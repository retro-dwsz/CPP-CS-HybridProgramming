// using System;
// using System.Runtime.InteropServices;

/* Compile: 
 * dotnet publish -c Release -r win-x64 --self-contained true
 * /p:PublishAot=true
 * /p:PublishSingleFile=true
 * /p:IncludeNativeLibrariesForSelfExtract=true
 * /p:StripSymbols=true
 * /p:IlcDisableReflection=true
 * /p:IlcGenerateCompleteTypeMetadata=false
 * /p:InvariantGlobalization=true
 * /p:EnableCompressionInSingleFile=true
 */

namespace DYNAMIC_CS_CPP_HAV_TEST;

enum Symbol
{
    Degree,
    Radian
}
public class Program_test 
{
    [System.Runtime.InteropServices.DllImport("Hello.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    static extern void Hello();
    [System.Runtime.InteropServices.DllImport("Hello.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    static extern void Hav(double x, Symbol symbol = Symbol.Degree, bool printing = false);

    public static void Main_test()
    {
        System.Console.WriteLine("Calling C++ from C#...");
        Hello();
        Hav(90, printing:true);
        System.Console.WriteLine("Done.");
    }
}

