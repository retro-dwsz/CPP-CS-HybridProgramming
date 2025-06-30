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

/// <summary>
/// Represents a geographical location with latitude, longitude, and associated metadata.
/// </summary>
public class Location
{
    public enum Unit
    {
        Degree,
        Radian
    }
    /*
     Default latitude       0 
     Default longitude      0
     Default name           MyLocation 
     Default coords unit    Degrees
    */
    public double Lat = 0;
    public double Lon = 0;
    public string Name = "";
    public Unit LUnit;

    private string Symbol = "";
    private List<double> Coords = new List<double>();

    /// <summary>
    /// Initializes a new instance of the Location class with default or specified values.
    /// </summary>
    /// <param name="Lat">Latitude of the location (default: 0).</param>
    /// <param name="Lon">Longitude of the location (default: 0).</param>
    /// <param name="Name">Name of the location (default: "MyLocation").</param>
    /// <param name="isRadian">Indicates whether the coordinates are in radians (default: false).</param>
    public Location(string Name = "MyLocation", double Lat = 0, double Lon = 0, bool isRadian = false)
    {
        if (isRadian)
        {
            LUnit = Unit.Radian;
            Symbol = Symbols.RAD;
        }
        else if (!isRadian)
        {
            LUnit = Unit.Degree;
            Symbol = Symbols.DEGREE;
        }
        this.Lat = Lat;
        this.Lon = Lon;
        this.Name = Name;

        Coords.Add(Lat);
        Coords.Add(Lon);
    }

    /// <summary>
    /// Prints the location's details in a human-readable format.
    /// </summary>
    public void Printer()
    {
        Console.WriteLine($"{Name} Coords in {LUnit}");
        Console.WriteLine($"{Symbols.PHI} = {Lat}{Symbol}");
        Console.WriteLine($"{Symbols.LAMBDA} = {Lon}{Symbol}");
    }

    /// <summary>
    /// Converts the location's coordinates to radians.
    /// </summary>
    /// <param name="SupressWarning">Suppresses warnings if the coordinates are already in radians (default: false).</param>
    /// <param name="force">Forces conversion even if the coordinates are already in radians (default: false).</param>
    /// <returns>A list containing the converted latitude and longitude in radians.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void toRadian(bool SupressWarning = false, bool force = false)
    {
        if (LUnit == Unit.Radian)
        {
            if (!SupressWarning && force)
            {
                Console.WriteLine("Warning: Already in Radians, but forced conversion is enabled.");
            }
            else if (!SupressWarning)
            {
                Console.WriteLine("Warning: Already in Radians.");
                // return Coords;
            }
        }

        // Perform the actual conversion
        Lat = Lat * Math.PI / 180;
        Lon = Lon * Math.PI / 180;

        LUnit = Unit.Radian;
        Symbol = Symbols.RAD;

        Coords.Clear();
        Coords.Add(Lat);
        Coords.Add(Lon);
    }

    /// <summary>
    /// Converts the location's coordinates to degrees.
    /// </summary>
    /// <param name="SupressWarning">Suppresses warnings if the coordinates are already in degrees (default: false).</param>
    /// <param name="Force">Forces conversion even if the coordinates are already in degrees (default: false).</param>
    /// <returns>A list containing the converted latitude and longitude in degrees.</returns>
    /// 
    /// TODO: Make C code för this?
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ToDegree(bool SupressWarning = false, bool Force = false)
    {
        if (LUnit == Unit.Degree)
        {
            if (!SupressWarning && Force)
            {
                Console.WriteLine("Warning: Already in Degrees, but forced conversion is enabled.");
            }
            else if (!SupressWarning)
            {
                Console.WriteLine("Warning: Already in Degrees.");
                // return Coords;
            }
        }

        // Perform the actual conversion
        Lat = Lat * Math.PI / 180;
        Lon = Lon * Math.PI / 180;

        LUnit = Unit.Degree;
        Symbol = Symbols.DEGREE;

        Coords.Clear();
        Coords.Add(Lat);
        Coords.Add(Lon);
    }

