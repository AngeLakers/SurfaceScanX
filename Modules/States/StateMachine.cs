using SurfaceScan.Resources.Properties;

namespace SurfaceScan.Modules.States;

public class StateMachine : IStateMachine
{
    private IState _currentState;

    // 设置初始状态
    public void SetState(IState state)
    {
        _currentState = state;
        _currentState.Enter();
    }

    // 切换到新的状态
    public void ChangeState(IState newState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = newState;
        _currentState.Enter();
    }

    // 更新当前状态
    public void Update()
    {
        _currentState?.Update();
    }
    
    public IState GetCurrentState()
    {
        return _currentState;
    }
}