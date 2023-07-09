#include <iostream>
using namespace std;

namespace VSLCodeBankCPP
{
    class StringManipulation{
        static string tolower(string inputString) 
        {
	        for (char& c : inputString) {
		        c = std::tolower(c);
	        }
	        return inputString;
        }
		static string ReverseString(const string& input)
		{
            string reversedString = input;
            reverse(reversedString.begin(), reversedString.end());
            return reversedString;
		}
    }
    class Stat{
        static float CertainityRange(float participants, float percentage)
        {
		    float temp;
		    temp = 1-percentage;
		    temp *= percentage/100;
		    temp /= sqrt(participants);
		    temp *= 1.96f;
		    return temp;
	    }
    }
    class Algebra{
        public:
        double solveLinearEquation(const std::string& equation) {
            std::istringstream iss(equation);
            double a, b, c;
            char x, equal;
            iss >> a >> x >> equal >> b >> c;
            return (c - b) / a;
        }
    };

    class Conversions{
        static int tempC(int F)
        {
            F -= 32;
            F *= (5/9);
            return F;
        }
        static int tempF(int C)
        {
            C *= (9/5);
            C += 32;
            return C;
        }
        static float UStoLei(float US)
        {
            return US *= 4.32;
        }
        static float LeitoUS(float Lei)
        {
            return Lei /= 4.32;
        }
    };
;}
