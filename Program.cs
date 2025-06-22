// using System;
using System.Runtime.InteropServices;

class Program
{
    [DllImport("Hello.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void Hello();

    static void Main()
    {
        Console.WriteLine("Calling C++ from C#...");
        Hello();
        Console.WriteLine("Done.");
    }
}