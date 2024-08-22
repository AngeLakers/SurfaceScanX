using System.Windows;
using Emgu.CV;

namespace SurfaceScan.Modules;

public class Algorithms
{
    public static void BSplineNatural(List<Point> inputPoints, List<double> inputX, List<double> predictedY,
        double[] normal)
    {
        predictedY.Clear();
        int n = inputPoints.Count;
        if (n < 3)
        {
            throw new ArgumentException("The number of input points is less than 3.");
        }
            

        // 初始化矩阵
        Matrix<double> a = new Matrix<double>(n - 1, 1);
        Matrix<double> b = new Matrix<double>(n - 1, 1);
        Matrix<double> d = new Matrix<double>(n - 1, 1);
        Matrix<double> dx = new Matrix<double>(n - 1, 1);
        Matrix<double> dy = new Matrix<double>(n - 1, 1);

        // 计算差值
        for (int i = 0; i < inputPoints.Count - 1; i++)
        {
            a[i, 0] = inputPoints[i].Y;
            dx[i, 0] = (inputPoints[i + 1].X - inputPoints[i].X);
            dy[i, 0] = (inputPoints[i + 1].Y - inputPoints[i].Y);
        }

        // 初始化三对角矩阵A和向量B
        Matrix<double> A = new Matrix<double>(n, n);
        Matrix<double> B = new Matrix<double>(n, 1);
        A[0, 0] = 1;
        A[n - 1, n - 1] = 1;

        for (int i = 1; i <= n - 2; i++)
        {
            A[i, i - 1] = dx[i - 1, 0];
            A[i, i] = 2 * (dx[i - 1, 0] + dx[i, 0]);
            A[i, i + 1] = dx[i, 0];
            B[i, 0] = 3 * (dy[i, 0] / dx[i, 0] - dy[i - 1, 0] / dx[i - 1, 0]);
        }

        // 直接矩阵求逆
        Matrix<double> A_inv = new Matrix<double>(n, n);
        CvInvoke.Invert(A, A_inv, Emgu.CV.CvEnum.DecompMethod.LU); // 求逆，LU分解方法也可以用于求逆

        // 计算 c = A^-1 * B
        Matrix<double> c = A_inv * B;

        for (int i = 0; i <= n - 2; i++)
        {
            d[i, 0] = (c[i + 1, 0] - c[i, 0]) / (3 * dx[i, 0]);
            b[i, 0] = dy[i, 0] / dx[i, 0] - dx[i, 0] * (2 * c[i, 0] + c[i + 1, 0]) / 3;
        }
        
        // 预分配空间，避免并行计算时频繁调整大小
        predictedY.Capacity = inputX.Count;

        // 使用Parallel.For进行并行化插值计算
        Parallel.For(0, inputX.Count, i =>
        {   
            double x = inputX[i];
            
            // 使用二分查找定位区间
            int j = BinarySearch(inputPoints, x, n);

            // 缓存常用计算结果，避免重复计算
            double x_j = inputPoints[j].X;
            double deltaX = x - x_j;
            double deltaX2 = deltaX * deltaX;
            double deltaX3 = deltaX2 * deltaX;

            // 计算插值
            double middleV = a[j, 0] +
                             b[j, 0] * deltaX +
                             c[j, 0] * deltaX2 +
                             d[j, 0] * deltaX3;

            predictedY[i] = middleV; // 使用索引直接赋值，避免 Add() 的锁操作

            if (normal != null)
            {
                double middleV_ = a[j, 0] +
                                  b[j, 0] * (x - 1 - x_j) +
                                  c[j, 0] * Math.Pow(x - 1 - x_j, 2) +
                                  d[j, 0] * Math.Pow(x - 1 - x_j, 3);
                normal[i] = middleV - middleV_; // 直接使用索引赋值 不晓得这里要不要请0
            }
        });
    }

    // 辅助函数：找到点 x 所在的区间
    
    // 二分查找替代线性查找
    private static int BinarySearch(List<Point> points, double x, int n)
    {
        int low = 0;
        int high = n - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;
            if (x < points[mid].X)
                high = mid - 1;
            else if (x > points[mid + 1].X)
                low = mid + 1;
            else
                return mid;
        }

        return n - 2; // 默认返回最后一个区间
    }
}