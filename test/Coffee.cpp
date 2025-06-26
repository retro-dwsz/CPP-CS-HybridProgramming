/*        Coffee.cpp        */

#pragma once

#include "Coffee.h"
#include <string>

Coffee* Coffee_Create(const char* Tag, const char* Owner, int Volume, int Temp){
    return new Coffee(Tag,Owner, Volume, Temp);
}

void Coffee::Status() {
    std::string Content = fmt::format(
        "Coffee name: {}\nAvailable coffee: {} ml\nCoffee status: {}",
        this->Tag, this->Volume, StateToStr(this->state)
    );
    printf("%s", Content.c_str());
}

void Coffee::Drink(int Volume){
    std::string Content;
    if (Volume > this->Volume){
        Content = fmt::format("Can't drink more than available volume ({} ml)", this->Volume);
        printf("%s", Content.c_str());
    } else {
        Content = fmt::format("Drinking {} ml ...", Volume);
        printf("%s", Content.c_str());

        this->Volume -= Volume;
        
        Content = fmt::format("{} ml left!", this->Volume);
        printf("%s", Content.c_str());
    }
}
/*      End Coffee.cpp      */
/*~~~~~~~~~~~~~~~~~~~~~~~~~~*/
