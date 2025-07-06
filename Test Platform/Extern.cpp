/**
 * 🔧 FÖR WINDOWN~LINUX TEST : Compile DLL for Windows & Linux from C++ (Extern.cpp)
 * 
 * 🧪 Windows:
 * ┌── x64:
 * │   <COMPILER> -shared -o Extern_WIN.x64.dll Extern.cpp -static -fPIC -std=c++23 -O3 -m64
 * ├── x86:
 * │   <COMPILER> -shared -o Extern_WIN.x86.dll Extern.cpp -static -fPIC -std=c++23 -O3 -m32 -I"./include"
 * ├── ARM (32-bit):
 * │   <COMPILER> -shared -o Extern_WIN.ARM.dll Extern.cpp -static -fPIC -std=c++23 -O3 -march=armv7a
 * └── ARM64:
 *     <COMPILER> -shared -o Extern_WIN.ARM64.dll Extern.cpp -static -fPIC -std=c++23 -O3 -march=armv8-a

 * 🐧 Linux:
 * ┌── x64:
 * │   <COMPILER> -shared -o Extern_LINUX.X64.so Extern.cpp -fPIC -std=c++23 -O3 -m64 -static
 * ├── x86:
 * │   <COMPILER> -shared -o Extern_LINUX.X86.so Extern.cpp -fPIC -std=c++23 -O3 -m32 -static -I"./include"
 * ├── ARM (32-bit):
 * │   <COMPILER> -shared -o Extern_LINUX.ARM.so Extern.cpp -fPIC -std=c++23 -O3 -march=armv7a -static
 * └── ARM64:
 *     <COMPILER> -shared -o Extern_LINUX.ARM64.so Extern.cpp -fPIC -std=c++23 -O3 -march=armv8-a -static

 * 💡 Notes:
 * - Use `clang++` or `g++` full version for multi-arch support
 * - Use `-static` to make sure everything is included
 * - For build cross-platform, use cross-compiler or Docker or use VM
 * 
 * 📦 Output:
 * - Windows: .dll
 * - Linux:   .so
 */

#include <cmath>
#include <fmt/format.h>
#include <stdio.h>

#if defined(_WIN32)
    #define CE extern "C" __declspec(dllexport)
#elif defined(__linux__)
    #define CE extern "C"
#endif

constexpr double PI = 3.141592653589793;
constexpr int R  = 6371;

CE
void __TEST__(){
    printf("%s", fmt::format("Hello, world!").c_str());
}

CE
double convert(double x){
    return x * PI/180;
}

CE
double Hav_rad(double x){   // Haversine för Radian
    return (1-cos(x))/2;
}

CE
double Hav_deg(double x){   // Haversine för degree
    return Hav_rad(convert(x));
}

// Distance för Radian
CE
double Distance_rad(double latA, double lonA, double latB, double lonB){
    double lat1 = latA;
    double lon1 = lonA;
    double lat2 = latB;
    double lon2 = lonB;
    
    double Dlat = lat2 - lat1;
    double Dlon = lon2 - lon1;
    
    double hav1 = Hav_rad(Dlat);
    double hav2 = Hav_rad(Dlon);
    double cos1 = std::cos(lat1);
    double cos2 = std::cos(lat2);
    
    double Hav = hav1 + cos1 * cos2 * hav2;
    double T = 2 * std::asin(std::sqrt(Hav));
    double D = R * T;
    
    return D;
}

// Distance för Degree
CE
double Distance_Deg(double latA, double lonA, double latB, double lonB){
    double lat1 = latA;
    double lon1 = lonA;
    double lat2 = latB;
    double lon2 = lonB;
    
    double Dlat = lat2 - lat1;
    double Dlon = lon2 - lon1;
    
    double hav1 = Hav_deg(Dlat);
    double hav2 = Hav_deg(Dlon);
    double cos1 = std::cos(convert(lat1));
    double cos2 = std::cos(convert(lat2));
    
    double Hav  = hav1 + cos1 * cos2 * hav2;
    double T    = 2 * std::asin(std::sqrt(Hav));
    double D    = R * T;

    return D;
}