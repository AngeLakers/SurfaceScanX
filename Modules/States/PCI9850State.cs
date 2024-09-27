using SurfaceScan.Modules.Log;
using SurfaceScan.Modules.States;
using SurfaceScan.Resources.Properties;

namespace SurfaceScan.Modules.DataProcessing;

public partial class PCI9850InitState : IState
{
    private readonly StateMachine _stateMachine;

    public PCI9850InitState(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }


    public void Update()
    {
        LogManager.Info("结束初始化9850采集卡");
        _stateMachine.SetState(new PCI9850SamplingState());
    }

    public void Exit()
    {
        LogManager.Info("结束初始化9850采集卡成功");
        _stateMachine.ChangeState(new PCI9850SamplingState());
    }
}

public class PCI9850SamplingState : IState
{
  
    private Thread _grabThread;




    public void Enter()
    {
        LogManager.Info("9850采集卡开始持续采样");
    }

    public void Update()
    { 
        _grabThread = new Thread(PCI9850Control.GrabSignal);
        _grabThread.Start();
       
    }

    public void Exit()
    {    PCI9850Control._isRunning = false;
        _grabThread.Join(); // 等待线程结束
        LogManager.Info("PCI9850结束采样状态");
    }
}