    /// <summary>
    /// Retrieves the current coordinates of the location.
    /// </summary>
    /// <returns>A list containing the latitude and longitude.</returns>
    public List<double> GetCoords()
    {
        return Coords;
    }

    public Unit GetUnit()
    {
        return LUnit;
    }
};

/// <summary>
/// Provides methods to calculate the haversine function used in geographical distance calculations.
/// Includes support for both radians and degrees, with optional verbose output for debugging.
/// </summary>
public class Haversine
{
    /// <summary>
    /// Converts an angle from degrees to radians.
    /// </summary>
    /// <param name="deg">Angle in degrees.</param>
    /// <param name="Printing">Optional. If true, prints intermediate values to console.</param>
    /// <returns>The angle converted to radians.</returns>
    /// 
    /// TODO: Make C code för this
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static double deg2rad(double deg, bool Printing = false)
    {
        double var = Math.PI / 180 * deg;
        if (Printing)
        {
            Console.WriteLine($"deg = {deg}");
            Console.WriteLine($"rad = {var}");
        }
        return var;
    }

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
        double Cos = 1 - Math.Cos(x);
        double hHav = Cos / 2;
        if (Printing)
        {
            Console.WriteLine($"~! x = {x}{Symbols.RAD}");
            Console.WriteLine($"~! cos(x) = {Math.Cos(x)}");
            Console.WriteLine($"~! 1-cos(x) = {Cos}");
            Console.WriteLine($"~! Hav(x) = {hHav}");
        }

        return hHav;
    }

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
        // radian-ize the Angle
        // because C# expect angle in radian
        x = deg2rad(x);

        double Cos = 1 - Math.Cos(x);
        double hHav = Cos / 2;

        if (Printing)
        {
            Console.WriteLine($"~! x = {x}{Symbols.RAD}");
            Console.WriteLine($"~! cos(x) = {Math.Cos(x)}");
            Console.WriteLine($"~! 1-cos(x) = {Cos}");
            Console.WriteLine($"~! Hav(x) = {hHav}");
        }

        return hHav;
    }

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
        if (isRadian) { }
        else
        {
            x = deg2rad(x);
        }

        double Cos = 1 - Math.Cos(x);
        double hHav = Cos / 2;

        if (Printing)
        {
            Console.WriteLine($"~ x = {x} {Symbols.RAD}");
            Console.WriteLine($"~ cos(x) = {Math.Cos(x)}");
            Console.WriteLine($"~ 1-cos(x) = {Cos}");
            Console.WriteLine($"~ Hav(x) = {hHav}");
        }

        return hHav;
    }
}

public static class Symbols
{
    // Greek Alphabets
    public const string DELTA = "\u0394";    // Δ
    public const string THETA = "\u03b8";    // θ
    public const string PHI = "\u03d5";    // π   
    public const string LAMBDA = "\u03bb";    // λ

    // Greek Alphabets Colored
    public const string C_DELTA = "\x1b[38;2;115;192;105m\u0394\x1b[0m";    // Color: 73c069
    public const string C_THETA = "\x1b[38;2;255;138;70m\u03b8\x1b[0m";     // Color: ff8a46
    public const string C_PHI = "\x1b[38;2;16;150;150m\u03d5\x1b[0m";     // Color: 109696
    public const string C_LAMBDA = "\x1b[38;2;223;196;125m\u03bb\x1b[0m";    // Color: dfc47d

    // Math symbols
    public const string DEGREE = "\u00b0"; // °
    public const string RAD = " RAD";      // RAD
    public const string SQRT = "\u221a";   // √
    public const string APRX = "\u2248";   // ≈

    // Subscripts
    public const string SB1 = "\u2081";    // ₁
    public const string SB2 = "\u2082";    // ₂
};

/// <summary>
/// Provides utility methods for string manipulation and console formatting.
/// Includes functions to repeat strings, center text in the terminal, and more.
/// </summary>
public static class Misc
{
    /// <summary>
    /// Gets the current width of the console window.
    /// Can be used as a reference for aligning or centering output.
    /// </summary>
    public static int TerminalSize = Console.WindowWidth;

