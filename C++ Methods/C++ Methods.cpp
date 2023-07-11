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
        	double a = 1.0, b = 0.0, c = 0.0;
        	char x, equal;

	        if (iss.peek() == 'x') {
    	        x = 'x';
        	    equal = '=';
            	iss >> x >> equal >> b >> equal >> c;
	        } else {
    	        iss >> a >> x >> equal >> b >> equal >> c;
        	}

	        // Handle the case where there is no coefficient for x
    	    if (a == 0.0) {
        	    if (b == 0.0) {
            	    // Invalid equation: no solution
                	throw std::invalid_argument("Invalid equation");
	            } else {
    	            // Invalid equation: infinite solutions
        	        throw std::invalid_argument("Infinite solutions");
            	}
	        }

    	    // Calculate and return the solution
        	return (c - b) / a;
    	}
	double findSlope(const std::string& equation) {
        	std::istringstream iss(equation);
        	double a = 1.0, b = 0.0, c = 0.0;
        	char x, y, equal;

        	if (iss.peek() == 'x') {
            		x = 'x';
            		y = 'y';
            		equal = '=';
            	iss >> x >> equal >> b >> y >> equal >> c;
        	} else {
            	iss >> a >> x >> equal >> b >> y >> equal >> c;
        	}

        	// Handle the case where there is no coefficient for y
        	if (b == 0.0) {
            	throw std::invalid_argument("Invalid equation");
        	}

        	// Calculate and return the slope
        	return -a / b;
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
