namespace SurfaceScan.Modules.MotionControl;

internal record ControlParameters
{
    public const double MoveRadius = 10.25e4;
    public const ushort CardNo = 0;
    public const int MaxRetries = 10;
    public static double ProbeLength { get; } = 9e4;
    public static double ProbeFocus { get; } = 1.25e4;
};

public static partial class GlobalParameters
{
    // 静态的全局 SignalParameters 记录
    internal static readonly ControlParameters Parameters = new ControlParameters();
}