    /// <summary>
    /// Repeats a given string or character a specified number of times.
    /// Or in other words, mimics the string multiplication from Python in C# 
    /// </summary> 
    /// <param name="str">The string or character to repeat.</param>
    /// <param name="repetitions">Number of times to repeat (default: 1).</param>
    /// <returns>A single string with the input repeated.</returns>
    /// <example>
    /// <code>
    /// string result = Misc.Repeater("hello", 3); // Returns "hellohellohello"
    /// </code>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Repeater(object str, int repetitions = 1)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < repetitions; i++)
        {
            sb.Append(str?.ToString());
        }

        return sb.ToString();
    }

    /// <summary>
    /// Centers a given text within the terminal window, bordered by a repeating character.
    /// Useful for creating headers or separators in console applications.
    /// </summary>
    /// <param name="Text">The text to center (default: "Hello").</param>
    /// <param name="Char">Character used to fill borders (default: '=').</param>
    /// <param name="offset">Adds extra space to simulate padding or margin (default: 2).</param>
    /// <param name="Printing">If true, prints the result to the console (default: false).</param>
    /// <returns>The formatted centered string.</returns>
    /// <example>
    /// <code>
    /// Misc.PrintMid("Welcome", '-', offset: 4, Printing: true);
    /// // Output:
    /// // ------------------[Welcome]-------------------
    /// </code>
    /// </example>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string PrintMid(string Text = "Hello", char Char = '=', int offset = 2, char LeftBorder = '[', char RightBorder = ']', bool Printing = false)
    {
        int ConsoleWidth = TerminalSize + offset;               // Get width + offset
        int Border_sz = (ConsoleWidth - Text.Length - 4) / 2;   // Subtract the length of the text and some spacing ([Text] takes up 4 characters).
                                                                // Divide the remaining space equally between left and right borders.
                                                                // If ConsoleWidth = 80, Text.Length = 5 → Remaining space = 80 - 5 - 4 = 71
                                                                // Each border gets 71 / 2 = 35 characters.

        // Build Left & Right borders
        string Left = Repeater(Char, Border_sz);                        // Left side uses exactly Border_sz characters.
        string Right = Repeater(Char, Border_sz + (Text.Length % 2));   // Right side adjusts if the text has an odd number of characters,
                                                                        // so total width stays balanced.

        // Final assembly
        string Content = $"{Left}{LeftBorder}{Text}{RightBorder}{Right}";

        if (Printing)
        {
            Console.WriteLine(Content);
        }

        return Content;
    }
}

public class ColorTx
{
    public enum Position { Back, Fore }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ColorStr(string text = "Hello, world!", uint hex = 0xFF109696, Position pos = Position.Fore)
    {
        // Parse RGB from 0xAARRGGBB or 0xRRGGBB
        byte a = 255, r, g, b;
        if (hex > 0xFFFFFF)
        {
            a = (byte)((hex >> 24) & 0xFF);
            r = (byte)((hex >> 16) & 0xFF);
            g = (byte)((hex >> 8) & 0xFF);
            b = (byte)(hex & 0xFF);
        }
        else
        {
            r = (byte)((hex >> 16) & 0xFF);
            g = (byte)((hex >> 8) & 0xFF);
            b = (byte)(hex & 0xFF);
        }

        // Convert RGB to closest ConsoleColor
        ConsoleColor color = RgbToConsoleColor(r, g, b);

        if (pos == Position.Fore)
            Console.ForegroundColor = color;
        else
            Console.BackgroundColor = color;

        return text;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Print(uint hex, Position pos, string text)
    {
        Console.WriteLine(ColorStr(text, hex, pos));
        Console.ResetColor(); // Don't leave your terminal cursed
    }

