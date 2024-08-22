namespace SurfaceScan.Modules.MotionControl;
using LTDMC;
public class Base
{    
    // 共享常量
    protected const double PI = 3.1415926535;
    protected const double MoveRadius = 10.25e4;
    
    public bool MotiHold,TracSample;
   
    
    
    public Base()
    {
       
    }

    public short GetTotalAxis()
    {    uint total ;
        short result;

        // 获取总轴
        unsafe
        {    uint totalAxes = 0;
            
            {
                // 调用 nmc_get_total_axes 函数
                 result = LTDMC.__Internal.nmc_get_total_axes(0, &totalAxes);

                // 检查返回值是否成功
                if (result != 0)
                {
                    throw new Exception($"Error in fetching total axes. Error code: {result}");
                }
                
            }
            
            
        }

        return result;

    }

    
        // public unsafe void GetPosition()
        // {
        //     var temp =0;
        //     uint axis = (uint)GetTotalAxis();
        //     for (int i = 0; i < axis; i++)
        //     {
        //         LTDMC.__Internal.dmc_get_position_unit(0, (ushort)i, temp);
        //     }
        // }
    
}