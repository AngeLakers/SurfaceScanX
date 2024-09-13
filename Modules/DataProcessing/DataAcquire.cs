namespace SurfaceScan.Modules.DataProcessing;

public class DataAcquire
{
    static DataAcquire()
    {
        // 订阅 ReadRequest 事件
        PCI9850Control.ReadRequest += OnReadRequestHandler;
    }


    private static void OnReadRequestHandler(object sender, DataEventArgs args)
    {
        // 通过事件参数获取数据
        var data = args.Data;
        PCI9850Control._block = true;
        throw new NotImplementedException();
    }
}