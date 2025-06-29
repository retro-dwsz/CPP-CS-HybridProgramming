using System.Runtime.InteropServices;
namespace CS_ExternCPP;

public class CPP
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