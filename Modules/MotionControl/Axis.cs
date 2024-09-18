using csLTDMC;
using SurfaceScan.Modules.Log;

namespace SurfaceScan.Modules.MotionControl;

public class Axis : Base
{
    public static void EnableAllAxes()
    {
        try
        {
            for (int i = 0; i < MotionControl.TotalAxis; i++)
            {   
                LTDMC.nmc_set_axis_enable(0, decimal.ToUInt16(i));
            }
            
            LogManager.Info("启用所有轴成功");
        }
        catch (Exception e)
        {
            LogManager.Error("启用所有轴失败: " + e.Message);
            throw;
        }


        SetEquiv(); // 设置轴的脉冲当量
        Position.GetPosition(MotionControl.AxisPositon);
    }

    public static void DisableAllAxes()
    {
        try
        {
            for (int i = 0; i < MotionControl.TotalAxis; i++)
            {
                LTDMC.nmc_set_axis_disable(0, decimal.ToUInt16(i));
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
            LTDMC.dmc_set_position_unit(CardNo, decimal.ToUInt16(axis), 0);
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
                LTDMC.dmc_set_position_unit(MotionControl.CardNo, decimal.ToUInt16(i), 0);
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
                LTDMC.dmc_stop(MotionControl.CardNo, decimal.ToUInt16(i), 0);
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