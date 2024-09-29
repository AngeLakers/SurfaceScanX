namespace SurfaceScan.Modules.MotionControl;

public record ControlParameters
{
  
    public const double MoveRadius = 10.25e4;
};


public static partial class GlobalParameters
{
    // 静态的全局 SignalParameters 记录
    public static readonly ControlParameters Parameters = new ControlParameters();
}