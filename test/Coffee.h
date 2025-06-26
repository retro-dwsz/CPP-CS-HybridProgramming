/*         Coffee.h         */

#pragma once

#include <string.h>
#include <stdio.h>
#include <fmt/format.h>

#define CE __declspec(dllexport)

enum class State{
    VeryHot,    // 75-90
    Hot,        // 51-74
    Warm,       // 27-50
    Base,       // 17-26
    Cold,       //  6-16
    Freezing    //  0-5
};

inline State GetState(int Temp){
    int LocalTemp;
    if(Temp > 100 || Temp < 0){
        printf("Warning, coffee with tempurature over 100°C or below 0°C will be rounded to the closest bound");
    }
    if(Temp > 100){
        LocalTemp = 100;
    } else if(Temp < 0){
        LocalTemp = 0;
    } else {
        LocalTemp = Temp;
    };

    if(LocalTemp >= 75 && LocalTemp <= 90){
        return State::VeryHot;
    } else if(LocalTemp >= 51 && LocalTemp <= 74) {
        return State::Hot;
    } else if(LocalTemp >= 27 && LocalTemp <= 50){
        return State::Warm;
    } else if(LocalTemp >= 17 && LocalTemp <= 26){
        return State::Base;
    } else if(LocalTemp >= 6 && LocalTemp <= 16){
        return State::Cold;
    } else if(LocalTemp >= 0 && LocalTemp <= 5){
        return State::Freezing;
    } else{
        return State::Base;
    }
}

inline const char* StateToStr(State s) {
    switch(s) {
        case State::VeryHot: return "VeryHot";
        case State::Hot: return "Hot";
        case State::Warm: return "Warm";
        case State::Base: return "Base";
        case State::Cold: return "Cold";
        case State::Freezing: return "Freezing";
        default: return "Unknown";
    }
}

class Coffee{
    public:
    const char* Tag;    // Coffee Name
    const char* Owner;  // Coffee Owner
    int Volume;         // Coffee Volume
    int Temp;           // Coffee Tempurature
    State state;        // Coffee state

    Coffee(const char* Tag, const char* Owner, int Volume, int Temp){
        this->Tag = Tag;
        this->Owner = Owner;
        this->Volume = Volume;
        
        if(Temp > 100 || Temp < 0){
            printf("Warning, coffee with tempurature over 100°C or below 0°C will be rounded to the closest bound");
        }

        if(Temp > 100){
            this->Temp = 100;
        } else if(Temp < 0){
            this->Temp = 0;
        } else {
            this->Temp = Temp;
        };

        this->state = GetState(this->Temp);
    }

    void Status();
    // {
    //     printf(
    //         fmt::format(
    //             "Coffee name: {}\nAvailable coffee: {} ml\nCoffee status: {}",
    //             this->Tag, this->Volume, this->state
    //         ).c_str()
    //     );
    // }

    void Drink(int Volume);
    // {
    //     if (Volume > this->Volume){
    //         printf(fmt::format("Can't drink more than available volume ({} ml)", this->Volume).c_str());
    //     } else {
    //         printf(fmt::format("Drinking {} ml ...", Volume).c_str());
    //         this->Volume -= Volume;
    //         printf(fmt::format("{} ml left!").c_str());
    //     }
    // }
};

/*       End Coffee.h       */
/*~~~~~~~~~~~~~~~~~~~~~~~~~~*/
