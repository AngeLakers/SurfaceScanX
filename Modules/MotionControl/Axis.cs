namespace SurfaceScan.Modules.MotionControl;

using LTDMC;

public class Axis : Base
{
    public void EnableAllAxes()
    {
        // 开启所有轴
        MotionControl.TotalAxis = GetTotalAxis();
        for (int i = 0; i < MotionControl.TotalAxis; i++)
        {
            LTDMC.__Internal.nmc_set_axis_enable(0, (ushort)i);
            LTDMC.__Internal.dmc_set_equiv(0, (ushort)i, 1);
        }

        LTDMC.__Internal.dmc_set_equiv(0, 2, 10);
        LTDMC.__Internal.dmc_set_equiv(0, 5, 10);
        //位置获取，position 需要在其他类中实现
    }

    public void DisableAllAxes()
    {
        for (int i = 0; i < MotionControl.TotalAxis; i++)
        {
            LTDMC.__Internal.nmc_set_axis_disable(0, (ushort)i);
        }
        // axis_disable implementation
    }

    public void ResetAxis()
    {
        LTDMC.__Internal.dmc_set_position_unit(0, 3, 0);


        // axis_reset implementation
    }

    public void ResetAllAxes()
    {
        for (int i = 0; i < MotionControl.TotalAxis; i++)
        {
            LTDMC.__Internal.dmc_set_position_unit(0, (ushort)i,0);
        }
        // axis_reset_all implementation
    }

    public void MoveAxis(int axis, int dir, double speed, double length)
    {
        // axis_move implementation
    }

    public void StopAllAxes()
    {
        // axis_stop implementation
    }
}