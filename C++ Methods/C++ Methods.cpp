#include <iostream>
using namespace std;

namespace VSLCodeBankCPP
{
    string tolower(string inputString) 
    {
	    for (char& c : inputString) {
		    c = std::tolower(c);
	    }
	    return inputString;
    }
    class Stat{
        static float CertainityRange(float participants, float percentage)
        {
		float temp;
		temp = 1-percentage;
		temp *= percentage/100;
		temp /= sqrt(percentage);
		temp *= 1.96f;
		return temp;
	}
    }
;}
