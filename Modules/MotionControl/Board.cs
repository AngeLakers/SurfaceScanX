namespace SurfaceScan.Modules.MotionControl;
using csLTDMC;
public class Board:Base
{
    public void BoardLink()
    {
        // 开启板卡连接
        LTDMC.dmc_board_init();
    }

    public void BoardSoftReset()
    {    
        // 重置板卡
        LTDMC.dmc_soft_reset(MotionControl.CardNo);
        BoardClose();
        // 等15秒
        BoardLink();
    }
    
    public void BoardHardReset()
    {
        // 重置板卡
        LTDMC.dmc_board_reset();
        BoardClose();
        // 等15秒
        BoardLink();
    }
    
    
    public void BoardClose()
    {
        // 关闭板卡
        LTDMC.dmc_board_close();
    }
}