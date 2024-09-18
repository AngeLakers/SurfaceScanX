using System.Collections.Concurrent;
using SurfaceScan.Resources.Properties;

namespace SurfaceScan.Modules.Log;

using System;
using System.Collections.Generic;
using System.IO;

public static class LogManager
{
    public static object LockObj { get; } = new object();
    private static readonly ConcurrentQueue<string> LogBuffer = new ConcurrentQueue<string>(); // 日志缓冲区

    private static string LogFilePath { get; set; } = "log.txt";
    private static int MaxBufferSize { get; } = 100;
    private static readonly TimeSpan MaxBufferTime = TimeSpan.FromSeconds(10); // 最大缓冲时间
    private static DateTime LastWriteTime { get; set; } = DateTime.Now;
    public static long MaxFileSize { get; } = 10 * 1024 * 1024; // 最大文件大小 10MB


    // 静态构造函数：在程序生命周期结束时写入日志
    static LogManager()
    {
        // 注册在程序结束时执行的方法
        AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
        AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
        {
            Console.WriteLine("Unhandled exception occurred. Writing logs...");
            WriteLogsToFile();
        };
    }

    // 设置日志文件路径
    public static void SetLogFilePath(string path)
    {
        LogFilePath = path;
    }

    // 记录日志的公共方法，将日志存储在内存中
    public static void Log(LogLevel level, string message)
    {
        string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";
        LogBuffer.Enqueue(logMessage); // 将日志消息缓存在内存中
        Console.WriteLine(logMessage); // 输出到控制台
        WriteLogsToFileIfNeeded(); // 检查是否需要写入文件
    }

    // 记录信息日志
    public static void Info(string message)
    {
        Log(LogLevel.Info, message);
    }

    // 记录调试日志
    public static void Debug(string message)
    {
        Log(LogLevel.Debug, message);
    }

    // 记录错误日志
    public static void Error(string message)
    {
        Log(LogLevel.Error, message);
    }

    // 在程序结束时，统一写入日志文件
    private static void OnProcessExit(object sender, EventArgs e)
    {
        WriteLogsToFile();
    }


    private static void WriteLogsToFileIfNeeded()
    {
        // 如果日志条目超过最大缓冲区，或者超过了最大缓冲时间，写入文件
        if (LogBuffer.Count >= MaxBufferSize || (DateTime.Now - LastWriteTime) >= MaxBufferTime)
        {
            WriteLogsToFile();
            LastWriteTime = DateTime.Now;
        }
    }

    private static async Task WriteLogsToFileAsync()
    {
        try
        {
            await File.AppendAllLinesAsync(LogFilePath, LogBuffer);
            LogBuffer.Clear(); // 清空缓冲区
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to write logs to file: {ex.Message}");
        }
    }
    public static async Task LogAsync(LogLevel level, string message)
    {
        string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";
        LogBuffer.Enqueue(logMessage); // 将日志消息缓存在内存中
        Console.WriteLine(logMessage); // 输出到控制台

        await WriteLogsToFileIfNeededAsync(); // 检查是否需要写入文件
    }

    private static async Task WriteLogsToFileIfNeededAsync()
    {
        if (LogBuffer.Count >= MaxBufferSize || (DateTime.Now - LastWriteTime) >= MaxBufferTime)
        {
            await WriteLogsToFileAsync();
            LastWriteTime = DateTime.Now;
        }
    }

    private static void RotateLogFileIfNeeded()
    {
        var fileInfo = new FileInfo(LogFilePath);
        if (!fileInfo.Exists || fileInfo.Length <= MaxFileSize) return;
        var newFileName = $"{Path.GetFileNameWithoutExtension(LogFilePath)}_{DateTime.Now:yyyyMMddHHmmss}.log";
        var newFilePath = Path.Combine(fileInfo.DirectoryName!, newFileName);
        File.Move(LogFilePath, newFilePath); // 重命名旧文件
        Console.WriteLine($"Log file rotated: {newFilePath}");
    }


    // 将缓冲的日志批量写入文件
    private static void WriteLogsToFile()
    {
        RotateLogFileIfNeeded();
        lock (LockObj)
        {
            try
            {
                var logList = new List<string>();
                while (LogBuffer.TryDequeue(out var log))
                {
                    logList.Add(log);
                }

                if (logList.Count > 0)
                {
                    File.AppendAllLines(LogFilePath, logList); // 批量写入日志
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write logs to file: {ex.Message}");
            }
        }
    }
}