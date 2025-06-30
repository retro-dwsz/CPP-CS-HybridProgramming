'''
Compile script for C++ src -> dll

Description:
 Compile C++ source into LLVM IR (.ll)
 Link LLVM IR into shared DLL (.dll)
 NO CMake. NO Makefile. JUST PYTHON. 🔥

Folders:
 ./CPP_SRC      // Base source code
 ./CPP_LL       // LLVM Intermediate Code
 ./CPP_DLL      // .dll compiled file

Files in ./CPP_SRC:
 Distance.h     // Finding distance calculator
 Haversine.h    // Haversine func stuffs
 Includes.h     // Includes needed for this
 Location.h     // Geographical Location object class
 main.cpp       // The main soup
 Misc.h         // Terminal and string utility
 Symbols.h      // Math, Greek, Unit symbols

Template:
 clang++ -S -emit-llvm $file.$extension -o $file.ll -O3
 clang++ -shared -std=c++23 -o $file.dll $file.ll -fPIC
'''

import os

# File list — only C++ source files, NOT headers!
cpp_files = [
    "Distance.cpp",
    "Haversine.cpp",
    "main.cpp",          # Optional, only if needed
    # Add more .cpp files
]

# Directories
SRC_DIR = "./CPP_SRC"
LL_DIR  = "./CPP_LL"
DLL_DIR = "./CPP_DLL"

def compile_to_llvm(src_file: str) -> str:
    """Compile .cpp to .ll (LLVM IR)"""
    base = os.path.splitext(src_file)[0]
    src_path = os.path.join(SRC_DIR, src_file)
    ll_path = os.path.join(LL_DIR, f"{base}.ll")

    print(f"🔧 Compiling to LLVM: {src_file} → {ll_path}")
    command = f"clang++ -S -emit-llvm \"{src_path}\" -o \"{ll_path}\" -O3"
    os.system(command)

    return ll_path

def compile_to_dll(ll_path: str) -> None:
    """Compile LLVM IR (.ll) to DLL"""
    base = os.path.splitext(os.path.basename(ll_path))[0]
    dll_path = os.path.join(DLL_DIR, f"{base}.dll")

    print(f"🔗 Linking to DLL: {ll_path} → {dll_path}")
    command = f"clang++ -shared \"{ll_path}\" -o \"{dll_path}\" -std=c++23 -fPIC"
    os.system(command)

def main() -> None:
    print("🔥 Starting hybrid DLL build...")

    for file in cpp_files:
        if not file.endswith(".cpp"):
            print(f"⚠️ Skipping non-cpp file: {file}")
            continue

        ll = compile_to_llvm(file)
        compile_to_dll(ll)

    print("✅ Done building all DLLs!")

if __name__ == "__main__":
    main()

r'''
03:30 ~.\Hybrid Programming [28ms]
~$ dir

    Directory: D:\Code\!Docs\Obsolete Trig\Hybrid Programming

Mode                 LastWriteTime         Length Name
----                 -------------         ------ ----
d----          29/06/2025    01.33                .idea
d----          29/06/2025    21.30                .vscode
d----          01/07/2025    03.08                CPP_BC
d----          26/06/2025    01.01                CPP_SRC
d----          01/07/2025    02.57                CS_Compiled
d----          01/07/2025    02.58                CS_Compiled_LINUX
d----          29/06/2025    22.08                CS_SRC
d----          01/07/2025    02.58                obj
d----          29/06/2025    01.22                test
-a---          01/07/2025    02.39            472 .gitignore
-a---          27/06/2025    01.11        1277952 Coffee.dll
-a---          24/06/2025    00.08           2229 compile.py
-a---          29/06/2025    21.36          16016 CPP_Main_LINUX.dll
-a---          01/07/2025    03.08          69632 CPP_Main_X64.dll
-a---          01/07/2025    03.08          60416 CPP_Main_X86.dll
-a---          29/06/2025    01.05          69632 CPP_Main.dll
-a---          01/07/2025    02.57           3442 CSCPP-HavDistance.csproj
-a---          23/06/2025    01.24           1128 Hybrid Programming.sln
-a---          23/06/2025    00.58           1093 LICENSE
-a---          01/07/2025    00.35          32075 Program.cs
-a---          29/06/2025    01.25           3502 README.md
-a---          24/06/2025    20.21         326995 test.zip


03:30 ~.\Hybrid Programming [9ms]
~$ Get-ChildItem -Recurse | Measure-Object -Sum Length

Count             : 920
Average           :
Sum               : 345668499
Maximum           :
Minimum           :
StandardDeviation :
Property          : Length


03:30 ~.\Hybrid Programming [20ms]
~$ getsize
Total size: 329,7 MiB

03:30 ~.\Hybrid Programming [41ms]
~$
'''