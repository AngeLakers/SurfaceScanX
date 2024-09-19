using System.Configuration;
using System.Data;
using System.Diagnostics;
using SurfaceScan.Modules.Log;
using SurfaceScan.Modules.States;

namespace SurfaceScan.Modules.DataProcessing;

using PCI9850;
using SignalParameters = SurfaceScan.Modules.DataProcessing.SignalParameters;

public class PCI9850Control
{
    public static IntPtr _hdl;

    public static bool GrabHold { get; set; }

    // 用于同步请求的标志
    public static bool Block { get; set; }

    private static List<byte> _data = new List<byte>(); // 存储抓取的数据
    static byte[] _buf = null; // 延迟初始化缓冲区 使用 byte[] 来替代 unsigned char*

    public delegate void ReadRequestEventHandler(object sender, DataEventArgs args);
    public static bool _isRunning { get; set; }

    // 定义事件
    public static event ReadRequestEventHandler? ReadRequest;
    public StateMachine PCI9850StateMachine { get; private set; }


    PCI9850Control(StateManager stateManager)
    {
        PCI9850StateMachine = new StateMachine();
        stateManager.RegisterStateMachine("PCI9850", PCI9850StateMachine);
        PCI9850StateMachine.SetState(new PCI9850InitState(PCI9850StateMachine));
    }

    internal static void PCI9850Init()
    {
        try
        {
            var parameter = new _PCI9850_PARA_INIT.__Internal
            {
                lADFmt = (int)EmADFormat.ADFMT_STBIN,
                TriggerMode = (int)EmTriggerMode.TRIG_MODE_DELAY,
                TriggerSource = (int)EmTriggerSource.TRIG_SRC_EXT_RISING,
                TriggerLength = (int)DataProcessing.SignalParameters.TriggerLength,
                TriggerDelay = (int)DataProcessing.SignalParameters.TriggerDelay
            };

            int pci9850InitAd = PCI9850.PCI9850_initAD(_hdl, _PCI9850_PARA_INIT.__CreateInstance(parameter));
            LogManager.Info(pci9850InitAd == 1 ? "PCI9850 init success" : "PCI9850 init failed");
        }
        catch (Exception e)
        {
            LogManager.Error("PCI9850 initialization failed: " + e.Message);
            throw;
        }
    }

    public static unsafe void GrabSignal()
    {
        try
        {
            while (_isRunning)
            {
                // 1. 获取缓冲区大小
                int bufcnt = 0;

                // 等待缓冲区大小达到要求
                while (bufcnt < DataProcessing.SignalParameters.TriggerLength * 32)
                {
                    bufcnt = PCI9850.PCI9850_GetBufCnt(_hdl); // 获取缓冲区大小
                    if (!GrabHold) return; // 如果退出抓取，直接返回
                }

                // 2. 读取数据
                uint over = 0;
                if (_buf == null || _buf.Length != bufcnt)
                {
                    _buf = new byte[bufcnt]; // 仅当  缓冲区大小变化时重新分配内存
                }

                // 使用非托管指针读取数据
                fixed (byte* pBuf = _buf)
                {
                    PCI9850.PCI9850_ReadAD(_hdl, pBuf, (uint)bufcnt, ref over); // 读取数据
                }

                // 3. 处理数据
                ProcessSignalData(_buf);

                _buf = null; // 释放缓冲区
                // 5. 输出数据大小
                LogManager.Info($"Data size: {_data.Count}");
            }
        }
        catch (Exception e)
        {
            LogManager.Error("Grab signal failed: " + e.Message);
            throw new DataException();
        }
    }

    // 处理数据填充与 block 控制
    private static void ProcessSignalData(byte[] buf)
    {
        _data.Clear();
        for (int i = 0; i < DataProcessing.SignalParameters.SightLength; i++)
        {
            _data.Add(buf[i]);
        }
      
        // 通知数据处理完成
        // 在这里可以发出读取请求或其他信号处理
        // ReadRequest();
        // 触发事件通知 read_request 相关逻辑
        OnReadRequest(new DataEventArgs(_data));
    }

    private static void OnReadRequest(DataEventArgs e)
    {
        ReadRequest?.Invoke(null, e);
    }
}

public class DataEventArgs(List<byte> data) : EventArgs
{
    public List<byte> Data { get; set; } = data;
}

public partial class PCI9850InitState
{
    public void Enter()
    {
        // 从配置文件中获取参数,设置参数
        // 调用 PCI9850_Link 函数，连接第 0 个设备
        PCI9850Control._hdl = PCI9850.PCI9850_Link(0);

        // 检查是否连接成功
        // 连接成功，执行其他操作
        // 如果连接失败，输出调试信息
        LogManager.Info(PCI9850Control._hdl == IntPtr.Zero
            ? "Cannot find signal card"
            : "Signal card connected successfully");
        PCI9850Control.PCI9850Init();
    
    }
}