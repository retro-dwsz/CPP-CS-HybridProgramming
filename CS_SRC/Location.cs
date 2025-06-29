using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using CS_Symbols;

namespace CS_Location;

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