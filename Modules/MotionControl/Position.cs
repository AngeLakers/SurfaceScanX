using SurfaceScan.Modules.Log;
using SurfaceScan.Resources.Properties;
using static SurfaceScan.Modules.MotionControl.ControlParameters;

namespace SurfaceScan.Modules.MotionControl;

using csLTDMC;
using Resources;

public class Position : Base
// 常量定义

//len = 5e4,
{
    // 常量定义
    const double DegreeConversion = Pi * 2 / 360000; // 36e4 用作将编码器单位转换为弧度
    const double Acceleration = 0.1; // 加速时间
    const double Deceleration = 0.1; // 减速时间
    const double SmoothingRatio = 0.2; // 运动平滑比率

   
    //double probeDeg = paras[9] / 2 * PI * 2 / 36e4;
    //探头角度计算，具体怎么算不懂。
    public void BackToOrigin(ushort myCardNo, ushort myMode)
    {
        ushort[] myAxes = new ushort[6] { 0, 1, 2, 3, 4, 5 };
        ushort[] states = new ushort[6];
        ushort[] statemachines = new ushort[6];

        // 定义速度参数，假设这些值都是固定的
        double startVelocity = 1000; // 起始速度
        double runVelocity = 5000; // 运行速度
        double acceleration = 0.1; // 加速度
        double deceleration = 0.1; // 减速度

        for (int i = 0; i < 6; i++)
        {
            ushort axis = myAxes[i];

            // 获取轴状态机
            LTDMC.nmc_get_axis_state_machine(myCardNo, axis, ref statemachines[i]);

            if (statemachines[i] == 4) // 轴状态机准备好
            {
                // 设置速度曲线参数，参考 dmc_set_profile_unit 的方式


                // 设置回原点模式，设置该轴的速度曲线参数
                LTDMC.nmc_set_home_profile(myCardNo, axis, myMode, startVelocity, runVelocity, acceleration,
                    deceleration, 0);

                // 执行回零运动
                LTDMC.nmc_home_move(myCardNo, axis);

                // // 等待回零运动完成
                // while (LTDMC.dmc_check_done(MyCardNo, axis) == 0)
                // {
                // }

                // 判断回零是否正常完成
                LTDMC.dmc_get_home_result(myCardNo, axis, ref states[i]);
                if (states[i] == 1)
                {
                    Console.WriteLine($"轴 {axis} 回零完成");
                }
                else
                {
                    Console.WriteLine($"轴 {axis} 回零失败");
                }
            }
            else
            {
                Console.WriteLine($"轴 {axis} 未处于准备好状态，状态机值: {statemachines[i]}");
            }
        }
    }
    //
    // public void ControlAxes(ushort MyCardNo, ushort Mymode)
    // {
    //     ushort[] myAxes = new ushort[6] { 0, 1, 2, 3, 4, 5 };
    //     ushort[] states = new ushort[6];
    //     ushort[] stateMachines = new ushort[6];
    //     Thread[] axisThreads = new Thread[6];
    //
    //     for (int i = 0; i < 6; i++)
    //     {
    //         int axisIndex = i; // Local copy for thread safety
    //         axisThreads[i] = new Thread(() => ControlAxis(MyCardNo, myAxes[axisIndex], Mymode,
    //             ref stateMachines[axisIndex], ref states[axisIndex]));
    //         axisThreads[i].Start();
    //     }
    //
    //     // Wait for all threads to finish
    //     foreach (Thread t in axisThreads)
    //     {
    //         t.Join();
    //     }
    //
    //     // Check if all axes are in the ready state
    // }
    //
    // private void ControlAxis(ushort myCardNo, ushort axis, ushort mymode, ref ushort statemachine, ref ushort state)
    // {
    //     // 获取轴状态机
    //     LTDMC.nmc_get_axis_state_machine(myCardNo, axis, ref statemachine);
    //
    //     if (statemachine == 4) // 轴状态机准备好
    //     {
    //         // 设置回原点模式，设置该轴的速度曲线参数
    //         LTDMC.nmc_set_home_profile(myCardNo, axis, mymode, 500, 1000, 0.1, 0.1, 0);
    //
    //         // 执行回零运动
    //         LTDMC.nmc_home_move(myCardNo, axis);
    //
    //         // 等待回零运动完成
    //         // while (！LTDMC.dmc_check_done(MyCardNo, axis))
    //         // {
    //         //     Thread.Sleep(100);
    //         // }
    //
    //         // 判断回零是否正常完成
    //         LTDMC.dmc_get_home_result(myCardNo, axis, ref state);
    //         if (state == 1)
    //         {
    //             Console.WriteLine($"轴 {axis} 回零完成");
    //         }
    //         else
    //         {
    //             Console.WriteLine($"轴 {axis} 回零失败");
    //         }
    //     }
    //     else
    //     {
    //         Console.WriteLine($"轴 {axis} 未处于准备好状态，状态机值: {statemachine}");
    //     }
    // }


    public static void AxialMove(int dir, double speed, double length)
    {
        try
        {
            // 探头在 X 和 Z轴沿轴方向运动    
            // 获取探头相对初始当前弧度,垂直于地面的角度的。
            //根据需要移动距离长度 乘以弧度cos/sin 来分配给轴移动的信息 在相对位置模式下
            // 使用直线插补运动


            // 获取所有轴的当前位置
            GetPosition(MotionControl.AxisPositon);

            // A轴的角度，以弧度表示
            double probeDeg = MotionControl.AxisPositon[(int)Resources.Properties.Axis.A] * DegreeConversion;

            // 计算目标位置，根据指定的长度和探头角度
            double[] targetPosition = new double[2];
            targetPosition[0] = length * Math.Sin(probeDeg); // X 轴
            targetPosition[1] = length * Math.Cos(probeDeg); // Z 轴
            LogManager.Info("目标位置计算成功");
            // 轴列表，分别表示 X 轴和 Z 轴
            ushort[] axisList = new ushort[]
            {
                (ushort)Resources.Properties.Axis.X,
                (ushort)Resources.Properties.Axis.Z
            };

            // 如果方向是反向，调整目标位置 （可能要修改）
            if (dir == (int)Resources.Properties.Direction.Forward)
            {
                for (int i = 0; i < targetPosition.Length; i++)
                {
                    targetPosition[i] = -targetPosition[i]; // 将目标位置反向
                }
            }

            // 设置运动的矢量配置，速度和加速/减速参数
            LTDMC.dmc_set_vector_profile_unit(
                MotionControl.CardNo, 0,
                speed * SmoothingRatio, // 平滑速度
                speed, // 目标速度
                Acceleration, // 加速时间
                Deceleration, // 减速时间
                speed * SmoothingRatio // 平滑的结束速度
            );
            LogManager.Info("设置轴向运动参数成功");
            // 执行直线插补运动，X 和 Z 轴沿着目标位置运动
            LTDMC.dmc_line_unit(
                MotionControl.CardNo,
                0, 2, axisList, targetPosition, 0
            );
            LogManager.Info("轴向运动成功");
        }
        catch (Exception e)
        {
            LogManager.Error("轴向运动发生错误: " + e.Message);
            throw;
        }
    }


    public static void TangentialMove(int dir, double speed, double length)
    {
        try
        {
            // 探头在 X 和 Z轴沿轴切线运动
            // 获取探头相对初始当前弧度,垂直于地面的角度的。
            //根据需要移动距离长度 乘以弧度cos/sin 来分配给轴移动的信息 在相对位置模式下
            // 使用直线插补运动
            GetPosition(MotionControl.AxisPositon);
            double probeDeg = MotionControl.AxisPositon[(int)Resources.Properties.Axis.A] * DegreeConversion;
            double[] targetPosition = new double[2];
            targetPosition[0] = length * Math.Cos(probeDeg); // X 轴
            targetPosition[1] = length * Math.Sin(probeDeg) * -1; // Z 轴负方向

            // 轴列表，分别表示 X 轴和 Z 轴
            ushort[] axisList = new ushort[]
            {
                (ushort)Resources.Properties.Axis.X,
                (ushort)Resources.Properties.Axis.Z
            };
            LogManager.Info("目标位置计算成功");
            // 如果方向是反向，调整目标位置 （可能要修改）
            if (dir == (int)Resources.Properties.Direction.Forward)
            {
                for (int i = 0; i < targetPosition.Length; i++)
                {
                    targetPosition[i] = -targetPosition[i]; // 将目标位置反向
                }
            }

            // 设置运动的矢量配置，速度和加速/减速参数
            LTDMC.dmc_set_vector_profile_unit(
                Base.CardNo, 0,
                speed * SmoothingRatio, // 平滑速度
                speed, // 目标速度
                Acceleration, // 加速时间
                Deceleration, // 减速时间
                speed * SmoothingRatio // 平滑的结束速度
            );
            LogManager.Info("设置切向运动参数成功");
            // 执行直线插补运动，X 和 Z 轴沿着目标位置运动
            LTDMC.dmc_line_unit(
                MotionControl.CardNo,
                0, 2, axisList, targetPosition, 0
            );
            LogManager.Info("切向运动成功");
        }
        catch (Exception e)
        {
            LogManager.Error("轴向运动发生错误: " + e.Message);
            throw;
        }
    }

    // 希望给定角度沿着表面去运动, 先圆弧补差位置 再沿着新圆心画弧线
    public static void SurroundMove(int dir, double speed, double length)
    {
        // Length 为弧线
        try
        {
            //先沿着探头沿着X,Z轴 以保持轴的运动，圆周插补
            double[] center = new double[2];
            double[] target = new double[2];
            double probeDeg = MotionControl.AxisPositon[(int)Resources.Properties.Axis.A] * DegreeConversion;

            ushort[] axisList = new ushort[]
            {
                (ushort)Resources.Properties.Axis.X,
                (ushort)Resources.Properties.Axis.Z
            };
            // 计算圆心
            center[0] = MotionControl.AxisPositon[(int)Resources.Properties.Axis.X] - MoveRadius * Math.Sin(probeDeg);
            center[1] = MotionControl.AxisPositon[(int)Resources.Properties.Axis.Z] - MoveRadius * Math.Cos(probeDeg);
            // 计算目标位置(这里 length 为弧长吧？ 弧度可以加减吧 后续可能要MN修改 因为给值不一样)
            target[0] = center[0] + MoveRadius * Math.Cos(probeDeg + (length) * double.Pow(-1, dir));
            target[1] = center[1] + MoveRadius * Math.Sin(probeDeg + (length) * double.Pow(-1, dir));
            //这里传入的length 已经转换为 probe了
            LogManager.Info("目标位置计算成功");
            double time = MoveRadius * double.Pi * 2 * length / (36e4 * speed);
            double probeSpeed = length * 2 / time;

            if (dir == (int)Direction.Forward)
            {
                length = -length;
            }

            LTDMC.dmc_set_vector_profile_unit(0, 0, speed * 0.2, speed, 0.1, 0.1, speed * 0.2);
            LTDMC.dmc_set_profile_unit(0, 3, probeSpeed * 0.2, probeSpeed, 0.1, 0.1, probeSpeed * 0.2);
            LTDMC.dmc_arc_move_center_unit(0, 0, 2, axisList, target, center, (ushort)dir, 0, 1);
            LTDMC.dmc_pmove(0, (ushort)Resources.Properties.Axis.A,
                length * 2 + MotionControl.AxisPositon[(int)Resources.Properties.Axis.A], 1);
            LogManager.Info("环绕运动成功");
        }
        catch (Exception e)
        {
            LogManager.Error("环绕运动发生错误: " + e.Message);
            throw;
        }
    }

    // 以步长判定来走位置,然后扫描采点的方法
    public void SampleTangetialMove(int dir, double speed, double length, double step)
    {
        GetPosition(MotionControl.AxisPositon);

        Base.MotiHold = true;
        List<double> startPosition = MotionControl.AxisPositon.ToList();
        TangentialMove(dir, speed, length);
        int count = 0;
        while (Base.MotiHold)
        {
            GetPosition(MotionControl.AxisPositon);
            if (Math.Abs(MotionControl.AxisPositon[(int)Resources.Properties.Axis.X] -
                         startPosition[(int)Resources.Properties.Axis.X]) >= step)
            {
                count++;
                startPosition[(int)Resources.Properties.Axis.X] =
                    MotionControl.AxisPositon[(int)Resources.Properties.Axis.X];
                TangentialMove(dir, speed, length);
            }

            if (count >= 2)
            {
                Base.MotiHold = false;
            }
        }
    }


    public void InitialPosition(List<double> positions)
    {
        try
        {
            double dCmdPos = 0;
            for (int i = 0; i < MotionControl.TotalAxis; i++)
            {
                LTDMC.dmc_get_position_unit(decimal.ToUInt16(Base.CardNo), decimal.ToUInt16(i), ref dCmdPos);
                positions.Add(dCmdPos);
            }

            LogManager.Info("初始位置获取成功");
        }
        catch (Exception e)
        {
            LogManager.Error("初始位置获取失败: " + e.Message);
            throw;
        }
    }

    // 更新多轴位置
    public static void GetPosition(List<double> positions)
    {
        try
        {
            double dCmdPos = 0;
            int axis = 0;
            for (int i = 0; i < MotionControl.TotalAxis; i++)
            {
                LTDMC.dmc_get_position_unit(decimal.ToUInt16(Base.CardNo), decimal.ToUInt16(axis), ref dCmdPos);
                positions[i] = dCmdPos;
            }

            LogManager.Info("获取轴位置成功");
        }
        catch (Exception e)
        {
            LogManager.Error("获取轴位置失败: " + e.Message);
            throw;
        }
    }
}