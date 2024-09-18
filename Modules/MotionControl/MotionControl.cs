using csLTDMC;
using SurfaceScan.Modules.Log;

namespace SurfaceScan.Modules.MotionControl;

public class MotionControl : Base
{
    public static int TotalAxis { get; set; } = 0;
    public static List<double> AxisPositon = null!;
    public static List<double> StartAxisPositon = null!;
    public static List<double> EndAxisPositon = null!;

    public Axis Axis { get; private set; }
    public Track Track { get; private set; }
    public Position Position { get; private set; }


    public MotionControl()
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
        LogManager.Info("运动控制模块初始化成功");
    }
}