using DYNAMIC_CS_CPP_HAV;
using System;
using System.Runtime.InteropServices;

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
}

public class CPP
{
    public static int CheckPlatform()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return 1;
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            return 2;
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            return 3;
        }
        else
        {
            return -1;
        }
    }

    public static string GetOS()
    {
        int c = CheckPlatform();

        switch (c)
        {
            default: return "unknown";
            case 1: return "Windows";
            case 2: return "Linux";
            case 3: return "OSX";
        }
    }


    public static double CPP_Convert(double x)
    {
        string Platform = GetOS();
        if (Platform == "Windows")
        {
            return DynamicOS.CPP_WINDOWS.CPP_Convert(x);
        }
        else
        {
            return DynamicOS.CPP_LINUX.CPP_Convert(x);
        }
    }

    public static double CPP_Hav(double x, bool Printing)
    {
        string Platform = GetOS();
        if (Platform == "Windows")
        {
            return DynamicOS.CPP_WINDOWS.CPP_Hav(x, Printing);
        }
        else
        {
            return DynamicOS.CPP_LINUX.CPP_Hav(x, Printing);
        }
    }

    public static double CPP_HavDeg(double x, bool Printing)
    {
        string Platform = GetOS();
        if (Platform == "Windows")
        {
            return DynamicOS.CPP_WINDOWS.CPP_HavDeg(x, Printing);
        }
        else
        {
            return DynamicOS.CPP_LINUX.CPP_HavDeg(x, Printing);
        }
    }

    public static double CPP_RawUTF8Print(string text)
    {
        string Platform = GetOS();
        if (Platform == "Windows")
        {
            return DynamicOS.CPP_WINDOWS.CPP_RawUTF8Print(text);
        }
        else
        {
            return DynamicOS.CPP_LINUX.CPP_RawUTF8Print(text);
        }
    }

    public static double CPP_DHav(double dlat, double lon1, double lon2, double dlon)
    {
        string Platform = GetOS();
        if (Platform == "Windows")
        {
            return DynamicOS.CPP_WINDOWS.CPP_DHav(dlat, lon1, lon2, dlon);
        }
        else
        {
            return DynamicOS.CPP_LINUX.CPP_DHav(dlat, lon1, lon2, dlon);
        }
    }

    public static double CPP_Theta(double Hav, bool isRadian = false)
    {
        string Platform = GetOS();
        if (Platform == "Windows")
        {
            return DynamicOS.CPP_WINDOWS.CPP_Theta(Hav, isRadian);
        }
        else
        {
            return DynamicOS.CPP_LINUX.CPP_Theta(Hav, isRadian);
        }
    }

    public static double CPP_Distance(double Hav, bool isRadian = false)
    {
        string Platform = GetOS();
        if (Platform == "Windows")
        {
            return DynamicOS.CPP_WINDOWS.CPP_Distance(Hav, isRadian);
        }
        else
        {
            return DynamicOS.CPP_LINUX.CPP_Distance(Hav, isRadian);
        }
    }

    public static double CPP_DistanceT(double T)
    {
        string Platform = GetOS();
        if (Platform == "Windows")
        {
            return DynamicOS.CPP_WINDOWS.CPP_DistanceT(T);
        }
        else
        {
            return DynamicOS.CPP_LINUX.CPP_DistanceT(T);
        }
    }
}