    // Kinda not useful
    // TODO: Make C code för this
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Debug(string text)
    {
        Console.Write("DEBUG RAW: ");
        foreach (char c in text)
        {
            if (!char.IsControl(c) && !char.IsWhiteSpace(c))
            {
                Console.Write(c);
            }
            else
            {
                Console.Write($"\\x{((int)c):X2}");
            }
        }
        Console.WriteLine();
    }

    private static ConsoleColor RgbToConsoleColor(byte r, byte g, byte b)
    {
        // Naive RGB -> ConsoleColor mapping
        int index = (r > 128 ? 4 : 0) + (g > 128 ? 2 : 0) + (b > 128 ? 1 : 0);
        return (ConsoleColor)index;
    }
}

public class Distance
{
    public static int R = 6371;

    public class Distance_2D
    {
        /*
        based on Wikipedia article (With Printing)
        https://en.wikipedia.org/wiki/Haversine_formula

        formula:
        hav(θ°) = hav(Δφ) + cos(φ₁) * cos(φ₂) * hav(Δλ)
        θ° = 2 * archav(θ)
        d = R * θ°

        hav(x) = sin²(x/2) = (1 - cos(x))/2
        archav(θ) = 2 * arcsin(√(θ)) = 2 * arctan2(√(θ), √(1-θ))
        */
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static double Distance_Deg(Location A, Location B)
        {
            // Print Degree coordinates 
            Console.WriteLine($"Coords in Degrees");

            // Latitudes
            double lat1 = A.Lat;
            double lon1 = A.Lon;
            Console.WriteLine($"{Symbols.PHI}{Symbols.SB1} = {lat1}{Symbols.DEGREE}");
            Console.WriteLine($"{Symbols.LAMBDA}{Symbols.SB1} = {lon1}{Symbols.DEGREE}\n");

            // Longitudes
            double lat2 = B.Lat;
            double lon2 = B.Lon;
            Console.WriteLine($"{Symbols.PHI}{Symbols.SB2} = {lat2}{Symbols.DEGREE}");
            Console.WriteLine($"{Symbols.LAMBDA}{Symbols.SB2} = {lon2}{Symbols.DEGREE}\n~~~");

            // Calculate Deltas
            // Delta phi
            double Dlat = lat2 - lat1;                                          /// TODO: Make C code för this
            Console.WriteLine($"{Symbols.DELTA}{Symbols.PHI} = {Symbols.PHI}{Symbols.SB2} - {Symbols.PHI}{Symbols.SB1}");
            Console.WriteLine($"{Symbols.DELTA}{Symbols.PHI} = {lat2} - {lat1}");
            Console.WriteLine($"{Symbols.DELTA}{Symbols.PHI} = {Dlat}\n");

            // Delta lambda
            double Dlon = lon2 - lon1;                                          /// TODO: Make C code för this
            Console.WriteLine($"{Symbols.DELTA}{Symbols.LAMBDA} = {Symbols.LAMBDA}{Symbols.SB2} - {Symbols.LAMBDA}{Symbols.SB1}");
            Console.WriteLine($"{Symbols.DELTA}{Symbols.LAMBDA} = {lon2} - {lon1}");
            Console.WriteLine($"{Symbols.DELTA}{Symbols.LAMBDA} = {Dlon}\n~~~");

            /*
            Convert to Radians and Build hav(θ) formula
            */
            Console.WriteLine($"~ Hav({Symbols.DELTA}{Symbols.PHI})");
            Console.WriteLine($"~ Hav({Dlat}{Symbols.DEGREE})");
            double hav1 = Haversine.Hav_deg(Dlat, Printing: true);              /// TODO: Make C code för this

            Console.WriteLine($"\n~ Hav({Symbols.DELTA}{Symbols.LAMBDA})");
            Console.WriteLine($"~ Hav({Dlon}{Symbols.DEGREE})");
            double hav2 = Haversine.Hav_deg(Dlon, Printing: true);              /// TODO: Make C code för this

            double cos1 = Math.Cos(Haversine.deg2rad(lat1));
            double cos2 = Math.Cos(Haversine.deg2rad(lat2));

            /// TODO: Make C code för this {
            // Plug everything
            double Hav = hav1 + cos1 * cos2 * hav2;
            // Find theta
            double T = 2 * Math.Asin(Math.Sqrt(Hav));
            // Find d with theta
            double d = R * T;

            Console.WriteLine($"\nhav({Symbols.THETA}) = hav({Symbols.DELTA}{Symbols.PHI}) + cos({Symbols.PHI}{Symbols.SB1}) * cos({Symbols.PHI}{Symbols.SB2}) * hav({Symbols.DELTA}{Symbols.LAMBDA})");
            Console.WriteLine($"hav({Symbols.THETA}) = hav({Dlat}) + cos({lat1}) * cos({lat2}) * hav({Dlon})");
            Console.WriteLine($"hav({Symbols.THETA}) = {hav1} + {cos1} * {cos2} * {hav2}");
            Console.WriteLine($"hav({Symbols.THETA}) = {Hav}");

            Console.WriteLine($"{Symbols.THETA} = 2 * archav({Symbols.SQRT}(1 - hav)))");
            Console.WriteLine($"{Symbols.THETA} = 2 * arcsin({Symbols.SQRT}({Hav})");
            Console.WriteLine($"{Symbols.THETA} = {T}");

            Console.WriteLine($"d = R * θ{Symbols.RAD}");
            Console.WriteLine($"d = {R} * {T}");
            Console.WriteLine($"d {Symbols.APRX} {d} KM");
            Console.WriteLine($"d {Symbols.APRX} {Math.Round(d, 2)} KM");

            return d;
        }

