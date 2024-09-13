
namespace SurfaceScan.Modules.MotionControl;

using csLTDMC;

public class Helper:Base
{   // 初始化多轴位置
    public void InitalPosition(List<double> positions)
    {
        double dCmdPos = 0;
        for (int i = 0; i < MotionControl.TotalAxis; i++)
        {   
            LTDMC.dmc_get_position_unit(decimal.ToUInt16(MotionControl.CardNo), decimal.ToUInt16(i), ref dCmdPos);
            
            positions.Add(dCmdPos);
        }
        
        
        
    }
    // 更新多轴位置
    public static void GetPosition(List<double> positions)
    {
        double dCmdPos = 0;
        int axis = 0;
        for (int i = 0; i < MotionControl.TotalAxis; i++)
        {   LTDMC.dmc_get_position_unit(decimal.ToUInt16(MotionControl.CardNo), decimal.ToUInt16(axis), ref dCmdPos);
            positions[i] = dCmdPos;
        }

        
    }

    public static void SetProfileUnit(int axis,double speed,int ratio)
    {   // 设置轴的运动参数
        LTDMC.dmc_set_profile_unit(MotionControl.CardNo, 0, speed*ratio, speed, 0.1, 0.1, 0.1);
    }
    
    public void SetVectorProfileUnit(double speed, int ratio)
    {   // 设置矢量运动参数
        LTDMC.dmc_set_vector_profile_unit(MotionControl.CardNo, 0, speed*ratio, speed, 0.1, 0.1, 0.1);
    }
    
    public static void SetEquiv()
    {
        for (int i = 0; i < MotionControl.TotalAxis; i++)
        {
            // 设置轴的脉冲当量
            if (i != 2 && i != 5)
            {
                LTDMC.dmc_set_equiv(0, decimal.ToUInt16(i), 1);
            }
        }

        // z轴和下面盘 加了1/10 减速器
        LTDMC.dmc_set_equiv(0, 2, 10);
        LTDMC.dmc_set_equiv(0, 5, 10);
    }

    public static bool CheckAxisStatus(int axis)
    {
        return LTDMC.dmc_check_done(0, (ushort)axis);
    }
}