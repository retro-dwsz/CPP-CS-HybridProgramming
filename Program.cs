/* * * Program.cs * * */

// ORIGINAL FILE for entry point
// This is Flattend SRC_CS from another github repo
// For testing:
// DYNAMIC_CS_CPP_HAV_TEST.Program_test.Main_test();

namespace CS_Navigation;

using System;                           // System sauces
using System.Text;                      // Text stuffs
using System.Collections.Generic;       // idk

// using System.Diagnostics;
using System.Runtime.CompilerServices;  // Super Optimization
using DYNAMIC_CS_CPP_HAV_TEST;          // Testing
using DYNAMIC_CS_CPP_HAV;               // The Experiment

/**/
// using Location;                // Main sauce I
// using Haversine;               // Main sauce II
// using Symbols;                 // Helper of main sauce
// using Distance;                // The main dish along with the main sauce
// using Misc;                    // Very side dish

using OLD;                        // Old Program here

/// <summary>
/// Main entry point gate
/// </summary>
public class Program
{
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

    /* TEMPLATE:
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void IPB()
    {
        // [-6.588457, 106.806200]
        // [-6.559582, 106.726720]   

        Console.WriteLine($"Current terminal size: {Misc.TerminalSize}");

        Location SV_IPB = new Location("SV IPB", -6.588457, 106.806200, isRadian: false);
        Location Danau_IPB = new Location("Danau IPB", -6.559582, 106.726720, isRadian: false);

        SV_IPB.Printer();
        Danau_IPB.Printer();

        Console.WriteLine(Misc.PrintMid(Misc.PrintMid("Degree", '─', offset: -(Misc.TerminalSize / 2), LeftBorder: ' ', RightBorder: ' '), Char: ' ', LeftBorder: ' ', RightBorder: ' '));
        // double D = nDistance.Distance_2D.Distance_Deg(SV_IPB, Danau_IPB);
        double D = Distance.Distance_2D.Distance_Deg(SV_IPB, Danau_IPB);

        Console.WriteLine(Misc.PrintMid(Misc.PrintMid("Radians", '─', offset: -(Misc.TerminalSize / 2), LeftBorder: ' ', RightBorder: ' '), Char: ' ', LeftBorder: ' ', RightBorder: ' '));
        SV_IPB.toRadian();
        Danau_IPB.toRadian();

        // double R = nDistance.Distance_2D.Distance_Rad(SV_IPB, Danau_IPB);
        double R = Distance.Distance_2D.Distance_Rad(SV_IPB, Danau_IPB);

        Console.WriteLine(Misc.Repeater("~", Console.WindowWidth / 2));

        Console.WriteLine($"Degrees = {D} KM");
        Console.WriteLine($"Radians = {R} KM");

        Console.WriteLine(CheckEqual(D, R) ? "APPROVED!" : "meh");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void WikipediaExample()
    {
        Location WhiteHouse = new Location("White House WDC", 38.898, 77.037);
        Location EffielTowr = new Location("Effiel Tower à Paris", 48.858, 2.294);

        WhiteHouse.Printer();
        EffielTowr.Printer();

        Console.WriteLine(Misc.PrintMid(Misc.PrintMid("Degree", '─', offset: -(Misc.TerminalSize / 2), LeftBorder: ' ', RightBorder: ' '), Char: ' ', LeftBorder: ' ', RightBorder: ' '));

        double D = Distance.Distance_2D.Distance_Deg(WhiteHouse, EffielTowr);

        WhiteHouse.toRadian();
        EffielTowr.toRadian();

        Console.WriteLine(Misc.PrintMid(Misc.PrintMid("Radians", '─', offset: -(Misc.TerminalSize / 2), LeftBorder: ' ', RightBorder: ' '), Char: ' ', LeftBorder: ' ', RightBorder: ' '));
        double R = Distance.Distance_2D.Distance_Rad(WhiteHouse, EffielTowr);

        Console.WriteLine(Misc.Repeater("~", Console.WindowWidth / 2));

        Console.WriteLine($"Degrees = {D} KM");
        Console.WriteLine($"Radians = {R} KM");

        Console.WriteLine(CheckEqual(D, R) ? "APPROVED!" : "meh");
    }
    */

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

        Console.WriteLine(CheckEqual(D, R) ? "APPROVED!" : "meh");
    }

    public static void ENTRY_TEST()
    {
        ProgramTestCoffe.Main_test();
    }

    public static void ENTRY_MAIN()
    {
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

    public static void Main()
    {
        try
        {
            // ENTRY_MAIN();
            // ENTRY_TEST();
            ProgramExt.ENTRY_MAIN_EXT();
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}

/* * * End Program.cs * * */

/*
    6     6   │clang++ -shared -std=c++23 -o $file.dll $file.ll -fPIC                                                                                         
    7     7   '''                                                                                                                                             
    8     8                                                                                                                                                   
    9     9   import os                                                                                                                                       
   10    10                                                                                                                                                   
   11    11   # File list — only C++ source files, NOT headers!                                                                                               
   12    12   cpp_files = [                                                                                                                                   
   13    13   │   "Distance.cpp",                                                                                                                             
   14    14   │   "Haversine.cpp",                                                                                                                            
   15    15   │   "main.cpp",          # Optional, only if needed                                                                                             
   16    16   │   # Add more .cpp files                                                                                                                       
   17    17   ]                                                                                                                                               
   18    18                                                                                                                                                   
   19    19   # Directories                                                                                                                                   
   20    20   SRC_DIR = "./CPP_SRC"                                                                                                                           
   21    21   LL_DIR  = "./CPP_LL"                                                                                                                            
   22    22   DLL_DIR = "./CPP_DLL"                                                                                                                           
   23    23                                                                                                                                                   
   24    24   def compile_to_llvm(src_file: str) -> str:                                                                                                      
   25    25   │   """Compile .cpp to .ll (LLVM IR)"""                                                                                                         
   26  NORMAL   main  󰌠  compile.py                                                                                       35   1  14%  19:44   01:26 
 NORMAL   main  term:\…\system32\cmd.exe                               
*/