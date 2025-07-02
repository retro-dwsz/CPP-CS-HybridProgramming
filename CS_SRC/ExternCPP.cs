using DYNAMIC_CS_CPP_HAV;
using System;

// using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
// using System.Runtime.Versioning;

// NOT FULLY IMPLEMENTED YET!
public class CPP_F
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


public class CPP
{
    public static double CPP_Convert(double x)
    {
        return CPP_F.CPP_Convert(x);
    }

    public static double CPP_Hav(double x, bool Printing)
    {
        return CPP_F.CPP_Hav(x, Printing);
    }

    public static double CPP_HavDeg(double x, bool Printing)
    {
        return CPP_F.CPP_HavDeg(x, Printing);
    }

    public static double CPP_RawUTF8Print(string text)
    {
        return CPP_F.CPP_RawUTF8Print(text);
    }

    public static double CPP_DHav(double dlat, double lon1, double lon2, double dlon)
    {
        return CPP_F.CPP_DHav(dlat, lon1, lon2, dlon);
    }

    public static double CPP_Theta(double Hav, bool isRadian = false)
    {
        return CPP_F.CPP_Theta(Hav, isRadian);
    }

    public static double CPP_Distance(double Hav, bool isRadian = false)
    {
        return CPP_F.CPP_Distance(Hav, isRadian);
    }

    public static double CPP_DistanceT(double T)
    {
        return CPP_F.CPP_DistanceT(T);
    }
}
