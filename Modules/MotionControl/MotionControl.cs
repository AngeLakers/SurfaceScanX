namespace SurfaceScan.Modules.MotionControl;
using LTDMC;
public class MotionControl:Base
{   
    public static int TotalAxis { get; set; } = 0;
    public static List<double>[]? AxisPositon;
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
        TracSample = false;
        TotalAxis = GetTotalAxis();
        AxisPositon = new List<double>[TotalAxis];
        LTDMC.__Internal.dmc_board_init();
        
    }
    
}

