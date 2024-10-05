using System.Windows;
using SurfaceScan.Modules.Log;
using SurfaceScan.Modules.MotionControl;
using static SurfaceScan.Modules.DataProcessing.DataAcquire;
using Axis = SurfaceScan.Resources.Properties.Axis;

namespace SurfaceScan.Modules.DataProcessing;

public class DataProcess
{
    public void CalculateCorrection()
    {
        // 处理反射峰值最大点 算曲面位置
        try
        {
            ReflectionPointGroup.Clear();
            if (PointGroup.Count < 3)
            { // 暂时不处理
                Thread.Sleep(100);
            }

            foreach (var pointArray in PointGroup)
            {
                Point point = new Point();
                point.X = pointArray[0] - (double.Sin(pointArray[2] * 2 * double.Pi / 36e4)) *
                    (SignalParameters.ProbeLength + pointArray[4] * SignalParameters.SoundSpeed / 4e2);
                point.Y = pointArray[1] - (double.Sin(pointArray[2] * 2 * double.Pi / 36e4)) *
                    (SignalParameters.ProbeLength + pointArray[4] * SignalParameters.SoundSpeed / 4e2);
                ReflectionPointGroup.Add(point);
            }

            List<double> inputX = new List<double>(2);
            List<double> predictY = new List<double>();
            double[] normal = new double[] { };

            inputX.Add(ReflectionPointGroup.Last().X);
            inputX.Add(ReflectionPointGroup.Last().X - 1);
            Algorithms.BSplineNatural(ReflectionPointGroup, inputX, predictY, normal);
            double tanValue = (predictY[0] - predictY[1]) ;
            double currRad = double.Atan(tanValue);
            double currDegree = currRad/(2*double.Pi)*36e4;
            double distanceCorrection = PointGroup.Last()[4]*SignalParameters.SoundSpeed/4e2;
            ReflectionPointGroupList.Add(ReflectionPointGroup);
            Track.CorrectionDegree = (currDegree * -1) -(MotionControl.MotionControl.AxisPositon[(int)Axis.A] -
                                                         MotionControl.MotionControl.AxisPositon[(int)Axis.B] / 2) / 2;
            Track.CorrectionLength = distanceCorrection;
        }
        catch (Exception e)
        {
            LogManager.Info("计算修正参数出现错误: " + e.Message);
            throw;
        }
        //correction 
        return;
        // 计算相关性
    }

    public void CalculateScanPath()
    {
        //判断要饭谁点是不是空的。
        List<Point> planPoint;
       
        

    }

  
    
}