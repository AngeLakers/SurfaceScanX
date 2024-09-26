using csLTDMC;
using SurfaceScan.Modules.Log;
using SurfaceScan.Modules.States;

namespace SurfaceScan.Modules.MotionControl;

public class MotionControl : Base
{
    public static int TotalAxis { get; set; } = 6; //默认 以防出错

    public static List<double> AxisPositon = null!;
    

    public static List<double> StartAxisPositon = null!;
    public static List<double> EndAxisPositon = null!;

    public Axis Axis { get; private set; }
    public Track Track { get; private set; }
    public Position Position { get; private set; }
    public StateMachine MotionControlStateMachine { get; set; }


    public MotionControl(StateManager stateManager)
    {
        try
        {
            Axis = new Axis();
            Track = new Track();
            Position = new Position();

            MotiHold = false;
            TrackHold = false;
            TracSample = false;
            TotalAxis = GetTotalAxis();
            AxisPositon = new List<double>();
            StartAxisPositon = new List<double>();
            Board.BoardLink();
            
            
            MotionControlStateMachine = new StateMachine();
            stateManager.RegisterStateMachine("DataAcquire", MotionControlStateMachine);
            MotionControlStateMachine.SetState(new DataAcquireState());
        }
        catch (Exception ex)
        {
            LogManager.Error($"初始化运动控制模块失败: {ex.Message}");
            throw;
        }

        LogManager.Info("运动控制模块初始化成功");
    }

    
}