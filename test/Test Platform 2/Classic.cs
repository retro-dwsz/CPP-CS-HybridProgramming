using System;
using System.Runtime.InteropServices;

namespace CLASSIC_WINLINUX;

public class Machine
{
    public enum CPU
    {
        X86,        // X86
        X64,        // X86-64 or AMD64
        ARM,        // ARM32
        ARM64,      // ARM64
        LARM64,     // ARMv7 64-bit
        unknwon     // other
    }

    public enum OS
    {
        Win23,    // Win23
        Linux,      // Linux
        OSX,      // OSX MacOS
        unknwon
    }
}

class Debug
{
    public static Machine.CPU GetCPU()
    {
        Architecture arch = RuntimeInformation.ProcessArchitecture;
        switch (arch)
        {
            default: return Machine.CPU.unknwon;
            case Architecture.X64:
                return Machine.CPU.X64;
            case Architecture.Arm:
                return Machine.CPU.ARM;
            case Architecture.Arm64:
                return Machine.CPU.ARM64;
            case Architecture.LoongArch64:
                return Machine.CPU.LARM64;
        }
    }

    public static Machine.OS GetOS()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return Machine.OS.Win23;
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            return Machine.OS.Linux;
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            return Machine.OS.OSX;
        }
        else
        {
            return Machine.OS.unknwon;
        }
    }

    public static string GetFile()
    {
        Machine.CPU CPU = GetCPU();
        Machine.OS OS = GetOS();
        switch (OS)
        {
            case Machine.OS.Win23:
                switch (CPU)
                {
                    case Machine.CPU.X86: return "Extern_Win32.x86.dll";
                    case Machine.CPU.X64: return "Extern_Win32.x64.dll";
                    case Machine.CPU.LARM64: return "Extern_Win32.LARM64.dll";
                    default: return "Unsupported CPU";
                }
            case Machine.OS.Linux:
                switch (CPU)
                {
                    case Machine.CPU.X86: return "Extern_LINUX.x86.so";
                    case Machine.CPU.X64: return "Extern_LINUX.x64.so";
                    case Machine.CPU.LARM64: return "Extern_LINUX.LARM64.so";
                    default: return "Unsupported CPU";
                }
            case Machine.OS.OSX:
                switch (CPU)
                {
                    case Machine.CPU.X86: return "Extern_OSX.x86.dll";
                    case Machine.CPU.X64: return "Extern_OSX.x64.dll";
                    case Machine.CPU.LARM64: return "Extern_OSX.LARM64.dll";
                    default: return "Unsupported CPU";
                }
            default: return "unknown";
        }
    }

    public static void GetStatusSystem()
    {
        Console.WriteLine($"Running on {GetOS()} on {GetCPU()} CPU");
    }
}

public class Testing
{
    // string FILE = Debug.GetFile();      // nuh uh
    const string FILE = "Extern_WIN.x64";   // OK
    
    [DllImport(FILE, CallingConvention = CallingConvention.Cdecl)]
    public static extern void __TEST__();

    [DllImport(FILE, CallingConvention = CallingConvention.Cdecl)]
    public static extern double convert(double x);

    [DllImport(FILE, CallingConvention = CallingConvention.Cdecl)]
    public static extern double Hav_rad(double x);

    [DllImport(FILE, CallingConvention = CallingConvention.Cdecl)]
    public static extern double Hav_deg(double x);

    [DllImport(FILE, CallingConvention = CallingConvention.Cdecl)]
    public static extern double Distance_Rad(double latA, double lonA, double latB, double lonB);

    [DllImport(FILE, CallingConvention = CallingConvention.Cdecl)]
    public static extern double Distance_Deg(double latA, double lonA, double latB, double lonB);
}

class ProgramClassic
{
    public static void OutputBuffer()
    {
        ConsoleColor nowFore = Console.ForegroundColor;
        ConsoleColor nowBack = Console.BackgroundColor;

        // Console.ForegroundColor =
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write($"Output  \t ");

        Console.BackgroundColor = nowBack;
        Console.ForegroundColor = nowFore;
    }

    public static void FunctionName(string name)
    {
        ConsoleColor nowFore = Console.ForegroundColor;
        ConsoleColor nowBack = Console.BackgroundColor;

        // Console.ForegroundColor =
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write($"Function\t ");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine($"{name}");

        Console.BackgroundColor = nowBack;
        Console.ForegroundColor = nowFore;
    }

    public static void Main_t()
    {
        Debug.GetStatusSystem();
        // Extern.Linux.x64.__TEST__();

        Console.Write("\n");
        FunctionName("__TEST__()");
        OutputBuffer();
        Testing.__TEST__();

        Console.Write("\n");
        FunctionName("convert()");
        OutputBuffer();
        Console.WriteLine("\t", Testing.convert(Math.PI));

        Console.Write("\n");
        FunctionName($"Hav_rad(1.8641198515 - 1.86273266385) = Hav_rad({1.8641198515 - 1.86273266385})");
        OutputBuffer();
        Console.WriteLine("\t", Testing.Hav_rad(1.8641198515 - 1.86273266385));

        Console.Write("\n");
        FunctionName($"Hav_deg(1.8641198515 - 1.86273266385) = Hav_deg({1.8641198515 - 1.86273266385})");
        OutputBuffer();
        Console.WriteLine("\t", Testing.Hav_deg(106.806200 - 106.726720));

        Console.Write("\n");
        FunctionName($"Distance_Rad() -> Distance_Rad( -0.11499026728, 1.8641198515, -0.1144863034543, 1.86273266385 )");
        OutputBuffer();
        Console.WriteLine("\t", Testing.Distance_Rad(-0.11499026728, 1.8641198515, -0.1144863034543, 1.86273266385));

        Console.Write("\n");
        FunctionName($"Distance_Deg() -> Distance_Deg( -6.588457, 106.806200, -6.559582, 106.726720);");
        OutputBuffer();
        Console.WriteLine("\t", Testing.Distance_Deg(-6.588457, 106.806200, -6.559582, 106.726720));
        // try
        // {
        // }
        // catch (Exception e)
        // {
        //     Console.WriteLine($"\n\nCRASH !!\nInvalid file! Required: {Debug.GetOS()} on {Debug.GetCPU()}");
        //     throw new Exception($"{e.Message}");
        // }
    }
}