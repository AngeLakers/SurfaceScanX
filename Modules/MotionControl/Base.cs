namespace SurfaceScan.Modules.MotionControl;

using csLTDMC;

public class Base
{
    // 共享常量
    public const double PI = 3.1415926535;
    protected const double MoveRadius = 10.25e4;

    public bool MotiHold, TracSample;


    public Base()
    {
    }

    public short GetTotalAxis()
    {   // 保险起见，先初始化为 6
        uint total = 6;
        short result = 6;
        


        {
            // 调用 nmc_get_total_axes 函数
            result = LTDMC.nmc_get_total_axes(decimal.ToUInt16(MotionControl.CardNo), ref total);

            // 检查返回值是否成功
            if (result != 0)
            {
                throw new Exception($"Error in fetching total axes. ");
            }
        }


        return result;
    }
    
}