using SurfaceScan.Modules.Log;
using SurfaceScan.Resources.Properties;

namespace SurfaceScan.Modules.States;

public class MotionControlIdleState: IState
{
    public void Enter()
    {
        LogManager.Info("运动控制模块进入空闲状态");
    }

    public void Update()
    {
        throw new NotImplementedException();
    }

    public void Exit()
    {
        LogManager.Info("运动控制模块开始工作");
    }
}


public class MotionControlMotionState: IState
{
    public void Enter()
    {
        LogManager.Info("轴已经进入运动状态");
    }

    public void Update()
    {
        throw new NotImplementedException();
    }

    public void Exit()
    {
        LogManager.Info("轴已经退出运动状态");
    }
}

public class MotionControlTrackState: IState
{
    public void Enter()
    {
        throw new NotImplementedException();
    }

    public void Update()
    {
        throw new NotImplementedException();
    }

    public void Exit()
    {
        throw new NotImplementedException();
    }
}

public class MotionControlTrackMotionState: IState
{
    public void Enter()
    {
        LogManager.Info("采样继续，轴继续运动");
    }

    public void Update()
    {
        throw new NotImplementedException();
    }

    public void Exit()
    {
        LogManager.Info("采样结束，轴停止运动");
    }
}

public class ErrorState: IState
{
    public void Enter()
    {
        LogManager.Info("运动控制模块错误");
    }

    public void Update()
    {
        throw new NotImplementedException();
    }

    public void Exit()
    {
        LogManager.Info("运动控制模块错误已经解决");
    }
}