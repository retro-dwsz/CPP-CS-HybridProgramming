// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Drawing;

public class Debug
{
    public enum OS
    {
        Unknown,
        Windows,
        Linux,
        Apple
    }
    public enum CPU
    {
        X86,
        X64,
        ARM,
        ARM64,
        Unknown
    }

    public static CPU GetCPU()
    {
        Architecture arch = RuntimeInformation.ProcessArchitecture;
        switch (arch)
        {
            default: return CPU.Unknown;
            case Architecture.X86:
                return CPU.X86;
            case Architecture.X64:
                return CPU.X64;
            case Architecture.Arm:
                return CPU.ARM;
            case Architecture.Arm64:
                return CPU.ARM64;
        }
    }
    public static OS GetOS()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            // Console.WriteLine($"{RuntimeInformation.OSDescription}");
            return OS.Windows;
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            return OS.Linux;
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            return OS.Apple;
        }
        else
        {
            return OS.Unknown;
        }
    }

    public static string GetOS_S()
    {
        OS OS = GetOS();
        switch (OS)
        {
            case OS.Windows: return "Windows";
            case OS.Linux: return "Linux";
            case OS.Apple: return "Apple";
            default: return "unknwon";
        }
    }

    public static string GetCPU_S()
    {
        CPU CPU = GetCPU();
        switch (CPU)
        {
            case CPU.X86: return "X86";
            case CPU.X64: return "X64";
            case CPU.ARM: return "ARM";
            case CPU.ARM64: return "ARM64";
            case CPU.Unknown: return "unkown";
            default: return "unknown";
        }
    }

    public static void GetStatusSystem()
    {
        /* BUG:
        
        build/run:  Running on Windows on X64 CPU
        publish:    Running on 1 on 1 CPU   (fixed on Windows, still bug on Linux)
        
        */
        string OS = GetOS_S();
        string CPU = GetCPU_S();
        Console.WriteLine($"Running on {OS} on {CPU} CPU");
    }
}

public class Extern
{
    // Linux stuffs
    public class Linux
    {
        public class x64
        {
            [DllImport("./Extern_LINUX.x64.so", CallingConvention = CallingConvention.Cdecl)]
            public static extern void __TEST__();

            [DllImport("./Extern_LINUX.x64.so", CallingConvention = CallingConvention.Cdecl)]
            public static extern double convert(double x);

            [DllImport("./Extern_LINUX.x64.so", CallingConvention = CallingConvention.Cdecl)]
            public static extern double Hav_rad(double x);

            [DllImport("./Extern_LINUX.x64.so", CallingConvention = CallingConvention.Cdecl)]
            public static extern double Hav_deg(double x);

            [DllImport("./Extern_LINUX.x64.so", CallingConvention = CallingConvention.Cdecl)]
            public static extern double Distance_Rad(double latA, double lonA, double latB, double lonB);

            [DllImport("./Extern_LINUX.x64.so", CallingConvention = CallingConvention.Cdecl)]
            public static extern double Distance_Deg(double latA, double lonA, double latB, double lonB);
        }
        public class x86
        {
            [DllImport("./Extern_LINUX.x86.so", CallingConvention = CallingConvention.Cdecl)]
            public static extern void __TEST__();

            [DllImport("./Extern_LINUX.x86.so", CallingConvention = CallingConvention.Cdecl)]
            public static extern double convert(double x);

            [DllImport("./Extern_LINUX.x86.so", CallingConvention = CallingConvention.Cdecl)]
            public static extern double Hav_rad(double x);

            [DllImport("./Extern_LINUX.x86.so", CallingConvention = CallingConvention.Cdecl)]
            public static extern double Hav_deg(double x);

            [DllImport("./Extern_LINUX.x86.so", CallingConvention = CallingConvention.Cdecl)]
            public static extern double Distance_Rad(double latA, double lonA, double latB, double lonB);

            [DllImport("./Extern_LINUX.x86.so", CallingConvention = CallingConvention.Cdecl)]
            public static extern double Distance_Deg(double latA, double lonA, double latB, double lonB);
        }
    }

