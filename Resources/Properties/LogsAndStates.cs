namespace SurfaceScan.Resources.Properties;


public enum LogLevel
{
    Info,
    Debug,
    Error
}

public interface IState
{
    // 当进入状态时调用
    void Enter();

    // 当状态处于活跃状态时调用，执行持续的操作
    void Update();

    // 当退出状态时调用
    void Exit();
}

public interface IStateMachine
{
    // 设置初始状态
    void SetState(IState state);

    // 切换到新的状态
    void ChangeState(IState newState);

    // 更新当前状态
    void Update();
}