using csLTDMC;

namespace SurfaceScan.Modules.MotionControl;

public class MotionControl : Base
{
    public static int TotalAxis { get; set; } = 0;
    public static List<double> AxisPositon = null!;
    public static List<double> StartAxisPositon = null!;
    public new static bool MotiHold { get; set; } = false;
    public new static bool TrackHold { get; set; } = false;
    public static ushort CardNo { get; } = 0;
    public static ushort ErrCode { get; set; } = 0;
    public static ushort StateMachine { get; set; } = 0;
    public Board Board { get; private set; }
    public Axis Axis { get; private set; }
    public Track Track { get; private set; }
    public Position Position { get; private set; }

    public MultiMotion MultiMotion { get; private set; }

    public Scan Scan { get; private set; }


    public MotionControl()
    {
        Board = new Board();
        Axis = new Axis();
        Track = new Track();
        Position = new Position();
        MultiMotion = new MultiMotion();
        Scan = new Scan();
        MotiHold = false;
        TrackHold = false;
        TracSample = false;
        TotalAxis = GetTotalAxis();
        AxisPositon = new List<double>();
        StartAxisPositon = new List<double>();


        LTDMC.dmc_board_init();
    }
}