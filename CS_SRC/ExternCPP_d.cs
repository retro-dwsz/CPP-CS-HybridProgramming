// NOT FULLY IMPLEMENTED YET!
using DYNAMIC_CS_CPP_HAV;
using System;

// using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
// using System.Runtime.Versioning;

namespace CS_ExternCPP_d;

public class DEBUG
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

    public static void GetStatusSystem()
    {
        Console.WriteLine($"Running on {GetOS()} on {GetCPU()} CPU");
    }
}

public class DynamicOS
{
    public static void Error()
    {
        Console.WriteLine("Not compatible system!");
    }

    public class CPP_WINDOWS
    {
        [DllImport("CPP_Main.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double CPP_Convert(double x);

        [DllImport("CPP_Main.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double CPP_Hav(double x, bool Printing);

        [DllImport("CPP_Main.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double CPP_HavDeg(double x, bool Printing);

        [DllImport("CPP_Main.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double CPP_RawUTF8Print(string text);

        [DllImport("CPP_Main.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double CPP_DHav(double dlat, double lon1, double lon2, double dlon);

        [DllImport("CPP_Main.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double CPP_Theta(double Hav, bool isRadian = false);

        [DllImport("CPP_Main.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double CPP_Distance(double Hav, bool isRadian = false);

        [DllImport("CPP_Main.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double CPP_DistanceT(double T);
    }

    public class CPP_WINDOWS_D
    {
        public class X64
        {
            [DllImport("CPP_Main_X64.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_Convert(double x);

            [DllImport("CPP_Main_X64.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_Hav(double x, bool Printing);

            [DllImport("CPP_Main_X64.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_HavDeg(double x, bool Printing);

            [DllImport("CPP_Main_X64.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_RawUTF8Print(string text);

            [DllImport("CPP_Main_X64.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_DHav(double dlat, double lon1, double lon2, double dlon);

            [DllImport("CPP_Main_X64.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_Theta(double Hav, bool isRadian = false);

            [DllImport("CPP_Main_X64.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_Distance(double Hav, bool isRadian = false);

            [DllImport("CPP_Main_X64.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_DistanceT(double T);
        }

        public class ARM64
        {
            [DllImport("CPP_Main_ARM64.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_Convert(double x);

            [DllImport("CPP_Main_ARM64.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_Hav(double x, bool Printing);

            [DllImport("CPP_Main_ARM64.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_HavDeg(double x, bool Printing);

            [DllImport("CPP_Main_ARM64.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_RawUTF8Print(string text);

            [DllImport("CPP_Main_ARM64.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_DHav(double dlat, double lon1, double lon2, double dlon);

            [DllImport("CPP_Main_ARM64.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_Theta(double Hav, bool isRadian = false);

            [DllImport("CPP_Main_ARM64.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_Distance(double Hav, bool isRadian = false);

            [DllImport("CPP_Main_ARM64.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_DistanceT(double T);
        }
    }


    public class CPP_LINUX
    {
        [DllImport("CPP_Main_LINUX.dll.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern double CPP_Convert(double x);

        [DllImport("CPP_Main_LINUX.dll.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern double CPP_Hav(double x, bool Printing);

        [DllImport("CPP_Main_LINUX.dll.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern double CPP_HavDeg(double x, bool Printing);

        [DllImport("CPP_Main_LINUX.dll.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern double CPP_RawUTF8Print(string text);

        [DllImport("CPP_Main_LINUX.dll.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern double CPP_DHav(double dlat, double lon1, double lon2, double dlon);

        [DllImport("CPP_Main_LINUX.dll.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern double CPP_Theta(double Hav, bool isRadian = false);

        [DllImport("CPP_Main_LINUX.dll.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern double CPP_Distance(double Hav, bool isRadian = false);

        [DllImport("CPP_Main_LINUX.dll.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern double CPP_DistanceT(double T);
    }

    public class CPP_LINUX_D
    {
        public class X64
        {
            [DllImport("CPP_Main_LINUX_X64.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_Convert(double x);

            [DllImport("CPP_Main_LINUX_X64.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_Hav(double x, bool Printing);

            [DllImport("CPP_Main_LINUX_X64.dll.so", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_HavDeg(double x, bool Printing);

            [DllImport("CPP_Main_LINUX_X64.dll.so", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_RawUTF8Print(string text);

            [DllImport("CPP_Main_LINUX_X64.dll.so", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_DHav(double dlat, double lon1, double lon2, double dlon);

            [DllImport("CPP_Main_LINUX_X64.dll.so", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_Theta(double Hav, bool isRadian = false);

            [DllImport("CPP_Main_LINUX_X64.dll.so", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_Distance(double Hav, bool isRadian = false);

            [DllImport("CPP_Main_LINUX_X64.dll.so", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_DistanceT(double T);
        }

        public class ARM64
        {
            [DllImport("CPP_Main_LINUX_ARM64.dll.so", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_Convert(double x);

            [DllImport("CPP_Main_LINUX_ARM64.dll.so", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_Hav(double x, bool Printing);

            [DllImport("CPP_Main_LINUX_ARM64.dll.so", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_HavDeg(double x, bool Printing);

            [DllImport("CPP_Main_LINUX_ARM64.dll.so", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_RawUTF8Print(string text);

            [DllImport("CPP_Main_LINUX_ARM64.dll.so", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_DHav(double dlat, double lon1, double lon2, double dlon);

            [DllImport("CPP_Main_LINUX_ARM64.dll.so", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_Theta(double Hav, bool isRadian = false);

            [DllImport("CPP_Main_LINUX_ARM64.dll.so", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_Distance(double Hav, bool isRadian = false);

            [DllImport("CPP_Main_LINUX_ARM64.dll.so", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_DistanceT(double T);
        }
    }
}

public class CPP
{
    public static double CPP_Convert(double x)
    {
        DEBUG.OS Platform = DEBUG.GetOS();
        DEBUG.CPU CPU = DEBUG.GetCPU();
        if (Platform == DEBUG.OS.Windows)
        {
            if (CPU == DEBUG.CPU.X64)
            {
                return DynamicOS.CPP_WINDOWS_D.X64.CPP_Convert(x);
            }
            else if (CPU == DEBUG.CPU.ARM64)
            {
                return DynamicOS.CPP_WINDOWS_D.ARM64.CPP_Convert(x);
            }
            else
            {
                return DynamicOS.CPP_WINDOWS.CPP_Convert(x);
            }
        }
        else if (Platform == DEBUG.OS.Linux)
        {
            if (CPU == DEBUG.CPU.X64)
            {
                return DynamicOS.CPP_LINUX_D.X64.CPP_Convert(x);
            }
            else if (CPU == DEBUG.CPU.ARM64)
            {
                return DynamicOS.CPP_LINUX_D.ARM64.CPP_Convert(x);
            }
            else
            {
                return DynamicOS.CPP_LINUX.CPP_Convert(x);
            }
        }
        else
        {
            DynamicOS.Error();
            return 0;
        }
    }

    public static double CPP_Hav(double x, bool Printing)
    {
        DEBUG.OS Platform = DEBUG.GetOS();
        DEBUG.CPU CPU = DEBUG.GetCPU();
        if (Platform == DEBUG.OS.Windows)
        {
            if (CPU == DEBUG.CPU.X64)
            {
                return DynamicOS.CPP_WINDOWS_D.X64.CPP_Hav(x, Printing);
            }
            else if (CPU == DEBUG.CPU.ARM64)
            {
                return DynamicOS.CPP_WINDOWS_D.ARM64.CPP_Hav(x, Printing);
            }
            else
            {
                return DynamicOS.CPP_WINDOWS.CPP_Hav(x, Printing);
            }
        }
        else if (Platform == DEBUG.OS.Linux)
        {
            if (CPU == DEBUG.CPU.X64)
            {
                return DynamicOS.CPP_LINUX_D.X64.CPP_Hav(x, Printing);
            }
            else if (CPU == DEBUG.CPU.ARM64)
            {
                return DynamicOS.CPP_LINUX_D.ARM64.CPP_Hav(x, Printing);
            }
            else
            {
                return DynamicOS.CPP_LINUX.CPP_Hav(x, Printing);
            }
        }
        else
        {
            DynamicOS.Error();
            return 0;
        }
    }

    public static double CPP_HavDeg(double x, bool Printing)
    {
        DEBUG.OS Platform = DEBUG.GetOS();
        DEBUG.CPU CPU = DEBUG.GetCPU();
        if (Platform == DEBUG.OS.Windows)
        {
            if (CPU == DEBUG.CPU.X64)
            {
                return DynamicOS.CPP_WINDOWS_D.X64.CPP_HavDeg(x, Printing);
            }
            else if (CPU == DEBUG.CPU.ARM64)
            {
                return DynamicOS.CPP_WINDOWS_D.ARM64.CPP_HavDeg(x, Printing);
            }
            else
            {
                return DynamicOS.CPP_WINDOWS.CPP_HavDeg(x, Printing);
            }
        }
        else if (Platform == DEBUG.OS.Linux)
        {
            if (CPU == DEBUG.CPU.X64)
            {
                return DynamicOS.CPP_LINUX_D.X64.CPP_HavDeg(x, Printing);
            }
            else if (CPU == DEBUG.CPU.ARM64)
            {
                return DynamicOS.CPP_LINUX_D.ARM64.CPP_HavDeg(x, Printing);
            }
            else
            {
                return DynamicOS.CPP_LINUX.CPP_HavDeg(x, Printing);
            }
        }
        else
        {
            DynamicOS.Error();
            return 0;
        }
    }

    public static double CPP_RawUTF8Print(string text)
    {
        DEBUG.OS Platform = DEBUG.GetOS();
        DEBUG.CPU CPU = DEBUG.GetCPU();
        if (Platform == DEBUG.OS.Windows)
        {
            if (CPU == DEBUG.CPU.X64)
            {
                return DynamicOS.CPP_WINDOWS_D.X64.CPP_RawUTF8Print(text);
            }
            else if (CPU == DEBUG.CPU.ARM64)
            {
                return DynamicOS.CPP_WINDOWS_D.ARM64.CPP_RawUTF8Print(text);
            }
            else
            {
                return DynamicOS.CPP_WINDOWS.CPP_RawUTF8Print(text);
            }
        }
        else if (Platform == DEBUG.OS.Linux)
        {
            if (CPU == DEBUG.CPU.X64)
            {
                return DynamicOS.CPP_LINUX_D.X64.CPP_RawUTF8Print(text);
            }
            else if (CPU == DEBUG.CPU.ARM64)
            {
                return DynamicOS.CPP_LINUX_D.ARM64.CPP_RawUTF8Print(text);
            }
            else
            {
                return DynamicOS.CPP_LINUX.CPP_RawUTF8Print(text);
            }
        }
        else
        {
            DynamicOS.Error();
            return 0;
        }
    }

    public static double CPP_DHav(double dlat, double lon1, double lon2, double dlon)
    {
        DEBUG.OS Platform = DEBUG.GetOS();
        DEBUG.CPU CPU = DEBUG.GetCPU();
        if (Platform == DEBUG.OS.Windows)
        {
            if (CPU == DEBUG.CPU.X64)
            {
                return DynamicOS.CPP_WINDOWS_D.X64.CPP_DHav(dlat, lon1, lon2, dlon);
            }
            else if (CPU == DEBUG.CPU.ARM64)
            {
                return DynamicOS.CPP_WINDOWS_D.ARM64.CPP_DHav(dlat, lon1, lon2, dlon);
            }
            else
            {
                return DynamicOS.CPP_WINDOWS.CPP_DHav(dlat, lon1, lon2, dlon);
            }
        }
        else if (Platform == DEBUG.OS.Linux)
        {
            if (CPU == DEBUG.CPU.X64)
            {
                return DynamicOS.CPP_LINUX_D.X64.CPP_DHav(dlat, lon1, lon2, dlon);
            }
            else if (CPU == DEBUG.CPU.ARM64)
            {
                return DynamicOS.CPP_LINUX_D.ARM64.CPP_DHav(dlat, lon1, lon2, dlon);
            }
            else
            {
                return DynamicOS.CPP_LINUX.CPP_DHav(dlat, lon1, lon2, dlon);
            }
        }
        else
        {
            DynamicOS.Error();
            return 0;
        }
    }

    public static double CPP_Theta(double Hav, bool isRadian = false)
    {
        DEBUG.OS Platform = DEBUG.GetOS();
        DEBUG.CPU CPU = DEBUG.GetCPU();
        if (Platform == DEBUG.OS.Windows)
        {
            if (CPU == DEBUG.CPU.X64)
            {
                return DynamicOS.CPP_WINDOWS_D.X64.CPP_Theta(Hav, isRadian);
            }
            else if (CPU == DEBUG.CPU.ARM64)
            {
                return DynamicOS.CPP_WINDOWS_D.ARM64.CPP_Theta(Hav, isRadian);
            }
            else
            {
                return DynamicOS.CPP_WINDOWS.CPP_Theta(Hav, isRadian);
            }
        }
        else if (Platform == DEBUG.OS.Linux)
        {
            if (CPU == DEBUG.CPU.X64)
            {
                return DynamicOS.CPP_LINUX_D.X64.CPP_Theta(Hav, isRadian);
            }
            else if (CPU == DEBUG.CPU.ARM64)
            {
                return DynamicOS.CPP_LINUX_D.ARM64.CPP_Theta(Hav, isRadian);
            }
            else
            {
                return DynamicOS.CPP_LINUX.CPP_Theta(Hav, isRadian);
            }
        }
        else
        {
            DynamicOS.Error();
            return 0;
        }
    }

    public static double CPP_Distance(double Hav, bool isRadian = false)
    {
        DEBUG.OS Platform = DEBUG.GetOS();
        DEBUG.CPU CPU = DEBUG.GetCPU();
        if (Platform == DEBUG.OS.Windows)
        {
            if (CPU == DEBUG.CPU.X64)
            {
                return DynamicOS.CPP_WINDOWS_D.X64.CPP_Distance(Hav, isRadian);
            }
            else if (CPU == DEBUG.CPU.ARM64)
            {
                return DynamicOS.CPP_WINDOWS_D.ARM64.CPP_Distance(Hav, isRadian);
            }
            else
            {
                return DynamicOS.CPP_WINDOWS.CPP_Distance(Hav, isRadian);
            }
        }
        else if (Platform == DEBUG.OS.Linux)
        {
            if (CPU == DEBUG.CPU.X64)
            {
                return DynamicOS.CPP_LINUX_D.X64.CPP_Distance(Hav, isRadian);
            }
            else if (CPU == DEBUG.CPU.ARM64)
            {
                return DynamicOS.CPP_LINUX_D.ARM64.CPP_Distance(Hav, isRadian);
            }
            else
            {
                return DynamicOS.CPP_LINUX.CPP_Distance(Hav, isRadian);
            }
        }
        else
        {
            DynamicOS.Error();
            return 0;
        }
    }

    public static double CPP_DistanceT(double T)
    {
        DEBUG.OS Platform = DEBUG.GetOS();
        DEBUG.CPU CPU = DEBUG.GetCPU();
        if (Platform == DEBUG.OS.Windows)
        {
            if (CPU == DEBUG.CPU.X64)
            {
                return DynamicOS.CPP_WINDOWS_D.X64.CPP_Convert(T);
            }
            else if (CPU == DEBUG.CPU.ARM64)
            {
                return DynamicOS.CPP_WINDOWS_D.ARM64.CPP_Convert(T);
            }
            else
            {
                return DynamicOS.CPP_WINDOWS.CPP_Convert(T);
            }
        }
        else if (Platform == DEBUG.OS.Linux)
        {
            if (CPU == DEBUG.CPU.X64)
            {
                return DynamicOS.CPP_LINUX_D.X64.CPP_Convert(T);
            }
            else if (CPU == DEBUG.CPU.ARM64)
            {
                return DynamicOS.CPP_LINUX_D.ARM64.CPP_Convert(T);
            }
            else
            {
                return DynamicOS.CPP_LINUX.CPP_Convert(T);
            }
        }
        else
        {
            DynamicOS.Error();
            return 0;
        }
    }
}
