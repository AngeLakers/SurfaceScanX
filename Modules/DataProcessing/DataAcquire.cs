using System.Drawing;
using SurfaceScan.Modules.Log;
using SurfaceScan.Modules.MotionControl;

namespace SurfaceScan.Modules.DataProcessing;
using System.Collections.Concurrent;
public class DataAcquire
{
    public static double[] TrackPoint { get; } = new double[5];
    static readonly object _lockObj = new object();
    // 使用 ConcurrentBag 替代 List
    public static ConcurrentBag<double[]> PointGroup = new ConcurrentBag<double[]>();
  



static DataAcquire()
{
    // 订阅 ReadRequest 事件
    PCI9850Control.ReadRequest += OnReadRequestHandler;
}

private static void OnReadRequestHandler(object sender, DataEventArgs args)
{
    // 通过事件参数获取数据
    var data = args.Data;
    PCI9850Control.Block = true;
    //当读取数据时，将数据存储到缓冲区
    if (Base.TracSample)
    {
        // 读取获取的采样数据 并且在范围内 获取最大值
        int max = 0, max_loc = 0;

        Parallel.For((int)SignalParameters.GateStartPoint, (int)SignalParameters.GateEndPoint, i =>
        {
            int diff = data[i] - 128;
            int value = (diff < 0) ? -diff : diff;

            // 使用锁确保线程安全
            lock (_lockObj)
            {
                if (value <= max) return;
                max = value;
                max_loc = i;
            }
        });
        // 使用容器储存点的对应数据

        TrackPoint[0] = MotionControl.MotionControl.AxisPositon[(int)Resources.Properties.Axis.X];
        TrackPoint[1] = MotionControl.MotionControl.AxisPositon[(int)Resources.Properties.Axis.Z];
        TrackPoint[2] = (MotionControl.MotionControl.AxisPositon[(int)Resources.Properties.Axis.A] +
                         MotionControl.MotionControl.AxisPositon[(int)Resources.Properties.Axis.B] / 2) / 2;
        TrackPoint[3] = max;
        TrackPoint[4] = max_loc;
        // 加入点集合
        PointGroup.Add(TrackPoint);
        MotionControl.Base.TracSample = true;
        if (max < SignalParameters.GateHeight)
        {
            MotionControl.Base.MotiHold = true;
            // caculation_correction
            PointGroup.Clear();
            //Moti_para_block =false;
        }
    }
}


}