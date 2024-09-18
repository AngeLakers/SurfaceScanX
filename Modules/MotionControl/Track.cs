namespace SurfaceScan.Modules.MotionControl;

public class Track
{
    private const double CorrSurrSpeed = 2e3;
    private const double CorrAxalSpeed = 1e3;

    public void ProbeCorrection(double corrDeg, double corrLen)
    {
        Base.MotiHold = true;
        // 加入check下是否开启电机了
        // 先调整探头角度
        Position.SurroundMove((int)Resources.Properties.Direction.Forward, CorrSurrSpeed, corrDeg);

        while (!Base.CheckAxisStatus((int)Resources.Properties.Axis.A))
        {
            Position.GetPosition(MotionControl.AxisPositon);
            // 判断两个轴的位置差 是否大于1.2e5
            if ((MotionControl.AxisPositon[(int)Resources.Properties.Axis.A] -
                 MotionControl.AxisPositon[(int)Resources.Properties.Axis.B] / 2) > 1.2e5)
            {
                Axis.StopAllAxes();
                Base.TrackHold = false;
                return;
            }
            // 移动探头靠近表面
            Axis.StopAllAxes();
            Position.AxialMove((int)Resources.Properties.Direction.Reverse, CorrAxalSpeed, corrLen);
            while (!Base.CheckAxisStatus((int)Resources.Properties.Axis.X))
            {
                Axis.StopAllAxes();
                return;
            }
        }
        // 停止运动
        while (!Base.CheckAxisStatus((int)Resources.Properties.Axis.X))
        {
            Position.GetPosition(MotionControl.AxisPositon);
            if (Base.MotiHold) continue;
            Axis.StopAllAxes();
            return;
        }
    }
}