        /*
        based on Radian formula (With Printing)

        hav(θ) = hav(Δφ) + cos(φ₁) * cos(φ₂) * hav(Δλ)
        θ = 2 * arctan2(√(θ), √(1-θ))
        d = R * θ
        hav(x) = sin²(x/2) = (1 - cos(x))/2
        */
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static double Distance_Rad(Location A, Location B)
        {
            // Print Radian coordinates 
            Console.WriteLine("Coords in Radians");
            // Latitudes
            double lat1 = A.Lat;
            double lon1 = A.Lon;
            Console.WriteLine($"{Symbols.PHI}{Symbols.SB1} = {lat1}{Symbols.RAD}");
            Console.WriteLine($"{Symbols.LAMBDA}{Symbols.SB1} = {lon1}{Symbols.RAD}\n");

            // Longitudes
            double lat2 = B.Lat;
            double lon2 = B.Lon;
            Console.WriteLine($"{Symbols.PHI}{Symbols.SB2} = {lat2}{Symbols.RAD}");
            Console.WriteLine($"{Symbols.LAMBDA}{Symbols.SB2} = {lon2}{Symbols.RAD}\n~~~");

            // Calculate Deltas
            // Delta phi
            double Dlat = lat2 - lat1;
            Console.WriteLine($"{Symbols.DELTA}{Symbols.PHI} = {Symbols.PHI}{Symbols.SB2} - {Symbols.PHI}{Symbols.SB1}");
            Console.WriteLine($"{Symbols.DELTA}{Symbols.PHI} = {lat2} - {lat1}");
            Console.WriteLine($"{Symbols.DELTA}{Symbols.PHI} = {Dlat}\n");

            // Delta lambda
            double Dlon = lon2 - lon1;
            Console.WriteLine($"{Symbols.DELTA}{Symbols.LAMBDA} = {Symbols.LAMBDA}{Symbols.SB2} - {Symbols.LAMBDA}{Symbols.SB1}");
            Console.WriteLine($"{Symbols.DELTA}{Symbols.LAMBDA} = {lon2} - {lon1}");
            Console.WriteLine($"{Symbols.DELTA}{Symbols.LAMBDA} = {Dlon}\n~~~");

            // Build hav(θ) formula
            Console.WriteLine($"~  Hav({Symbols.DELTA}{Symbols.PHI})");
            Console.WriteLine($"~  Hav({Dlat})");
            double hav1 = Haversine.Hav_rad(Dlat, Printing: true);

            Console.WriteLine($"\n~  Hav({Symbols.DELTA}{Symbols.LAMBDA})");
            Console.WriteLine($"~  Hav({Dlon})");
            double hav2 = Haversine.Hav_rad(Dlon, Printing: true);
            double cos1 = Math.Cos(lat1);
            double cos2 = Math.Cos(lat2);

            /// TODO: Make C code för this
            // Plug everything
            double Hav = hav1 + cos1 * cos2 * hav2;
            // Find theta
            double T = 2 * Math.Atan2(Math.Sqrt(Hav), Math.Sqrt(1 - Hav));
            // Find d with theta
            double d = R * T;

            Console.WriteLine($"\nhav({Symbols.THETA}) = hav({Symbols.DELTA}{Symbols.PHI}) + cos({Symbols.PHI}{Symbols.SB1}) * cos({Symbols.PHI}{Symbols.SB2}) * hav({Symbols.DELTA}{Symbols.LAMBDA})");
            Console.WriteLine($"hav({Symbols.THETA}) = hav({Dlat}) + cos({lat1}) * cos({lat2}) * hav({Dlon})");
            Console.WriteLine($"hav({Symbols.THETA}) = {hav1} + {cos1} * {cos2} * {hav2}");
            Console.WriteLine($"hav({Symbols.THETA}) = {Hav}\n");

            Console.WriteLine($"{Symbols.THETA} = 2 * archav({Symbols.THETA})");
            Console.WriteLine($"{Symbols.THETA} = 2 * arctan2({Symbols.SQRT}({Symbols.THETA}), {Symbols.SQRT}(1 - {Symbols.THETA}))");
            Console.WriteLine($"{Symbols.THETA} = 2 * arctan2({Symbols.SQRT}({Hav}), {Symbols.SQRT}({1 - Hav}))");
            Console.WriteLine($"{Symbols.THETA} = {T}\n");

            Console.WriteLine($"d = R * θ{Symbols.RAD}");
            Console.WriteLine($"d = {R} * {T}");
            Console.WriteLine($"d {Symbols.APRX} {d} KM");
            Console.WriteLine($"d {Symbols.APRX} {Math.Round(d, 2)} KM");

            return d;
        }

