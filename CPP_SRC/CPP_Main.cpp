// The main thing

#include <cmath>
#define CE extern "C" __declspec(dllexport)

constexpr double PI = 3.141592653589793;

/****** Basic functions ******/

CE
/* fn: Degree~Radian converter */
double Convert(double x){
    return x * PI/180;
}
/* End fn */

CE
/* fn: Versed-sine function */
double Ver(double x){
    return 1 - cos(x);
}
/* End fn */

CE
/* fn: Halv Versed-sine function */
double Hav(double x){
    return (Ver(x))/2;
}
/* End fn */
/****** End Basic functions ******/

/****** Distance Haversine functions ******/

CE
double DHav(double dlat, double lon1, double lon2, double dlon){
    return dlat + lon1 + lon2 + dlon;
}

CE
double Theta(double Hav, bool isRadian = false){
    if(isRadian){
        return 2 * atan2(sqrt(Hav), sqrt(1 - Hav));
    } else {
        return 2 * asin(sqrt(Hav));
    }
}

CE 
double Distance(double Hav, bool isRadian = false){
    return 6371.2 * Theta(Hav, isRadian);
}

/****** End Distance Haversine functions ******/

/****** Raw string functions ******/
#include <stdio.h>
#include <stdint.h>
#include <string.h>

CE
long long int GetUTF8Codepoint(const char* text) {
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
void RawUTF8Print(const char* text) {
    const unsigned char* u = (const unsigned char*)text;
    // printf("UTF-8 Codepoints (%d char(s)):\n", strlen(text));
    printf("UTF-8 Codepoints:\n");

    while (*u) {
        int bytes = 1;
        if ((u[0] & 0x80) == 0x00)       bytes = 1;
        else if ((u[0] & 0xE0) == 0xC0)  bytes = 2;
        else if ((u[0] & 0xF0) == 0xE0)  bytes = 3;
        else if ((u[0] & 0xF8) == 0xF0)  bytes = 4;

        long long cp = GetUTF8Codepoint((const char*)u);
        printf("%.*s \t U+%04llX\n", bytes, u, cp);

        u += bytes;
    }
}
/****** End Raw string functions ******/

