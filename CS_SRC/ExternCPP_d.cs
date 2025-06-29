// NOT FULLY IMPLEMENTED YET!

using System;
using System.Runtime.InteropServices;

namespace CS_ExternCPP_Dynamic;

public static class CPP_Dyn
{
    static IntPtr _lib;

    // ✅ Define delegate with UnmanagedFunctionPointer
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate double ConvertDel(double x);

    private static ConvertDel convert;

    static CPP_Dyn()
    {
        string lib =
            RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "CPP_Main.dll" :
            RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ? "CPP_Main_LINUX.dll" :
            throw new PlatformNotSupportedException("OS not supported!");

        _lib = NativeLibrary.Load(lib);

        // ✅ Ambil pointer dan cast ke delegate
        IntPtr funcPtr = NativeLibrary.GetExport(_lib, "CPP_Convert");
        convert = Marshal.GetDelegateForFunctionPointer<ConvertDel>(funcPtr);
    }

    public static double CPP_Convert(double x) => convert(x);

}
