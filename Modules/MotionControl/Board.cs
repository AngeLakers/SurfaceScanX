using csLTDMC;
using SurfaceScan.Modules.Log;
using SurfaceScan.Modules.MotionControl;

namespace SurfaceScan.Modules.MotionControl;

using csLTDMC;

public static class Board
{
    public static void BoardLink()
    {
        // 开启板卡连接
        try
        {
            LTDMC.dmc_board_init();
            LogManager.Info("登录板卡成功");
        }
        catch (Exception ex)
        {
            LogManager.Error($"板卡初始化失败: {ex.Message}");
        }
    }

    public static async Task BoardSoftResetAsync()
    {
        try
        {
            // 重置板卡
            LTDMC.dmc_soft_reset(Base.CardNo);
            BoardClose();
            // 等15秒
            await Task.Delay(15000);
            BoardLink();
            LogManager.Info("板卡软重置成功");
        }
        catch (Exception ex)
        {
            LogManager.Error($"板卡软重置失败: {ex.Message}");
        }
    }

    public static async Task BoardHardResetAsync()
    {
        try
        {
            // 重置板卡
            LTDMC.dmc_board_reset();
            BoardClose();
            // 等15秒
            await Task.Delay(15000);
            BoardLink();
            LogManager.Info("板卡硬重置成功");
        }
        catch (Exception ex)
        {
            LogManager.Error($"板卡硬重置失败: {ex.Message}");
        }
    }


    public static void BoardClose()
    {
        // 关闭板卡
        try
        {
            LTDMC.dmc_board_close();
            LogManager.Info("板卡关闭成功");
        }
        catch (Exception ex)
        {
            LogManager.Error($"关闭板卡失败: {ex.Message}");
        }
    }
}