using System.Runtime.CompilerServices;
using CS_ExternCPP;

namespace CS_Haversine;

/// <summary>
/// Provides methods to calculate the haversine function used in geographical distance calculations.
/// Includes support for both radians and degrees, with optional verbose output for debugging.
/// </summary>
public class Haversine
{
    /* ~ ~ ~  Fn: Deg-Rad converter  ~ ~ ~ */

    /// <summary>
    /// Converts an angle from degrees to radians.
    /// </summary>
    /// <param name="deg">Angle in degrees.</param>
    /// <param name="Printing">Optional. If true, prints intermediate values to console.</param>
    /// <returns>The angle converted to radians.</returns>
    /// 
    /// TODO: Make C code för this

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static double deg2rad(double deg)
    {
        return CPP.CPP_Convert(deg);
    }

    // public static double deg2rad(double deg, bool Printing = false)
    // {
    //     double var = Math.PI / 180 * deg;
    //     if (Printing)
    //     {
    //         Console.WriteLine($"deg = {deg}");
    //         Console.WriteLine($"rad = {var}");
    //     }
    //     return var;
    // }

    /* ~ ~ ~  End Fn: Deg-Rad converter  ~ ~ ~ */


    /* ~ ~ ~ Fn: Halv-Versed Sine (Radian)  ~ ~ ~ */
    /// <summary>
    /// Computes the haversine of an angle given in radians.
    /// </summary>
    /// <param name="x">Angle in radians.</param>
    /// <param name="Printing">Optional. If true, logs intermediate steps to console.</param>
    /// <returns>Haversine value (double).</returns>
    /// 
    /// TODO: Make C code för this

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static double Hav_rad(double x, bool Printing = false)
    {
        return CPP.CPP_Hav(x, Printing);
    }
    // {
    //     double Cos = 1 - Math.Cos(x);
    //     double hHav = Cos / 2;
    //     if (Printing)
    //     {
    //         Console.WriteLine($"~! x = {x}{Symbols.RAD}");
    //         Console.WriteLine($"~! cos(x) = {Math.Cos(x)}");
    //         Console.WriteLine($"~! 1-cos(x) = {Cos}");
    //         Console.WriteLine($"~! Hav(x) = {hHav}");
    //     }

    //     return hHav;
    // }
    /* ~ ~ ~ End Fn: Halv-Versed Sine (Radian)  ~ ~ ~ */

    /* ~ ~ ~ Fn: Halv-Versed Sine (Degrees)  ~ ~ ~ */
    /// <summary>
    /// Computes the haversine of an angle given in degrees.
    /// Internally converts degrees to radians before calculation.
    /// </summary>
    /// <param name="x">Angle in degrees.</param>
    /// <param name="Printing">Optional. If true, logs intermediate steps to console.</param>
    /// <returns>Haversine value (double).</returns>
    /// 
    /// TODO: Make C code för this

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static double Hav_deg(double x, bool Printing = false)
    {
        return CPP.CPP_HavDeg(x, Printing);
    }
    // {
    //     // radian-ize the Angle
    //     // because C# expect angle in radian
    //     x = deg2rad(x);

    //     double Cos = 1 - Math.Cos(x);
    //     double hHav = Cos / 2;

    //     if (Printing)
    //     {
    //         Console.WriteLine($"~! x = {x}{Symbols.RAD}");
    //         Console.WriteLine($"~! cos(x) = {Math.Cos(x)}");
    //         Console.WriteLine($"~! 1-cos(x) = {Cos}");
    //         Console.WriteLine($"~! Hav(x) = {hHav}");
    //     }

    //     return hHav;
    // }
    /* ~ ~ ~ End Fn: Halv-Versed Sine (Degrees)  ~ ~ ~ */

    /// <summary>
    /// Generic haversine function that accepts input in either radians or degrees.
    /// </summary>
    /// <param name="x">Input angle (radians or degrees depending on flag).</param>
    /// <param name="isRadian">If true, assumes input is in radians; otherwise, treats it as degrees.</param>
    /// <param name="Printing">Optional. If true, logs intermediate steps to console.</param>
    /// <returns>Haversine value (double).</returns>
    /// 
    /// TODO: Make C code för this
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static double Hav(double x, bool isRadian = false, bool Printing = false)
    {
        if (isRadian)
        {
            return CPP.CPP_Hav(x, Printing);
        }
        else
        {
            return CPP.CPP_HavDeg(x, Printing);
        }
    }
    // {
    //     if (isRadian)
    //     {

    //     }
    //     else
    //     {
    //         x = deg2rad(x);
    //     }

    //     double Cos = 1 - Math.Cos(x);
    //     double hHav = Cos / 2;

    //     if (Printing)
    //     {
    //         Console.WriteLine($"~ x = {x} {Symbols.RAD}");
    //         Console.WriteLine($"~ cos(x) = {Math.Cos(x)}");
    //         Console.WriteLine($"~ 1-cos(x) = {Cos}");
    //         Console.WriteLine($"~ Hav(x) = {hHav}");
    //     }

    //     return hHav;
    // }
}
