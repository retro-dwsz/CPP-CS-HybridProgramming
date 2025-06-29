using System;
using CS_ExternCPP;
using System.Runtime.CompilerServices;

namespace CS_Coloring;

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
        CPP.CPP_RawUTF8Print(text);
    }
    // {
    //     Console.Write("DEBUG RAW: ");
    //     foreach (char c in text)
    //     {
    //         if (!char.IsControl(c) && !char.IsWhiteSpace(c))
    //         {
    //             Console.Write(c);
    //         }
    //         else
    //         {
    //             Console.Write($"\\x{((int)c):X2}");
    //         }
    //     }
    //     Console.WriteLine();
    // }

    private static ConsoleColor RgbToConsoleColor(byte r, byte g, byte b)
    {
        // Naive RGB -> ConsoleColor mapping
        int index = (r > 128 ? 4 : 0) + (g > 128 ? 2 : 0) + (b > 128 ? 1 : 0);
        return (ConsoleColor)index;
    }
}