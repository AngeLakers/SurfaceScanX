namespace SurfaceScan.Modules.MotionControl;

using csLTDMC;
using Resources;

public class Position
// 常量定义

    //len = 5e4,
{
    // 常量定义
    const double DEGREE_CONVERSION = Base.PI * 2 / 360000; // 36e4 用作将编码器单位转换为弧度
    const double ACCELERATION = 0.1; // 加速时间
    const double DECELERATION = 0.1; // 减速时间

    const double SMOOTHING_RATIO = 0.2; // 运动平滑比率

    private const double MoveRadius = 102500;

    //double probe_deg = paras[9] / 2 * PI * 2 / 36e4;
    //探头角度计算，具体怎么算不懂。
    public static void BackToOrigin()
    {
        // 读取初始位置(0,0,0,0,0)
        short sRtn = 0;
        ushort statemachine = 0;

        // for (int i = 0; i < MotionControl.TotalAxis; i++)
        // {
        //     LTDMC.nmc_get_axis_state_machine(MotionControl.CardNo, decimal.ToUInt16(i), ref statemachine); //获取轴状态机
        //     if (statemachine == 4) //监控轴状态机的值，该值等于4 表示轴状态机处于准备好状态
        //     {
        //         // 速度 和 mode 可以自定义或者需要调整
        //         LTDMC.nmc_set_home_profile(MotionControl.CardNo, decimal.ToUInt16(i), 33, 2000, 4000, 0.1, 0.1, 0);
        //         //设置回原点模式,设置0 号轴梯形速度曲线参数
        //         LTDMC.nmc_home_move(MyCardNo, Myaxis); //执行回原点运动
        //         while (LTDMC.dmc_check_done(MyCardNo, Myaxis) == 0) // 判断轴运动状态，等待回零运动完成
        //         {
        //             Application.DoEvents();
        //         }
        //
        //         LTDMC.dmc_get_home_result(MyCardNo, Myaxis, ref state); //判断回零是否正常完成。
        //         if (state == 1) //回零正常完成
        //         {
        //             MessageBox.Show("回零完成");
        //         }
        //     }
        // }
    }


    public void AxialMove(int dir, double speed, double length)
    {
        // 探头在 X 和 Z轴沿轴方向运动    
        // 获取探头相对初始当前弧度,垂直于地面的角度的。
        //根据需要移动距离长度 乘以弧度cos/sin 来分配给轴移动的信息 在相对位置模式下
        // 使用直线插补运动


        // 获取所有轴的当前位置
        Helper.GetPosition(MotionControl.AxisPositon);

        // A轴的角度，以弧度表示
        double probe_deg = MotionControl.AxisPositon[(int)Resources.Properties.Axis.A] * DEGREE_CONVERSION;

        // 计算目标位置，根据指定的长度和探头角度
        double[] targetPosition = new double[2];
        targetPosition[0] = length * Math.Sin(probe_deg); // X 轴
        targetPosition[1] = length * Math.Cos(probe_deg); // Z 轴

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
            speed * SMOOTHING_RATIO, // 平滑速度
            speed, // 目标速度
            ACCELERATION, // 加速时间
            DECELERATION, // 减速时间
            speed * SMOOTHING_RATIO // 平滑的结束速度
        );

        // 执行直线插补运动，X 和 Z 轴沿着目标位置运动
        LTDMC.dmc_line_unit(
            MotionControl.CardNo,
            0, 2, axisList, targetPosition, 0
        );
    }


    public void TangentialMove(int dir, double speed, double length)
    {
        // 探头在 X 和 Z轴沿轴切线运动
        // 获取探头相对初始当前弧度,垂直于地面的角度的。
        //根据需要移动距离长度 乘以弧度cos/sin 来分配给轴移动的信息 在相对位置模式下
        // 使用直线插补运动

        Helper.GetPosition(MotionControl.AxisPositon);
        double probe_deg = MotionControl.AxisPositon[(int)Resources.Properties.Axis.A] * DEGREE_CONVERSION;
        double[] targetPosition = new double[2];
        targetPosition[0] = length * Math.Cos(probe_deg); // X 轴
        targetPosition[1] = length * Math.Sin(probe_deg) * -1; // Z 轴负方向

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
            speed * SMOOTHING_RATIO, // 平滑速度
            speed, // 目标速度
            ACCELERATION, // 加速时间
            DECELERATION, // 减速时间
            speed * SMOOTHING_RATIO // 平滑的结束速度
        );

        // 执行直线插补运动，X 和 Z 轴沿着目标位置运动
        LTDMC.dmc_line_unit(
            MotionControl.CardNo,
            0, 2, axisList, targetPosition, 0
        );
    }

    //先不管 有些逻辑 没有搞通 就是给定角度沿着表面去运动, 切线运动后调整姿态 再次确定法向量
    public void SurroundMove(int dir, double speed, double length)
    {
        //沿着探头沿着X,Z轴 以探头为圆心，半径为MoveRadius的圆周运动，圆周插补
        double[] Center = new double[2];
        double[] Target = new double[2];
        double probe_deg = MotionControl.AxisPositon[(int)Resources.Properties.Axis.A] * DEGREE_CONVERSION;

        ushort[] AxisList = new ushort[]
        {
            (ushort)Resources.Properties.Axis.X,
            (ushort)Resources.Properties.Axis.Z
        };
        // 计算圆心
        Center[0] = MotionControl.AxisPositon[(int)Resources.Properties.Axis.X] - MoveRadius * Math.Sin(probe_deg);
        Center[1] = MotionControl.AxisPositon[(int)Resources.Properties.Axis.Z] - MoveRadius * Math.Cos(probe_deg);
        // 计算目标位置(这里 length 为弧长吧？ 弧度可以加减吧 )
        Target[0] = Center[0] + MoveRadius * Math.Cos(probe_deg + (length / MoveRadius) * double.Pow(-1, dir));
        Target[1] = Center[1] + MoveRadius * Math.Sin(probe_deg + (length / MoveRadius) * double.Pow(-1, dir));

        double time = MoveRadius * Base.PI * 2 * length / (36e4 * speed);
        double probe_speed = length * 2 / time;

        if (dir == (int)Resources.Properties.Direction.Forward)
        {
            length = -length;
        }

        LTDMC.dmc_set_vector_profile_unit(0, 0, speed * 0.2, speed, 0.1, 0.1, speed * 0.2);
        LTDMC.dmc_set_profile_unit(0, 3, probe_speed * 0.2, probe_speed, 0.1, 0.1, probe_speed * 0.2);
        LTDMC.dmc_arc_move_center_unit(0, 0, 2, AxisList, Target, Center, (ushort)dir, 0, 1);
        LTDMC.dmc_pmove(0, 3, length * 2 + MotionControl.AxisPositon[(int)Resources.Properties.Axis.A], 1);
    }

    public void SampleTangetialMove(int dir, double speed, double length, double step)
    {
        Helper.GetPosition(MotionControl.AxisPositon);

        MotionControl.MotiHold = true;
        List<double> StartPosition = MotionControl.AxisPositon.ToList();
        TangentialMove(dir, speed, length);
        int Count =0;
        while (MotionControl.MotiHold)
        {
            Helper.GetPosition(MotionControl.AxisPositon);
            if (Math.Abs(MotionControl.AxisPositon[(int)Resources.Properties.Axis.X] - StartPosition[(int)Resources.Properties.Axis.X]) >= step)
            {
                Count++;
                StartPosition[(int)Resources.Properties.Axis.X] = MotionControl.AxisPositon[(int)Resources.Properties.Axis.X];
                TangentialMove(dir, speed, length);
            }
            if (Count >= 2)
            {
                MotionControl.MotiHold = false;
            }
        }
    }
}