#include <fmt/format.h>
#include <fmt/core.h>

extern "C" __declspec(dllexport)

void Hello()
{
    fmt::println("Hello, fmt!");
    fmt::println("{:-^80}", "[Border!]");
}

namespace Hav{
    
}