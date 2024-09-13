using System.Configuration;
using System.Diagnostics;

namespace SurfaceScan.Modules.DataProcessing;

using PCI9850;
using SignalParameters = SurfaceScan.Modules.DataProcessing.SignalParameters;

public static class PCI9850Control
{
    private static IntPtr _hdl;
    public static bool GrabHold { get; set; }
    // 用于同步请求的标志

    public static bool _block { get; set; }

    private static List<byte> _data = new List<byte>(); // 存储抓取的数据
    static byte[] _buf = null; // 延迟初始化缓冲区 使用 byte[] 来替代 unsigned char*

    private static ManualResetEvent _blockEvent = new ManualResetEvent(false); // 初始化同步事件

    public delegate void ReadRequestEventHandler(object sender, DataEventArgs args);

// 定义事件
    public static event ReadRequestEventHandler ReadRequest;

    static PCI9850Control()
    {
        // 从配置文件中获取参数,设置参数
        // 调用 PCI9850_Link 函数，连接第 0 个设备
        _hdl = PCI9850.PCI9850_Link(0);

        // 检查是否连接成功
        // 连接成功，执行其他操作
        // 如果连接失败，输出调试信息
        Debug.WriteLine(_hdl == IntPtr.Zero ? "Cannot find signal card" : "Signal card connected successfully");
    }

    public static void PCI9850Init()
    {
        var parameter = new _PCI9850_PARA_INIT.__Internal
        {
            lADFmt = (int)EmADFormat.ADFMT_STBIN,
            TriggerMode = (int)EmTriggerMode.TRIG_MODE_DELAY,
            TriggerSource = (int)EmTriggerSource.TRIG_SRC_EXT_RISING,
            TriggerLength = (int)DataProcessing.SignalParameters.TriggerLength,
            TriggerDelay = (int)DataProcessing.SignalParameters.TriggerDelay
        };
        // 判断是否初始化成功
        // 初始化成功，执行其他操作
        // 如果初始化失败，输出调试信息 1为 true 0为 false

        int initresult = PCI9850.PCI9850_initAD(_hdl, _PCI9850_PARA_INIT.__CreateInstance(parameter));
        Debug.WriteLine(initresult == 1 ? "PCI9850 init success" : "PCI9850 init failed");
    }

    public static unsafe void GrabSignal()
    {
        GrabHold = true;

        while (GrabHold)
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
                _buf = new byte[bufcnt]; // 仅当缓冲区大小变化时重新分配内存
            }

            // 使用非托管指针读取数据
            fixed (byte* pBuf = _buf)
            {
                PCI9850.PCI9850_ReadAD(_hdl, pBuf, (uint)bufcnt, ref over); // 读取数据
            }

            // 3. 处理数据
            ProcessSignalData(_buf);

            // 4. 等待数据处理完成
            _block = true;
            _blockEvent.Reset(); // 重置事件
            while (_block)
            {
                if (!GrabHold) return;
                _blockEvent.WaitOne(1); // 使用同步事件避免忙等待
            }

            // 5. 输出数据大小
            Console.WriteLine($"Data size: {_data.Count}");
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

        _block = false; // 数据处理完成，解除 block 状态
        // 在这里可以发出读取请求或其他信号处理
        // ReadRequest();
        // 触发事件通知 read_request 相关逻辑
        OnReadRequest(new DataEventArgs(_data));

        _blockEvent.Set(); // 通知等待数据处理的线程继续执行
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