    // Windows stuffs
    public class WIN
    {
        public class x64
        {
            [DllImport("Extern_WIN.x64.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void __TEST__();

            [DllImport("Extern_WIN.x64.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double convert(double x);

            [DllImport("Extern_WIN.x64.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double Hav_rad(double x);

            [DllImport("Extern_WIN.x64.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double Hav_deg(double x);

            [DllImport("Extern_WIN.x64.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double Distance_Rad(double latA, double lonA, double latB, double lonB);

            [DllImport("Extern_WIN.x64.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double Distance_Deg(double latA, double lonA, double latB, double lonB);
        }
        public class x86
        {
            [DllImport("Extern_WIN.x86.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void __TEST__();

            [DllImport("Extern_WIN.x86.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double convert(double x);

            [DllImport("Extern_WIN.x86.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double Hav_rad(double x);

            [DllImport("Extern_WIN.x86.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double Hav_deg(double x);

            [DllImport("Extern_WIN.x86.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double Distance_Rad(double latA, double lonA, double latB, double lonB);

            [DllImport("Extern_WIN.x86.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double Distance_Deg(double latA, double lonA, double latB, double lonB);
        }
    }
}

public class Testing
{
    public static void __TEST__()
    {
        Debug.OS OS = Debug.GetOS();
        Debug.CPU CPU = Debug.GetCPU();

        switch (OS)
        {
            case Debug.OS.Windows:
                switch (CPU)
                {
                    /* Windows 64-bit */
                    case Debug.CPU.X64:
                        Extern.WIN.x64.__TEST__();
                        break;

                    /* Windows 32-bit */
                    case Debug.CPU.X86:
                        Extern.WIN.x86.__TEST__();
                        break;
                    default:
                        Console.WriteLine("Unsupported OS!");
                        break;
                }
                break;
            case Debug.OS.Linux:
                switch (CPU)
                {
                    /* Linux 64-bit */
                    case Debug.CPU.X64:
                        Extern.Linux.x64.__TEST__();
                        break;

                    /* Linux 32-bit */
                    case Debug.CPU.X86:
                        Extern.Linux.x64.__TEST__();
                        break;
                    default:
                        Console.WriteLine("Unsupported OS!");
                        break;
                }
                break;
            default:
                Console.WriteLine("Unsopprted CPU!");
                break;
        }
    }

    public static void convert(double x)
    {
        Debug.OS OS = Debug.GetOS();
        Debug.CPU CPU = Debug.GetCPU();

        if (OS == Debug.OS.Windows)
        {
            switch (CPU)
            {
                case Debug.CPU.X64:
                    Console.WriteLine($"x = {x} -> " + Extern.WIN.x64.convert(x));
                    break;
                case Debug.CPU.X86:
                    Console.WriteLine($"x = {x} -> " + Extern.WIN.x86.convert(x));
                    break;
                default:
                    Console.WriteLine("Unsopprted CPU!");
                    break;
            }
        }
        else if (OS == Debug.OS.Linux)
        {
            switch (CPU)
            {
                case Debug.CPU.X64:
                    Console.WriteLine($"x = {x} -> " + Extern.Linux.x64.convert(x));
                    break;
                case Debug.CPU.X86:
                    Console.WriteLine($"x = {x} -> " + Extern.Linux.x86.convert(x));
                    break;
                default:
                    Console.WriteLine("Unsopprted CPU!");
                    break;
            }
        }
    }

    public static void Hav_rad(double x)
    {
        Debug.OS OS = Debug.GetOS();
        Debug.CPU CPU = Debug.GetCPU();

        switch (OS)
        {
            case Debug.OS.Windows:
                switch (CPU)
                {
                    case Debug.CPU.X64:
                        Console.WriteLine($"{Extern.WIN.x64.Hav_rad(x)}");
                        break;

                    case Debug.CPU.X86:
                        Console.WriteLine($"{Extern.WIN.x86.Hav_rad(x)}");
                        break;

                    default:
                        Console.WriteLine("Unsupported CPU!");
                        break;
                }
                break;

            case Debug.OS.Linux:
                switch (CPU)
                {
                    case Debug.CPU.X64:
                        Console.WriteLine($"{Extern.Linux.x64.Hav_rad(x)}");
                        break;

                    case Debug.CPU.X86:
                        Console.WriteLine($"{Extern.Linux.x86.Hav_rad(x)}");
                        break;

                    default:
                        Console.WriteLine("Unsupported CPU!");
                        break;
                }
                break;

            default:
                Console.WriteLine("Unsopprted OS!");
                break;
        }
    }

    public static void Hav_deg(double x)
    {
        Debug.OS OS = Debug.GetOS();
        Debug.CPU CPU = Debug.GetCPU();

        switch (OS)
        {
            case Debug.OS.Windows:
                switch (CPU)
                {
                    case Debug.CPU.X64:
                        Console.WriteLine($"{Extern.WIN.x64.Hav_deg(x)}");
                        break;

                    case Debug.CPU.X86:
                        Console.WriteLine($"{Extern.WIN.x86.Hav_deg(x)}");
                        break;

                    default:
                        Console.WriteLine("Unsupported CPU!");
                        break;
                }
                break;

            case Debug.OS.Linux:
                switch (CPU)
                {
                    case Debug.CPU.X64:
                        Console.WriteLine($"{Extern.Linux.x64.Hav_deg(x)}");
                        break;

                    case Debug.CPU.X86:
                        Console.WriteLine($"{Extern.Linux.x86.Hav_deg(x)}");
                        break;

                    default:
                        Console.WriteLine("Unsupported CPU!");
                        break;
                }
                break;

            default:
                Console.WriteLine("Unsopprted OS!");
                break;
        }
    }

    public static void Distance_Rad(double latA, double lonA, double latB, double lonB)
    {
        Debug.OS OS = Debug.GetOS();
        Debug.CPU CPU = Debug.GetCPU();

        switch (OS)
        {
            case Debug.OS.Windows:
                switch (CPU)
                {
                    case Debug.CPU.X64:
                        Console.WriteLine($"{Extern.WIN.x64.Distance_Rad(latA, lonA, latB, lonB)}");
                        break;

                    case Debug.CPU.X86:
                        Console.WriteLine($"{Extern.WIN.x86.Distance_Rad(latA, lonA, latB, lonB)}");
                        break;

                    default:
                        Console.WriteLine("Unsupported CPU!");
                        break;
                }
                break;

            case Debug.OS.Linux:
                switch (CPU)
                {
                    case Debug.CPU.X64:
                        Console.WriteLine($"{Extern.Linux.x64.Distance_Rad(latA, lonA, latB, lonB)}");
                        break;

                    case Debug.CPU.X86:
                        Console.WriteLine($"{Extern.Linux.x86.Distance_Rad(latA, lonA, latB, lonB)}");
                        break;

                    default:
                        Console.WriteLine("Unsupported CPU!");
                        break;
                }
                break;

            default:
                Console.WriteLine("Unsopprted OS!");
                break;
        }
    }

    public static void Distance_Deg(double latA, double lonA, double latB, double lonB)
    {
        Debug.OS OS = Debug.GetOS();
        Debug.CPU CPU = Debug.GetCPU();

        switch (OS)
        {
            case Debug.OS.Windows:
                switch (CPU)
                {
                    case Debug.CPU.X64:
                        Console.WriteLine($"{Extern.WIN.x64.Distance_Deg(latA, lonA, latB, lonB)}");
                        break;

                    case Debug.CPU.X86:
                        Console.WriteLine($"{Extern.WIN.x86.Distance_Deg(latA, lonA, latB, lonB)}");
                        break;

                    default:
                        Console.WriteLine("Unsupported CPU!");
                        break;
                }
                break;

            case Debug.OS.Linux:
                switch (CPU)
                {
                    case Debug.CPU.X64:
                        Console.WriteLine($"{Extern.Linux.x64.Distance_Deg(latA, lonA, latB, lonB)}");
                        break;

                    case Debug.CPU.X86:
                        Console.WriteLine($"{Extern.Linux.x86.Distance_Deg(latA, lonA, latB, lonB)}");
                        break;

                    default:
                        Console.WriteLine("Unsupported CPU!");
                        break;
                }
                break;

            default:
                Console.WriteLine("Unsopprted OS!");
                break;
        }

    }
}

class Program
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

    public static void Main()
    {
        Debug.GetStatusSystem();
        // Extern.Linux.x64.__TEST__();

        try
        {
            Console.Write("\n");
            FunctionName("__TEST__()");
            OutputBuffer();
            Testing.__TEST__();

            Console.Write("\n");
            FunctionName("convert()");
            OutputBuffer();
            Testing.convert(Math.PI);

            Console.Write("\n");
            FunctionName($"Hav_rad(1.8641198515 - 1.86273266385) = Hav_rad({1.8641198515 - 1.86273266385})");
            OutputBuffer();
            Testing.Hav_rad(1.8641198515 - 1.86273266385);

            Console.Write("\n");
            FunctionName($"Hav_deg(1.8641198515 - 1.86273266385) = Hav_deg({1.8641198515 - 1.86273266385})");
            OutputBuffer();
            Testing.Hav_deg(106.806200 - 106.726720);

            Console.Write("\n");
            FunctionName($"Distance_Rad() -> Distance_Rad( -0.11499026728, 1.8641198515, -0.1144863034543, 1.86273266385 )");
            OutputBuffer();
            Testing.Distance_Rad(-0.11499026728, 1.8641198515, -0.1144863034543, 1.86273266385);

            Console.Write("\n");
            FunctionName($"Distance_Deg() -> Distance_Deg( -6.588457, 106.806200, -6.559582, 106.726720);");
            OutputBuffer();
            Testing.Distance_Deg(-6.588457, 106.806200, -6.559582, 106.726720);
        }
        catch (Exception e)
        {
            Console.WriteLine($"\n\nCRASH !!\nInvalid file! Required: {Debug.GetOS()} on {Debug.GetCPU()}");
            throw new Exception($"{e}");
        }
    }
}