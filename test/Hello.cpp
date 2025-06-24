// #pragma once

#include <cmath>
#include <vector>
#include <string>
#include <string_view>

#include <sstream>

#include <fmt/format.h>
#include <variant>

#include <any>

const double PI =  3.141592653589793;
const int R     =  6378;

// #ifdef _WIN32
//   #define API __declspec(dllexport)
// #else
//   #define API __attribute__((visibility("default")))
// #endif

/********************************************** Hello Test **********************************************/

extern "C" __declspec(dllexport)
void Hello()
{
    fmt::println("Hello, fmt!");
    fmt::println("{:-^80}", "[Border!]");
}

/********************************************** Some Crazy stuffs **********************************************/
using str   = std::string;
using str_v = std::string_view;

enum class Unit {
    Degree,
    Radian
};

namespace Symbols {
    // Units
    inline constexpr str_v Degree = "\u00B0";     // °
    inline constexpr str_v Radian = "RAD";

    // Greek letters
    inline constexpr str_v PHI    = "\u03D5";   // φ
    inline constexpr str_v LAMBDA = "\u03BB";   // λ
    inline constexpr str_v DELTA  = "\u0394";   // Δ
    inline constexpr str_v THETA  = "\u03B8";   // θ

    // Colored versions using ANSI escape codes
    inline constexpr str_v C_DELTA  = "\x1b[38;2;115;192;105m\u0394\x1b[0m";   // Green
    inline constexpr str_v C_THETA  = "\x1b[38;2;255;138;70m\u03b8\x1b[0m";    // Orange
    inline constexpr str_v C_PHI    = "\x1b[38;2;16;150;150m\u03d5\x1b[0m";    // Teal
    inline constexpr str_v C_LAMBDA = "\x1b[38;2;223;196;125m\u03bb\x1b[0m";  // Gold

    // Math symbols
    inline constexpr str_v SQRT    = "\u221a";    // √
    inline constexpr str_v APRX    = "\u2248";    // ≈

    // Subscripts
    inline constexpr str_v SB1 = "\u2081";         // ₁
    inline constexpr str_v SB2 = "\u2082";         // ₂
};

namespace Haversine{
    double deg2rad(double Deg, bool Printing = false){
        double var = PI / 180 * Deg;

        if (Printing){
            fmt::println("Deg = {}", Deg);
            fmt::println("Rad = {}", var);
        }

        return var;
    }

    double Hav_rad(double x, bool Printing = false){
        double Cos = 1 - cos(x);
        double Hav = Cos/2;

        if (Printing){
            fmt::println("~! x = {}{}", x, Symbols::Radian);
            fmt::println("~! cos(x) = {}", cos(x));
            fmt::println("~! 1-cos(x) = {}", Cos);
            fmt::println("~! Hav(x) = {}", Hav);
        }

        return Hav;
    }

    double Hav_deg(double x, bool Printing = false){
        x = deg2rad(x);

        double Cos = 1 - cos(x);
        double Hav = Cos/2;

        if (Printing){
            fmt::println("~! x = {}{}", x, Symbols::Degree);
            fmt::println("~! cos(x) = {}", cos(x));
            fmt::println("~! 1-cos(x) = {}", Cos);
            fmt::println("~! Hav(x) = {}", Hav);
        }

        return Hav;
    }

    double Hav(double x, Unit unit = Unit::Degree, bool Printing = false){
        if(unit == Unit::Degree){
            fmt::println("input x = {} {}", x, Symbols::Degree);
            x = deg2rad(x);
        } else { 
            fmt::println("input x = {} {}", x, Symbols::Radian);
        }
        
        double Cos = 1 - cos(x);
        double Hav = Cos/2;

        if (Printing){
            fmt::println("~! x = {}{}", x, Symbols::Degree);
            fmt::println("~! cos(x) = {}", cos(x));
            fmt::println("~! 1-cos(x) = {}", Cos);
            fmt::println("~! Hav(x) = {}", Hav);
        }

        return Hav;
    }
}

extern "C" __declspec(dllexport)
double Hav(double x, Unit unit = Unit::Degree, bool Printing = false)
{
    fmt::println("Hello from haversine in C++! Calling in C#");
    return Haversine::Hav(x, unit, Printing);
}
// Compile: clang++ -S -emit-llvm Hello.cpp -o Hello.ll -O3 && clang++ -shared -std=c++20 -o Hello.dll Hello.ll -fPIC