/* * * ProgramExt.cs * * */

// Modded and Flattend SRC_CS from another github repo

namespace DYNAMIC_CS_CPP_HAV;

using System;                           // System sauces
using System.Text;                      // Text stuffs
using System.Collections.Generic;       // idk

using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;  // Super Optimization

/* * * * * * * */
// using CS_ExternCPP;
using CS_Location;
using CS_Haversine;
using CS_Symbols;
using CS_Misc;
using CS_Coloring;
using CS_Distance;


public class ProgramExt
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

    public static string GetCPU() {
        Architecture arch = RuntimeInformation.ProcessArchitecture;
        switch (arch)
        {
            default: return "unknown";
            case Architecture.X64:
                // Console.WriteLine("x86-64");
                return "x86-64";
            case Architecture.X86:
                // Console.WriteLine("x86");
                return "x86";
            case Architecture.Arm:
                // Console.WriteLine("ARM");
                return "ARM";
            case Architecture.Arm64:
                // Console.WriteLine("ARM64");
                return "ARM64";
            case Architecture.Armv6:
                return "ARMv6";
            case Architecture.RiscV64:
                return "RISC-V";
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool CheckEqual(object Var1, object Var2)
    {
        return Equals(Var1, Var2);
        // if (Var1 == Var2) {
        //     return true;
        // }
        // else {
        //     return false;
        // }
    }

    public static void ProgramMainRunner()
    {
        ProgramMainRunner(new Location(), new Location(), "");
    }

    private static void ProgramMainRunner(Location LocA, Location LocB, string tag = "")
    {
        if (tag != "")
        {
            Console.WriteLine(Misc.PrintMid(tag));
        }

        LocA.Printer();
        LocB.Printer();

        Console.WriteLine(Misc.PrintMid(Misc.PrintMid("Degree", '─', offset: -(Misc.TerminalSize / 2), LeftBorder: ' ', RightBorder: ' '), Char: ' ', LeftBorder: ' ', RightBorder: ' '));

        double D = Distance.Distance_2D.Distance_Deg(LocA, LocB);

        Console.WriteLine(Misc.PrintMid(Misc.PrintMid("Radians", '─', offset: -(Misc.TerminalSize / 2), LeftBorder: ' ', RightBorder: ' '), Char: ' ', LeftBorder: ' ', RightBorder: ' '));
        LocA.toRadian();
        LocB.toRadian();
        double R = Distance.Distance_2D.Distance_Rad(LocA, LocB);

        Console.WriteLine(Misc.Repeater("~", Console.WindowWidth / 2));

        Console.WriteLine($"Degrees = {D} KM");
        Console.WriteLine($"Radians = {R} KM");

        Console.WriteLine(CheckEqual(D, R) ? "C# + C/C++ is APPROVED!" : "meh");
    }

    public static void ENTRY_MAIN_EXT()
    {
        Console.WriteLine($"Running on {GetOS()} with {GetCPU()} CPU");
        string TITLE = ColorTx.ColorStr("Haversine Implementation!");
        Console.WriteLine(Misc.PrintMid(TITLE, ' ', LeftBorder: ' ', RightBorder: ' '));
        Console.WriteLine($"Terminal size: {Misc.TerminalSize}");

        // Save current color
        // ConsoleColor CurrentColor = Console.BackgroundColor;
        // Set color
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(Misc.PrintMid("IPBs", '─'));
        // Reset color
        Console.ResetColor();
        // IPB();
        ProgramMainRunner(new Location("SV IPB", -6.588457, 106.806200, isRadian: false), new Location("Danau IPB", -6.559582, 106.726720, isRadian: false));
        Console.WriteLine(Misc.Repeater("─", Misc.TerminalSize));

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(Misc.PrintMid("WIkipedia Example", '─'));
        Console.ResetColor();
        // WikipediaExample();
        ProgramMainRunner(new Location("White House WDC", 38.898, 77.037), new Location("Effiel Tower à Paris", 48.858, 2.294));
        Console.WriteLine(Misc.Repeater("─", Misc.TerminalSize));
    }
}

/* * * End ProgramExt.cs * * */