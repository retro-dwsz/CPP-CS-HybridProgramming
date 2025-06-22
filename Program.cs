using System;
using System.Runtime.InteropServices;

enum Symbol
{
    Degree,
    Radian
}

/* Compile
 * dotnet publish -c Release -r win-x64 --self-contained true /p:PublishAot=true /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true /p:StripSymbols=true /p:IlcDisableReflection=true /p:IlcGenerateCompleteTypeMetadata=false /p:InvariantGlobalization=true /p:EnableCompressionInSingleFile=true
 */
class Program
{
    [DllImport("Hello.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void Hello();
    [DllImport("Hello.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void Hav(double x, Symbol symbol = Symbol.Degree, bool printing = false);

    static void Main()
    {
        Console.WriteLine("Calling C++ from C#...");
        Hello();
        Hav(90, printing:true);
        Console.WriteLine("Done.");
    }
}