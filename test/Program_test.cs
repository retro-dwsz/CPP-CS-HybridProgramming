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

public class ProgramTestHav
{
    enum Symbol
    {
        Degree,
        Radian
    }

    [System.Runtime.InteropServices.DllImport("Hello.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    static extern void Hello();
    [System.Runtime.InteropServices.DllImport("Hello.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    static extern void Hav(double x, Symbol symbol = Symbol.Degree, bool printing = false);

    public static void Main_test()
    {
        System.Console.WriteLine("Calling C++ from C#...");
        Hello();
        Hav(90, printing: true);
        System.Console.WriteLine("Done.");
    }
}


public class ProgramTestCoffe
{
    [System.Runtime.InteropServices.DllImport("Coffee.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    static extern System.IntPtr Coffee_Create(string tag, string owner, int volume, int temp);

    [System.Runtime.InteropServices.DllImport("Coffee.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    static extern void Coffee_Status(System.IntPtr coffee);

    [System.Runtime.InteropServices.DllImport("Coffee.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    static extern void Coffee_Drink(System.IntPtr coffee, int volume);

    /*Compile:
    * Use `clang++ -std=c++23 -shared -o Coffee.dll Coffee.cpp CoffeeWrapper.cpp` 
    * or `clang++ -std=c++23 -shared -o Coffee.dll Coffee.cpp CoffeeWrapper.cpp -DUSING_FMT -Wno-pragma-once-outside-header -Wno-format-security -Wno-undefined-inline`
    * för no errors
    */
    public static void Main_test()
    {
        System.Console.WriteLine("Creating coffee...");
        System.IntPtr myCoffee = Coffee_Create("Latte", "David", 350, 65);

        System.Console.WriteLine("Status:");
        Coffee_Status(myCoffee);

        System.Console.WriteLine("\nDrinking 100ml...");
        Coffee_Drink(myCoffee, 100);

        System.Console.WriteLine("Status again:");
        Coffee_Status(myCoffee);
    }
}