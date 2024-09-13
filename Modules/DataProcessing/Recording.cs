namespace SurfaceScan.Modules.DataProcessing;

public record SignalParameters
{
    public static double Thick { get; } = 20; // 厚度 0
    public static double SoundSpeed { get; } = 1500; // 声速 1
    public static double Delay { get; } = 0; // 延迟 2
    public static double GateStart { get; } = 3; // 门控起始 3
    public static double GateLength { get; } = 17; // 门控长度 4
    public static double GateHeight { get; } = 15; // 门控高度 5

    public static double SightLength { get; } = Thick / SoundSpeed * 4e5; // 视野长度 12
    public static double TriggerLength { get; } = SightLength / 32 + 1; // 触发高度 13
    public static double TriggerDelay { get; } = Delay * 2e2; // 触发延迟 14
    public static double GateStartPoint { get; } = GateStart / SoundSpeed * 4e5; // 触发起始 15
    public static double GateEndPoint { get; } = (GateStart + GateLength) / SoundSpeed * 4e5; // 触发结束 16
}

public static class GlobalParameters
{
    // 静态的全局 SignalParameters 记录
    public static readonly SignalParameters Parameters = new SignalParameters();
}