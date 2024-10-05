using csLTDMC;
using SurfaceScan.Modules.Log;
using static SurfaceScan.Modules.MotionControl.ControlParameters;
namespace SurfaceScan.Modules.MotionControl;



public class Axis : Base
{
    private static ushort _errCode; //按照案例修改完成
    private static ushort _axisStateMachine;

    public void EnableAllAxes()
    {
        try
        {
            for (int i = 0; i < MotionControl.TotalAxis; i++)
            {
                LTDMC.nmc_get_errcode(CardNo, 2, ref _errCode);
                if (_errCode == 0)
                {
                    LTDMC.nmc_set_axis_enable(CardNo, decimal.ToUInt16(i));

                    LTDMC.nmc_get_axis_state_machine(CardNo, decimal.ToUInt16(i), ref _axisStateMachine);
                    DateTime dtStart = DateTime.Now; //获取当前时间
                    while (_axisStateMachine != 4) //监控轴状态机的值，该值等于4 表示轴状态机处于使能状态
                    {
                        if ((DateTime.Now - dtStart).TotalMilliseconds >= 1000) //1s 时间防止死循环
                        {
                            break;
                        }

                        LTDMC.nmc_set_axis_enable(CardNo, (ushort)i); //设置轴使能
                        LTDMC.nmc_get_axis_state_machine(CardNo, (ushort)i, ref _axisStateMachine); //获取状态机
                    }
                }
                else //总线不正常状态下不响应使能操作
                {
                    LTDMC.nmc_clear_errcode(CardNo, 2); //尝试清除总线错误
                    throw new Exception(_errCode.ToString());
                }
            }

            LogManager.Info("启用所有轴成功");
        }
        catch (Exception e)
        {
            LogManager.Error("启用所有轴失败: " + e.Message);
        }
        var result =SetEquiv(); // 设置轴的脉冲当量
        if (result ==false)
        {
            LogManager.Error("设置轴的脉冲当量失败");
        }
        Position.GetPosition(MotionControl.AxisPositon);
    }
    

    public static void DisableAllAxes()
    {
        try
        {
            for (int i = 0; i < MotionControl.TotalAxis; i++)
            {
                LTDMC.nmc_get_errcode(CardNo, 2, ref _errCode);
                if (_errCode == 0)
                {
                    LTDMC.nmc_set_axis_disable(CardNo, decimal.ToUInt16(i));
                }
                else //总线不正常状态下不响应使能操作
                {
                    LTDMC.nmc_clear_errcode(CardNo, 2); //尝试清除总线错误
                    throw new Exception(_errCode.ToString());
                }
            }

            // 更新位置
            Position.GetPosition(MotionControl.AxisPositon);
            LogManager.Info("禁用所有轴成功");
        }
        catch (Exception e)
        {
            LogManager.Error("禁用所有轴失败: " + e.Message);
            throw;
        }
    }

    public static void ResetAxisPosition(int axis)
    {
        // 可自定义reset哪个轴
        try
        {
           var result=LTDMC.dmc_set_position_unit(CardNo, decimal.ToUInt16(axis), 0);
           if (result != 0)
           {
               throw new Exception($"重置轴位置{axis}为失败: {result}");
           }
           LogManager.Info("重置轴位置为0成功");
        }
        catch (Exception e)
        {
            LogManager.Error("重置轴位置为0失败: " + e.Message);
            throw;
        }
    }

    public static void ResetAllAxesPosition()
    {
        try
        {
            // 清零位置
            for (int i = 0; i < MotionControl.TotalAxis; i++)
            {
                ResetAxisPosition(i);
            }

            LogManager.Info("重置所有轴位置为0成功");
        }
        catch (Exception e)
        {
            LogManager.Error("重置所有轴位置为0失败: " + e.Message);
            throw;
        }
    }

    public static void MoveAxis(int axis, int dir, double speed, double length)
    {
        // axis_move implementation
    }

    public static void StopAllAxes()
    {
        try
        {
            // 停止所有轴
            for (int i = 0; i < MotionControl.TotalAxis; i++)
            {
                var result = LTDMC.dmc_stop(CardNo, decimal.ToUInt16(i), 0);
                if (result != 0)
                {
                    throw new Exception($"停止轴{i}失败: {result}");
                }
            }
            

            LogManager.Info("停止所有轴成功");
        }
        catch (Exception e)
        {
            LogManager.Error("停止所有轴失败: " + e.Message);
            throw;
        }
    }
}