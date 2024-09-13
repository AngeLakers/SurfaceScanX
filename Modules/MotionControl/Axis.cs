using csLTDMC;

namespace SurfaceScan.Modules.MotionControl;

public class Axis : Base
{
    public void EnableAllAxes()
    {
        for (int i = 0; i < MotionControl.TotalAxis; i++)
        {
            LTDMC.nmc_set_axis_enable(0, decimal.ToUInt16(i));
        }

        Helper.SetEquiv();   

        Helper.GetPosition(MotionControl.AxisPositon);
    }

    public void DisableAllAxes()
    {
        for (int i = 0; i < MotionControl.TotalAxis; i++)
        {
            LTDMC.nmc_set_axis_disable(0, decimal.ToUInt16(i));
        }

        // 更新位置
        Helper.GetPosition(MotionControl.AxisPositon);
    }

    public static void ResetAxis(int axis)
    {
        // 可自定义reset哪个轴
        LTDMC.dmc_set_position_unit(MotionControl.CardNo, decimal.ToUInt16(axis), 0);

        // axis_reset implementation
    }

    public static void ResetAllAxes()
    {
        // 清零位置
        for (int i = 0; i < MotionControl.TotalAxis; i++)
        {
            LTDMC.dmc_set_position_unit(MotionControl.CardNo, decimal.ToUInt16(i), 0);
        }
    }

    public void MoveAxis(int axis, int dir, double speed, double length)
    {
        // axis_move implementation
    }

    public static void StopAllAxes()
    {
        // 停止所有轴
        
        for (int i = 0; i < MotionControl.TotalAxis; i++)
        {
            LTDMC.dmc_stop(MotionControl.CardNo, decimal.ToUInt16(i), 0);
        }
        
    }
    
    
    

    
}