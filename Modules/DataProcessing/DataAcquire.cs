using System.IO;
using System.Text;
using System.Windows;
using SurfaceScan.Modules.Log;
using SurfaceScan.Modules.MotionControl;
using SurfaceScan.Modules.States;
using Axis = SurfaceScan.Resources.Properties.Axis;
using System.Collections.Generic;

namespace SurfaceScan.Modules.DataProcessing;

using System.Collections.Concurrent;

public class DataAcquire
{
    public static double[] TrackPoint { get; } = new double[5];
    public String LoadPath = "D:\\SurfaceScan\\Data\\";// 先写个固定的路径
    static readonly object _lockObj = new object();

    // 使用 ConcurrentBag 替代 List
    public static ConcurrentBag<double[]> PointGroup = new ConcurrentBag<double[]>();
    public static List<Point> ReflectionPointGroup = new List<Point>();
    public static List<List<Point>> ReflectionPointGroupList = new List<List<Point>>();
    public StateMachine DataAcquireStateMachine { get; set; }


    public string SavePath { get; set; }


    DataAcquire()
    {
        DataAcquireStateMachine = new StateMachine();
        StateManager.RegisterStateMachine("DataAcquire", DataAcquireStateMachine);
        DataAcquireStateMachine.SetState(new DataAcquireState());
        // 订阅 ReadRequest 事件
        PCI9850Control.ReadRequest += OnReadRequestHandler;
    }

    public void OnReadRequestHandler(object sender, DataEventArgs args)
    {
        // 通过事件参数获取数据
        var data = args.Data;
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
                    StateManager.SetState("MotionControl", new MotionControlIdleState());
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


    public void TrackDataStoring()
    {
        const int batchSize = 1000; // 设置每个批次的大小
        List<double> saveStr = new List<double>(ReflectionPointGroupList.Sum(g => g.Count * 2)); // 预分配内存

        using (FileStream fileStream = new FileStream(SavePath, FileMode.Create, FileAccess.Write))
        using (BinaryWriter writer = new BinaryWriter(fileStream))
        {
            writer.Write((ushort)ReflectionPointGroupList.Count); // 直接写入组的数量
        
            foreach (var group in ReflectionPointGroupList)
            {
                writer.Write((ushort)group.Count); // 直接写入每个组的大小
                foreach (var point in group)
                {
                    saveStr.Add(point.X);
                    saveStr.Add(point.Y);
                
                    // 当达到批次大小时，写入数据
                    if (saveStr.Count >= batchSize * 2) // 每个点有两个值 (X, Y)
                    {
                        foreach (var value in saveStr) // 逐个写入 double 值
                        {
                            writer.Write(value);
                        }
                        saveStr.Clear(); // 清空缓存
                    }
                }
            }

            // 写入剩余的数据
            if (saveStr.Count > 0)
            {
                foreach (var value in saveStr) // 确保写入剩余数据
                {
                    writer.Write(value);
                }
            }
        }

        TracDataReady();
    }

    private void TracDataReady()
    {
        // 数据准备完成后的处理逻辑
    }
    
    public void LoadTracData()
    {
        try
        {
            using (FileStream fileStream = new FileStream(LoadPath, FileMode.Open, FileAccess.Read))
            using (BinaryReader reader = new BinaryReader(fileStream))
            {
                // 读取组的数量
                ushort groupCount = reader.ReadUInt16();
                ReflectionPointGroupList.Clear();

                // 读取每个组的数据
                for (int i = 0; i < groupCount; i++)
                {
                    ushort pointCount = reader.ReadUInt16();
                    List<Point> reflGroup = new List<Point>(pointCount);

                    // 直接读取坐标数据并创建点
                    for (int j = 0; j < pointCount; j++)
                    {
                        double x = reader.ReadDouble();
                        double y = reader.ReadDouble();
                        reflGroup.Add(new Point(x, y));
                    }

                    ReflectionPointGroupList.Add(reflGroup);
                }
            }

            TracDataReady();
            LogManager.Info("加载轨迹数据成功");
        }
        catch (Exception ex)
        {
            LogManager.Info("加载轨迹数据失败: " + ex.Message);
        }
    }
}