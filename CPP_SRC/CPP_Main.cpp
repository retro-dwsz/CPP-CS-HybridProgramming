// The main thing

#include <cmath>

#define CE extern "C" __declspec(dllexport);

CE
double Convert(double x){
    return x * 3.141592653589793/180;
}

