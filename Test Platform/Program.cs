// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

public class Debug
{
    public enum OS
    {
        Unknown,
        Windows,
        Linux,
        Apple
    }
    public enum CPU
    {
        X64,
        ARM,
        ARM64,
        Unknown
    }

    public static CPU GetCPU()
    {
        Architecture arch = RuntimeInformation.ProcessArchitecture;
        switch (arch)
        {
            default: return CPU.Unknown;
            case Architecture.X64:
                return CPU.X64;
            case Architecture.Arm:
                return CPU.ARM;
            case Architecture.Arm64:
                return CPU.ARM64;
        }
    }
    public static OS GetOS()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            // Console.WriteLine($"{RuntimeInformation.OSDescription}");
            return OS.Windows;
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            return OS.Linux;
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            return OS.Apple;
        }
        else
        {
            return OS.Unknown;
        }
    }

    public static void GetStatusSystem()
    {
        Console.WriteLine($"Running on {GetOS()} on {GetCPU()} CPU");
    }
}

class Program
{
    public static void Main()
    {
        Debug.GetStatusSystem();
    }
}