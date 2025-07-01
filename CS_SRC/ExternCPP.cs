using DYNAMIC_CS_CPP_HAV;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace CS_ExternCPP;

// NOT FULLY IMPLEMENTED YET!
public class DynamicOS
{
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

        public class X86
        {
            [DllImport("CPP_Main_X86.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_Convert(double x);

            [DllImport("CPP_Main_X86.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_Hav(double x, bool Printing);

            [DllImport("CPP_Main_X86.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_HavDeg(double x, bool Printing);

            [DllImport("CPP_Main_X86.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_RawUTF8Print(string text);

            [DllImport("CPP_Main_X86.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_DHav(double dlat, double lon1, double lon2, double dlon);

            [DllImport("CPP_Main_X86.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_Theta(double Hav, bool isRadian = false);

            [DllImport("CPP_Main_X86.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_Distance(double Hav, bool isRadian = false);

            [DllImport("CPP_Main_X86.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_DistanceT(double T);
        }

        public class ARM
        {

        }

        public class ARM64
        {

        }

        public class ARMv6
        {

        }

        public class RISCV
        {

        }

    }


    public class CPP_LINUX
    {
        [DllImport("CPP_Main_LINUX.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double CPP_Convert(double x);

        [DllImport("CPP_Main_LINUX.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double CPP_Hav(double x, bool Printing);

        [DllImport("CPP_Main_LINUX.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double CPP_HavDeg(double x, bool Printing);

        [DllImport("CPP_Main_LINUX.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double CPP_RawUTF8Print(string text);

        [DllImport("CPP_Main_LINUX.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double CPP_DHav(double dlat, double lon1, double lon2, double dlon);

        [DllImport("CPP_Main_LINUX.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double CPP_Theta(double Hav, bool isRadian = false);

        [DllImport("CPP_Main_LINUX.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double CPP_Distance(double Hav, bool isRadian = false);

        [DllImport("CPP_Main_LINUX.dll", CallingConvention = CallingConvention.Cdecl)]
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

            [DllImport("CPP_Main_LINUX_X64.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_HavDeg(double x, bool Printing);

            [DllImport("CPP_Main_LINUX_X64.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_RawUTF8Print(string text);

            [DllImport("CPP_Main_LINUX_X64.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_DHav(double dlat, double lon1, double lon2, double dlon);

            [DllImport("CPP_Main_LINUX_X64.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_Theta(double Hav, bool isRadian = false);

            [DllImport("CPP_Main_LINUX_X64.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_Distance(double Hav, bool isRadian = false);

            [DllImport("CPP_Main_LINUX_X64.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_DistanceT(double T);
        }

        public class X86
        {
            [DllImport("CPP_Main_LINUX_X86.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_Convert(double x);

            [DllImport("CPP_Main_LINUX_X86.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_Hav(double x, bool Printing);

            [DllImport("CPP_Main_LINUX_X86.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_HavDeg(double x, bool Printing);

            [DllImport("CPP_Main_LINUX_X86.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_RawUTF8Print(string text);

            [DllImport("CPP_Main_LINUX_X86.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_DHav(double dlat, double lon1, double lon2, double dlon);

            [DllImport("CPP_Main_LINUX_X86.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_Theta(double Hav, bool isRadian = false);

            [DllImport("CPP_Main_LINUX_X86.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_Distance(double Hav, bool isRadian = false);

            [DllImport("CPP_Main_LINUX_X86.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double CPP_DistanceT(double T);
        }

        public class ARM
        {

        }

        public class ARM64
        {

        }

        public class ARMv6
        {

        }

        public class RISCV
        {

        }

    }
}

public class CPP
{
    enum OS
    {
        Unknown,
        Windows,
        Linux,
        Apple
    }
    enum CPU
    {
        X64,
        X86,
        ARM,
        ARM64,
        ARMv6,
        RISCV,
        Unknown
    }

    private static CPU GetCPU()
    {
        Architecture arch = RuntimeInformation.ProcessArchitecture;
        switch (arch)
        {
            default: return CPU.Unknown;
            case Architecture.X64:
                return CPU.X64;
            case Architecture.X86:
                return CPU.X86;
            case Architecture.Arm:
                return CPU.ARM;
            case Architecture.Arm64:
                return CPU.ARM64;
            case Architecture.Armv6:
                return CPU.ARMv6;
            case Architecture.RiscV64:
                return CPU.RISCV;
            case Architecture.LoongArch64:
                return CPU.Unknown;
        }
    }
    private static OS GetOS()
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


    public static double CPP_Convert(double x)
    {
        OS Platform = GetOS();
        CPU CPU = GetCPU();
        if (Platform == OS.Windows)
        {
            if (CPU == CPU.X64)
            {
                return DynamicOS.CPP_WINDOWS.CPP_Convert(x);
            }
            else if (CPU == CPU.X86)
            {
                return DynamicOS.CPP_WINDOWS_D.X86.CPP_Convert(x);
            }
            else
            {
                return 0.0;
            }
        }
        else
        {
            return DynamicOS.CPP_LINUX.CPP_Convert(x);
        }
    }

    public static double CPP_Hav(double x, bool Printing)
    {
        OS Platform = GetOS();
        CPU CPU = GetCPU();
        if (Platform == OS.Windows)
        {
            if(CPU == CPU.X64)
            {
            return DynamicOS.CPP_WINDOWS.CPP_Hav(x, Printing);

            } else if (CPU == CPU.X86)
            {
                return DynamicOS.CPP_WINDOWS_D.X86.CPP_Hav(x, Printing);
            } else
            {
                return 0.0;
            }
        }
        else
        {
            return DynamicOS.CPP_LINUX.CPP_Hav(x, Printing);
        }
    }

    public static double CPP_HavDeg(double x, bool Printing)
    {
        OS Platform = GetOS();
        CPU CPU = GetCPU();
        if (Platform == OS.Windows)
        {
            if(CPU == CPU.X64)
            {
            return DynamicOS.CPP_WINDOWS.CPP_HavDeg(x, Printing);

            } else if (CPU == CPU.X86)
            {
                return DynamicOS.CPP_WINDOWS_D.X86.CPP_HavDeg(x, Printing);
            } else
            {
                return 0.0;
            }
        }
        else
        {
            return DynamicOS.CPP_LINUX.CPP_HavDeg(x, Printing);
        }
    }

    public static double CPP_RawUTF8Print(string text)
    {
        OS Platform = GetOS();
        CPU CPU = GetCPU();
        if (Platform == OS.Windows)
        {
            if(CPU == CPU.X64)
            {
            return DynamicOS.CPP_WINDOWS.CPP_RawUTF8Print(text);

            } else if (CPU == CPU.X86)
            {
                return DynamicOS.CPP_WINDOWS_D.X86.CPP_RawUTF8Print(text);
            } else
            {
                return 0.0;
            }
        }
        else
        {
            return DynamicOS.CPP_LINUX.CPP_RawUTF8Print(text);
        }
    }

    public static double CPP_DHav(double dlat, double lon1, double lon2, double dlon)
    {
        OS Platform = GetOS();
        CPU CPU = GetCPU();
        if (Platform == OS.Windows)
        {
            if(CPU == CPU.X64)
            {
            return DynamicOS.CPP_WINDOWS.CPP_DHav(dlat, lon1, lon2, dlon);

            } else if (CPU == CPU.X86)
            {
                return DynamicOS.CPP_WINDOWS_D.X86.CPP_DHav(dlat, lon1, lon2, dlon);
            } else
            {
                return 0.0;
            }
        }
        else
        {
            return DynamicOS.CPP_LINUX.CPP_DHav(dlat, lon1, lon2, dlon);
        }
    }

    public static double CPP_Theta(double Hav, bool isRadian = false)
    {
        OS Platform = GetOS();
        CPU CPU = GetCPU();
        if (Platform == OS.Windows)
        {
            if(CPU == CPU.X64)
            {
            return DynamicOS.CPP_WINDOWS.CPP_Theta(Hav, isRadian);

            } else if (CPU == CPU.X86)
            {
                return DynamicOS.CPP_WINDOWS_D.X86.CPP_Theta(Hav, isRadian);
            } else
            {
                return 0.0;
            }
        }
        else
        {
            return DynamicOS.CPP_LINUX.CPP_Theta(Hav, isRadian);
        }
    }

    public static double CPP_Distance(double Hav, bool isRadian = false)
    {
        OS Platform = GetOS();
        CPU CPU = GetCPU();
        if (Platform == OS.Windows)
        {
            if(CPU == CPU.X64)
            {
            return DynamicOS.CPP_WINDOWS.CPP_Distance(Hav, isRadian);

            } else if (CPU == CPU.X86)
            {
                return DynamicOS.CPP_WINDOWS_D.X86.CPP_Distance(Hav, isRadian);
            } else
            {
                return 0.0;
            }
        }
        else
        {
            return DynamicOS.CPP_LINUX.CPP_Distance(Hav, isRadian);
        }
    }

    public static double CPP_DistanceT(double T)
    {
        OS Platform = GetOS();
        CPU CPU = GetCPU();
        if (Platform == OS.Windows)
        {
            if(CPU == CPU.X64)
            {
            return DynamicOS.CPP_WINDOWS.CPP_DistanceT(T);

            } else if (CPU == CPU.X86)
            {
                return DynamicOS.CPP_WINDOWS_D.X86.CPP_DistanceT(T);
            } else
            {
                return 0.0;
            }
        }
        else
        {
            return DynamicOS.CPP_LINUX.CPP_DistanceT(T);
        }
    }
}