        /// TODO: Make C code för this
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        public static double Distance(Location A, Location B, bool IsRadian = false)
        {
            double lat1, lon1;
            double lat2, lon2;

            double Dlat;
            double Dlon;

            double hav1;
            double hav2;
            double cos1;
            double cos2;

            double Hav, T, d;

            if (!IsRadian)
            {
                lat1 = A.Lat;
                lon1 = A.Lon;
                lat2 = B.Lat;
                lon2 = B.Lon;

                Dlat = lat2 - lat1;
                Dlon = lon2 - lon1;

                hav1 = Haversine.Hav_deg(Dlat);
                hav2 = Haversine.Hav_deg(Dlon);
                cos1 = Math.Cos(Haversine.deg2rad(lat1));
                cos2 = Math.Cos(Haversine.deg2rad(lat2));
                Hav = hav1 + cos1 * cos2 * hav2;
                T = 2 * Math.Asin(Math.Sqrt(Hav));
                d = R * T;
                return d;
            }
            else
            {
                lat1 = A.Lat;
                lon1 = A.Lon;
                lat2 = B.Lat;
                lon2 = B.Lon;

                Dlat = lat2 - lat1;
                Dlon = lon2 - lon1;

                hav1 = Haversine.Hav_rad(Dlat);
                hav2 = Haversine.Hav_rad(Dlon);
                cos1 = Math.Cos(lat1);
                cos2 = Math.Cos(lat2);
                Hav = hav1 + cos1 * cos2 * hav2;
                T = 2 * Math.Atan2(Math.Sqrt(Hav), Math.Sqrt(1 - Hav));
                d = R * T;
                return d;
            }
        }
    }
}

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

    /*
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
