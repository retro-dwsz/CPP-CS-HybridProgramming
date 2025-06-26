/*     CoffeeWrapper.cpp     */

#pragma once

#include "Coffee.h"
#include <string>

extern "C" CE inline Coffee* Coffee_Create(const char* Tag, const char* Owner, int Volume, int Temp){
    return new Coffee(Tag, Owner, Volume, Temp);
}
    
extern "C" CE inline void Coffee_Status(Coffee* obj){
    obj->Status();
}

extern "C" CE inline void Coffee_Drink(Coffee* obj, int Volume){
    obj->Drink(Volume);
}

/*   End CoffeeWrapper.cpp  */
/*~~~~~~~~~~~~~~~~~~~~~~~~~~*/
