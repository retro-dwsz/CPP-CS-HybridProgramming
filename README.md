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

OOP\_SRC/
├── Program.cs        # Main entry point
├── Location.cs       # Represents a coordinate (lat, lon)
├── Distance.cs       # Distance calculator (calls C++ backend)
├── Haversine.cs      # \[Replaced by native C++]
├── Symbols.cs        # Greek and math symbols
├── Misc.cs           # Terminal formatting, etc.
└── NativeInterop.cs  # DllImport for calling C++ functions

Native/
├── Includes.h        # Shared includes
├── Symbols.h         # Unicode + ANSI codes
├── Haversine.h       # C++ haversine functions (deg2rad, hav, etc)
├── interop.cpp       # Exported functions for C#
└── HaversineInterop.dll  # Compiled native DLL

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
clang++ -shared -std=c++23 -O3 -o HaversineInterop.dll interop.cpp -I. -fPIC
````

**With MSVC (Visual Studio Command Prompt):**

```bash
cl /LD interop.cpp /I. /O2 /FeHaversineInterop.dll
```

> Make sure to place the resulting `HaversineInterop.dll` in your C# project’s output folder (`bin/Debug/...`).

---

### 🧠 C# (Call from DLL)

Inside `NativeInterop.cs`:

```csharp
[DllImport("HaversineInterop.dll", CallingConvention = CallingConvention.Cdecl)]
public static extern double hav_deg(double angle);
```

Then call it in your app:

```csharp
double result = NativeInterop.hav_deg(60.0);
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
