using SurfaceScan.Modules.Log;
using SurfaceScan.Resources.Properties;

namespace SurfaceScan.Modules.States;

public class DataAcquireState: IState
{
    public void Enter()
    {
       LogManager.Info("开始进入数据采样状态");
    }

    public void Update()
    {
        throw new NotImplementedException();
    }

    public void Exit()
    {
        LogManager.Info("结束数据采样状态");
    }
}

public class DataAcquireIdleState: IState
{
    public void Enter()
    {
        LogManager.Info("开始进入数据采样空闲状态");
    }

    public void Update()
    {
        throw new NotImplementedException();
    }

    public void Exit()
    {
        LogManager.Info("结束数据采样空闲状态");
    }
}