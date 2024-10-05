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
            var result = LTDMC.dmc_board_init();
            switch (result)
            {
                case 0:
                    throw new Exception($"没有找到卡。{result}");
                case >= 1 and <= 8:
                    LogManager.Info($"登录板卡成功，卡数量：{result}");
                    break;
                case < 0:
                    LogManager.Error($"2 张或2 张以上控制卡的硬件设置卡号相同");
                    break;
            }
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
            // 执行总线软复位操作后，循环调用nmc_get_errcode 函数判断总线状态，如果总线状态正常，说明总线软复位成功，否则继续调用nmc_get_errcode 函数判断总线状态，直到总线状态正常
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

                //Task暂停
                Task.Delay(1000);
            }

            LogManager.Info("板卡软重置成功");
        }
        catch (Exception ex)
        {
            LogManager.Error($"板卡软重置失败: {ex.Message}");
            throw;
        }
    }

    public void BoardClose()
    {
        // 关闭板卡
        try
        {
            var result = LTDMC.dmc_board_close();
            if (result == 0)
            {
                LogManager.Info("板卡关闭成功");
            }
            else
            {
                //其他错误码抛出异常
                throw new Exception($"板卡关闭失败: {result}");
            }
        }catch (Exception ex)
        {
            LogManager.Error($"板卡关闭失败: {ex.Message}");
            throw;
        }
    }
}