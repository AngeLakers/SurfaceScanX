namespace SurfaceScan.Modules.MotionControl;
using LTDMC;
public class Board:Base
{
    public void BoardLink()
    {
        // 开启板卡连接
        LTDMC.__Internal.dmc_board_init();
    }

    public void BoardReset()
    {    
        // 重置板卡
        LTDMC.__Internal.dmc_board_init();
        LTDMC.__Internal.dmc_soft_reset(0);
    }
}