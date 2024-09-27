using SurfaceScan.Modules.Log;
using SurfaceScan.Resources.Properties;

namespace SurfaceScan.Modules.States;

using System;
using System.Collections.Generic;

public static class StateManager
{
    // 用于存储各个模块的状态机
    private static Dictionary<string, StateMachine> _stateMachines = new Dictionary<string, StateMachine>();

    // 注册状态机
    public static void RegisterStateMachine(string moduleName, StateMachine stateMachine)
    {
        if (_stateMachines.ContainsKey(moduleName))
        {
            LogManager.Warning($"StateMachine for {moduleName} is already registered.");
        }
        else
        {
            _stateMachines[moduleName] = stateMachine;
            LogManager.Info($"StateMachine for {moduleName} registered successfully.");
        }
    }

    // 获取某个模块当前状态
    public static IState? GetCurrentState(string moduleName)
    {
        if (_stateMachines.TryGetValue(moduleName, out var stateMachine))
        {
            return stateMachine.GetCurrentState();
        }

        LogManager.Error($"StateMachine for {moduleName} not found.");
        return null;
    }

    // 更新所有状态机（例如在主循环中调用）
    public static void UpdateAll()
    {
        foreach (var stateMachine in _stateMachines.Values)
        {
            stateMachine.Update();
        }
    }
    
    public static void SetState(string moduleName, IState newState)
    {
        if (_stateMachines.TryGetValue(moduleName, out var stateMachine))
        {
            stateMachine.SetState(newState);
            LogManager.Info($"StateMachine for {moduleName} state set to {newState.GetType().Name}.");
        }
        else
        {
            LogManager.Error($"StateMachine for {moduleName} not found.");
        }
    }
}