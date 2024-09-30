using csLTDMC;
using SurfaceScan.Modules.Log;
using SurfaceScan.Modules.MotionControl;

namespace SurfaceScan.Modules.MotionControl;

using csLTDMC;

public class Board
{
    // 开启板卡连接
    public void BoardInit()
    {
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

    //软重置板卡
    public void BoardSoftReset()
    {
        try
        {
            // 执行总线热复位操作后，循环调用nmc_get_errcode 函数判断总线状态，如果总线状态正常，说明总线热复位成功，否则继续调用nmc_get_errcode 函数判断总线状态，直到总线状态正常
            LTDMC.dmc_soft_reset(ControlParameters.CardNo);
            var errCode = Base.ErrCode;
            int retryCount = 0;

            while (LTDMC.nmc_get_errcode(ControlParameters.CardNo, 2, ref errCode) != 0)
            {
                if (retryCount++ >= ControlParameters.MaxRetries)
                {
                    LogManager.Error("板卡软重置超过最大重试次数");
                    return;
                }

                //Thread 暂停
                Thread.Sleep(1000);
            }

            LogManager.Info("板卡软重置成功");
        }
        catch (Exception ex)
        {
            LogManager.Error($"板卡软重置失败: {ex.Message}");
            throw;
        }
    }

    public void BoardHardReset()
    {
        try
        {
            // 重置板卡
            LTDMC.dmc_board_reset();
            BoardClose();
            // 等15秒
            Task.Delay(15000);
            BoardInit();
            LogManager.Info("板卡硬重置成功");
        }
        catch (Exception ex)
        {
            LogManager.Error($"板卡硬重置失败: {ex.Message}");
        }
    }


    public void BoardClose()
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