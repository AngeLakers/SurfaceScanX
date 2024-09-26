using System.Drawing;
using SurfaceScan.Modules.Log;
using SurfaceScan.Modules.MotionControl;
using SurfaceScan.Modules.States;
using Axis = SurfaceScan.Resources.Properties.Axis;

namespace SurfaceScan.Modules.DataProcessing;

using System.Collections.Concurrent;

public class DataAcquire
{
    public static double[] TrackPoint { get; } = new double[5];

    static readonly object _lockObj = new object();

    // 使用 ConcurrentBag 替代 List
    public static ConcurrentBag<double[]> PointGroup = new ConcurrentBag<double[]>();
    public StateMachine DataAcquireStateMachine { get; set; }



    DataAcquire(StateManager stateManager)
    {
        DataAcquireStateMachine = new StateMachine();
        stateManager.RegisterStateMachine("DataAcquire", DataAcquireStateMachine);
        DataAcquireStateMachine.SetState(new DataAcquireState());
        // 订阅 ReadRequest 事件
        PCI9850Control.ReadRequest += OnReadRequestHandler;
    }

    public void OnReadRequestHandler(object sender, DataEventArgs args)
    {
        // 通过事件参数获取数据
        var data= args.Data;
       // 可能需要提前处理下传入的数据，让其在9850删除
        //当读取数据时，将数据存储到缓冲区
        try
        {
            if (DataAcquireStateMachine.GetCurrentState() is DataAcquireState)
            {
                // 读取获取的采样数据 并且在范围内 获取最大值
                int max = 0, maxLocation = 0;

                Parallel.For((int)SignalParameters.GateStartPoint, (int)SignalParameters.GateEndPoint, i =>
                {
                    int diff = data[i] - 128;
                    int value = (diff < 0) ? -diff : diff;

                    // 使用锁确保线程安全
                    lock (_lockObj)
                    {
                        if (value <= max) return;
                        max = value;
                        maxLocation = i;
                    }
                });
                // 使用容器储存点的对应数据

                TrackPoint[0] = MotionControl.MotionControl.AxisPositon[(int)Axis.X];
                TrackPoint[1] = MotionControl.MotionControl.AxisPositon[(int)Axis.Z];
                TrackPoint[2] = (MotionControl.MotionControl.AxisPositon[(int)Axis.A] +
                                 MotionControl.MotionControl.AxisPositon[(int)Axis.B] / 2) / 2;
                TrackPoint[3] = max;
                TrackPoint[4] = maxLocation;
                // 加入点集合
                PointGroup.Add(TrackPoint);
                DataAcquireStateMachine.ChangeState(new DataAcquireIdleState());
                if (max < SignalParameters.GateHeight)
                {
                    Base.MotiHold = true;
                    // caculation_correction
                    PointGroup.Clear();
                    //Moti_para_block =false;
                }
            }
        }
        catch
        {
            LogManager.Error("采样数据处理失败");
            // ignored
        }
        
        
    }
}