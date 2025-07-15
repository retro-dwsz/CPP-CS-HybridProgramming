/**
 * 🔧 FÖR WINDOWN~LINUX TEST : Compile DLL for Windows & Linux from C++
 (Extern.cpp)
 *
 * 🧪 Windows:
 * ┌─ x64:
 * ├── clang++ -shared -o Extern_WIN.x64.dll Extern.cpp -static -fPIC -std=c++23 -O3 -m64 -I"./include" -L"./include/lib-fmt-x64-win" -lfmt
 * │
 * ├─ x86:
 * └── clang++ -shared -o Extern_WIN.x86.dll Extern.cpp -static -fPIC -std=c++23 -O3 -m32 -I"./include" -L"./include/lib-fmt-x86-win" -lfmt

 * 🐧 Linux:
 * ┌─ x64:
 * ├── clang++ -c -o Extern_LINUX.x64.a Extern.cpp -fPIC -std=c++23 -O3 -m64 -static -I"./include" -L"./include/lib-fmt-x64-linux" -lfmt
 * ├── clang++ -shared -o Extern_LINUX.x64.so Extern.cpp -fPIC -std=c++23 -O3 -m64 -I"./include" -L"./include/lib-fmt-x64-linux" -lfmt
 * │
 * ├─ x86:
 * ├── clang++ -c -o Extern_LINUX.x86.a Extern.cpp -fPIC -std=c++23 -O3 -m32 -static -I"./include" -L"./include/lib-fmt-x86-linux" -lfmt
 * └── clang++ -shared -o Extern_LINUX.x86.so Extern.cpp -fPIC -std=c++23 -O3 -m32 -I"./include" -L"./include/lib-fmt-x86-linux" -lfmt

 Others
 * ├─ ARCH/OS :
 * └── <COMPILER> -shared -o Extern_<OS>.<ARCH>.<EXT> Extern.cpp -fPIC -std=c++23 -O3 -m32 -static -I"./include" -L"./include/lib-fmt-<ARCH>-<OS>" -lfmt

 * 💡 Notes:
 * - Use `clang++` or `g++` full version for multi-arch support
 * - Use `-static` to make sure everything is included
 * - For build cross-platform, use cross-compiler or Docker or use VM
 *
 * 📦 Output:
 * - Windows: .dll
 * - Linux:   .so (dynamic) or .a (static)
 */

#include <cmath>
#include <fmt/format.h>
#include <stdio.h>

// #define FMT_HEADER_ONLY

#if defined(_WIN32)
  #define CE extern "C" __declspec(dllexport)
#elif defined(__linux__)
  #define CE extern "C"
#endif

constexpr double PI = 3.141592653589793;
constexpr int R = 6371;

CE void __TEST__() {
    printf("%s\n~", fmt::format("Cześć! Hello, world!").c_str());
}

CE double convert(double x) {
    return x * PI / 180;
}

CE double Hav_rad(double x) { // Haversine för Radian
    return (1 - cos(x)) / 2;
}

CE double Hav_deg(double x) { // Haversine för degree
    return Hav_rad(convert(x));
}

// Distance för Radian
CE double Distance_Rad(double latA, double lonA, double latB, double lonB) {
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
    double T = 2 * std::atan2(std::sqrt(Hav), std::sqrt(1 - Hav));
    double D = R * T;

    return D;
}

// Distance för Degree
CE double Distance_Deg(double latA, double lonA, double latB, double lonB) {
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

    double Hav = hav1 + cos1 * cos2 * hav2;
    double T = 2 * std::asin(std::sqrt(Hav));
    double D = R * T;

    return D;
}