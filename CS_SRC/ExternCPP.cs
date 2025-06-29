using System.Runtime.InteropServices;
using DYNAMIC_CS_CPP_HAV;

namespace CS_ExternCPP;

public class CPP
{
    // private static string GetFile() {
    //     string OS = ProgramExt.GetOS();
    //     string File = "";

    //     if (OS == "Windows")
    //     {
    //         File = "CPP_Main.dll";
    //     }
    //     else if (OS == "Linux")
    //     {
    //         File = "CPP_Main_LINUX.dll";
    //     };

    //     return File;
    // }

    // private string CPPFile = GetFile();

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

// NOT FULLY IMPLEMENTED YET!
class DynamicOS
{
    class CPP_Windows
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

    class CPP_Linux
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
