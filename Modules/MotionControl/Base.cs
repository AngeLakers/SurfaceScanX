using SurfaceScan.Modules.Log;

namespace SurfaceScan.Modules.MotionControl;

using csLTDMC;

public class Base
{
    // 共享常量
    public const double Pi = 3.1415926535;
    public const double MoveRadius = 10.25e4;
    public static bool MotiHold { get; set; } = false;
    public static bool TracSample { get; set; } = false;
    public static ushort CardNo { get; } = 0;
    public static ushort ErrCode { get; set; } = 0;
    public static ushort StateMachine { get; set; } = 0;
    public new static bool TrackHold { get; set; } = false;
    static int _errcode = 0; //总线错误代码
    static int _statemachine= 0; //状态机状态

    protected Base()
    {
    }

    protected static short GetTotalAxis()
    {
        // 保险起见，先初始化为 6
        uint total = 6;
        short result = 6;

        try
        {
            // 调用 nmc_get_total_axes 函数
            result = LTDMC.nmc_get_total_axes(decimal.ToUInt16(MotionControl.CardNo), ref total);

            // 检查返回值是否成功
            if (result != 0)
            {
                throw new Exception($"错误代码: {result}");
            }
        }
        catch (Exception ex)
        {
            // 记录错误日志
            LogManager.Error($"获取轴数失败: {ex.Message}");
            // 重新抛出异常
            throw;
        }

        return result;
    }

    protected static void SetEquiv()
    {
        try
        {
            for (int i = 0; i < MotionControl.TotalAxis; i++)
            {
                // 设置轴的脉冲当量
                if (i != 2 && i != 5)
                {
                    LTDMC.dmc_set_equiv(Base.CardNo, decimal.ToUInt16(i), 1);
                }
            }

            // z轴和下面盘 加了1/10 减速器
            LTDMC.dmc_set_equiv(Base.CardNo, (ushort)Resources.Properties.Axis.Z, 10);
            LTDMC.dmc_set_equiv(Base.CardNo, (ushort)Resources.Properties.Axis.W, 10);
            LogManager.Info("设置脉冲当量成功");
        }
        catch (Exception ex)
        {
            LogManager.Error($"设置脉冲当量失败: {ex.Message}");
            throw;
        }
    }


    public static void SetProfileUnit(int axis, double speed, int ratio)
    {
        try
        {
            // 设置轴的运动参数
            LTDMC.dmc_set_profile_unit(MotionControl.CardNo, (ushort)axis, speed * ratio, speed, 0.1, 0.1,
                speed * ratio);
            LogManager.Info("设置轴的运动参数成功");
        }
        catch (Exception ex)
        {
            LogManager.Error($"设置轴的运动参数失败: {ex.Message}");
            throw;
        }
    }

    public static void SetVectorProfileUnit(int axis, double speed, int ratio)
    {
        // 设置矢量运动参数

        try
        {
            // 设置轴的运动参数
            LTDMC.dmc_set_vector_profile_unit(MotionControl.CardNo, (ushort)axis, speed * ratio, speed, 0.1, 0.1, 0.1);
            LogManager.Info("设置轴的插补运动参数成功");
        }
        catch (Exception ex)
        {
            LogManager.Error($"设置轴的插补运动参数失败: {ex.Message}");
            throw;
        }
    }


    public static bool CheckAxisStatus(int axis)
    {
        try
        {
            var status = LTDMC.dmc_check_done(0, (ushort)axis);
            LogManager.Info("检查轴状态成功");
            return status;
        }
        catch (Exception ex)
        {
            LogManager.Error($"检查轴状态失败: {ex.Message}");
            throw;
        }
    }
}