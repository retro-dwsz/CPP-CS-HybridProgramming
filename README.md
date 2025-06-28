# CPPnCS-Hybrid
Belajar hybrid-programming C# dan C++ dengan Haversine


# 🌍 Fancy Haversine Distance Calculator (C# + C++ Hybrid)

This project is a hybrid-powered **Haversine calculator** built with:

- 💻 **C#** → for the OOP structure, terminal output, and clean logic
- ⚙️ **C++** → for math-heavy functions like `Haversine::Hav_deg()` and `calculate_distance()` to boost performance

We're blending the beauty of **.NET** and the raw speed of **C++** using `DllImport`.

---

## 📁 Project Structure

```
.                     # C# files (flatted)
├── Program.cs          # Main entry point
├── Location.cs         # Represents a coordinate (lat, lon)
├── Distance.cs         # Distance calculator (calls C++ backend)
├── Haversine.cs        # \[Replaced by native C++]
├── Symbols.cs          # Greek and math symbols
├── Misc.cs             # Terminal formatting, etc.
└── NativeInterop.cs    # DllImport for calling C++ functions

.\test                # Testing files
├── Program_test.cs     # Testing för Main entry point
├── Hello.cpp           # Testing för Represents a coordinate (lat, lon)
├── Hello.ll            # Compiled to LLVM Intermediate Level
└── Hello.dll           # Comepiled thing

.\SRC_CPP             # C++ Files
├── Distance.h 
├── Haversine.h           # C++ haversine functions (deg2rad, hav, etc)
├── Includes.h            # Shared includes
├── Location.h            # Location object stuffs
├── Main.cpp              # Main file
├── Misc.h                # Greek and math symbols
└── Symbols.h             # Unicode + ANSI codes

````

---

## 🧪 Features

- 🌐 Convert degrees to radians
- 📏 Calculate Haversine value (in degrees or radians)
- 🧠 Move heavy calculations to C++ for better performance
- 📦 Pure DLL-based interop (no C++/CLI, no COM hell)

---

## 🛠️ Build Instructions

### 🧩 C++ (DLL Build)

**With Clang (recommended):**
```bash
clang++ -shared -o CPP_Main.dll .\CPP_SRC\CPP_Main.cpp -O3 -static -fPIC
````

**With MSVC (Visual Studio Command Prompt):**

```bash
cl /LD CPP_Main.cpp /I. /O2 /FeCPP_Main.dll
```

> Make sure to place the resulting `CPP_Main.dll` in your C# project’s output folder (`bin/Debug/...`).

---

### 🧠 C# (Call from DLL)

Inside `Program.cs`:

```csharp
[DllImport("CPP_Main.dll", CallingConvention = CallingConvention.Cdecl)]
public static extern double hav_deg(double angle);
```

Then call it in your app:

```csharp
double result = hav_deg(60.0);
Console.WriteLine($"Hav(60°) = {result}");
```

---

## ⚠️ Gotchas

* Make sure **architecture matches** (x64 vs x86)
* Don't use C++ `std::string`, `fmt`, or classes directly through interop — keep exported functions `extern "C"` and C-style
* If you use `fmt::println()` in C++, make sure `fmt` is linked properly (or comment it out during interop)

---

## 🚀 Future Ideas

* Export full `calculate_distance(lat1, lon1, lat2, lon2)`
* Benchmark `C# only` vs `C# + C++ hybrid`
* Create a GUI (e.g., WinForms/WPF) for interactive geo distance calculator
* Add multi-threaded batch distance calculations in C++

---

## 💬 Credits

Built with caffeine, a love for both high-level structure and low-level control, and pure curiosity for hybrid programming.

---

## 🔗 License

MIT

---
