namespace SurfaceScan.Modules.DataProcessing;

public record SignalParameters
{
    public static double Thick { get; } = 20; // 厚度 0
    public static double SoundSpeed { get; } = 1500; // 声速 1
    public static double Delay { get; } = 0; // 延迟 2
    public static double GateStart { get; } = 3; // 门控起始 3
    public static double GateLength { get; } = 17; // 门控长度 4
    public static double GateHeight { get; } = 15; // 门控高度 5

    public static double SightLength { get; } = CalculateSightLength(); // 视野长度 12
    public static double TriggerLength { get; private set; } = CalculateTriggerLength(); // 触发高度 13
    public static double TriggerDelay { get; private set; } = CalculateTriggerDelay(); // 触发延迟 14
    public static double GateStartPoint { get; private set; } = CalculateGateStartPoint(); // 触发起始 15
    public static double GateEndPoint { get; set; } = CalculateGateEndPoint(); // 触发结束 16
    
    internal const double ProbeLength = 9e4; // 探头长度 
    
    public const double ProbeFocus = 1.25e4; // 探头焦距

    private static double CalculateSightLength() => Thick / SoundSpeed * 4e5;
    private static double CalculateTriggerLength() => SightLength / 32 + 1;
    private static double CalculateTriggerDelay() => Delay * 2e2;
    private static double CalculateGateStartPoint() => GateStart / SoundSpeed * 4e5;
    private static double CalculateGateEndPoint() => (GateStart + GateLength) / SoundSpeed * 4e5;
    
    
}

public static class GlobalParameters
{
    // 静态的全局 SignalParameters 记录
    public static readonly SignalParameters Parameters = new SignalParameters();
}