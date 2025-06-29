// The main thing

/**
 * Compile with the following arguments of Clang or GCC
 * Windows  clang++ -shared -o CPP_Main.dll ./CPP_SRC/CPP_Main.cpp -O3 -fPIC
 * Linux    clang++ -shared -o CPP_Main_LINUX.dll ./CPP_SRC/CPP_Main.cpp -O3 -fms-extensions -fPIC
 * 
 * On windows it should be around 69.632 Bytes
 * On other platform, maybe it's the same?
 * 
 * NOTE:
 * - Use CPP_<fn> to distinguisch CPP function and CS function 
 * - Clang is reccomended, but GCC is OK
 * - This code was originally made in Windows OS,
 *   if you find anything incompatible for other OSes (like Linux and MacOS),
 *   please tell me, or if you want, you can fork this so this can be Linux compatible
 *   and/or MacOS compatible, or anything else.
 * - Use SEPERATOR to "seperate" function sections, because C is old,
 *   and "namespace" is not avalable because it's C. Yes it's CPP, but it's just the skin
 * - Please ingore the error on the CE shortcut, adding ";" will break the ENTIRE code
*/

#include <stdio.h>
#include <cmath>

#define SEPERATOR /* ~ ~ ~ ~ ~ ~ ~ ~ */

#if defined(_WIN32)
    #define CE extern "C" __declspec(dllexport)
#elif defined(__linux__)
    #define CE extern "C" 
#endif


constexpr double PI = 3.141592653589793;

/******         Basic functions          ******/

/* fn: Degree~Radian converter */
CE
double CPP_Convert(double x){
    return x * PI/180;
}
/* End fn */

/* fn: Versed-sine function */
CE
double CPP_Ver(double x){
    return 1 - cos(x);
}
/* End fn */

/* fn: Halv Versed-sine function (Radian) */
CE
double CPP_Hav(double x, bool Printing){
    double Cos = CPP_Ver(x);
    double hHav = Cos/2;
    
    if (Printing)
    {        
        printf("~! x = %f RAD\n", x);
        printf("~! cos(x) = %f\n", cos(x));
        printf("~! 1-cos(x) = %f\n", Cos);
        printf("~! Hav(x) = %f\n", hHav);
    } 

    return hHav;
}
/* End fn */

/* fn: Halv Versed-sine function (Degree) */
CE
double CPP_HavDeg(double x, bool Printing){
    return CPP_Hav(CPP_Convert(x), Printing);
}
/* End fn */

/******       End Basic functions        ******/

SEPERATOR

/***** *  Distance Haversine functions  * *****/

CE
double CPP_DHav(double HAV_dlat, double COS_lon1, double COS_lon2, double HAV_dlon){
    return HAV_dlat + COS_lon1 * COS_lon2 * HAV_dlon;
}

CE
double CPP_Theta(double Hav, bool isRadian = false){
    if(isRadian){
        return 2 * atan2(sqrt(Hav), sqrt(1 - Hav));
    } else {
        return 2 * asin(sqrt(Hav));
    }
}

CE 
double CPP_DistanceT(double T){
    return 6371.2 * T;
}

CE 
double CPP_Distance(double Hav, bool isRadian = false){
    return 6371.2 * CPP_Theta(Hav, isRadian);
}

/***** *  End Distance Haversine functions  * *****/

SEPERATOR

/***** *  Raw string functions  * *****/
#include <stdio.h>
#include <stdint.h>
#include <string.h>

CE
long long int CPP_GetUTF8Codepoint(const char* text) {
    // printf("%d chars detected!", strlen(text));
    const unsigned char* u = (const unsigned char*)text;
    long long int cp = 0;

    if (u[0] < 0x80) {
        cp = u[0];
    } else if ((u[0] & 0xE0) == 0xC0) {
        cp = ((u[0] & 0x1F) << 6) | (u[1] & 0x3F);
    } else if ((u[0] & 0xF0) == 0xE0) {
        cp = ((u[0] & 0x0F) << 12) | ((u[1] & 0x3F) << 6) | (u[2] & 0x3F);
    } else if ((u[0] & 0xF8) == 0xF0) {
        cp = ((u[0] & 0x07) << 18) | ((u[1] & 0x3F) << 12) |
             ((u[2] & 0x3F) << 6) | (u[3] & 0x3F);
    }

    return cp;
}

CE
void CPP_RawUTF8Print(const char* text) {
    const unsigned char* u = (const unsigned char*)text;
    // printf("UTF-8 Codepoints (%d char(s)):\n", strlen(text));
    printf("UTF-8 Codepoints:\n");

    while (*u) {
        int bytes = 1;
        if ((u[0] & 0x80) == 0x00)       bytes = 1;
        else if ((u[0] & 0xE0) == 0xC0)  bytes = 2;
        else if ((u[0] & 0xF0) == 0xE0)  bytes = 3;
        else if ((u[0] & 0xF8) == 0xF0)  bytes = 4;

        long long cp = CPP_GetUTF8Codepoint((const char*)u);
        printf("%.*s \t U+%04llX\n", bytes, u, cp);

        u += bytes;
    }
}
/***** *  End Raw string functions  * *****/

