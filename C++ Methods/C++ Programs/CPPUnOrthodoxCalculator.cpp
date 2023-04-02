#include <iostream>
#include <string>

using namespace std;

string toLowercase(string inputString) {
	for (char& c : inputString) {
		c = std::tolower(c);
	}
	return inputString;
}
void wait_for_enter() {
	std::string line;
	std::getline(std::cin, line);
	std::cin.clear();
}
int getInteger() {
	int num;
	std::string input;
	bool isValid = false;

	while (!isValid) {
		std::getline(std::cin, input);

		try {
			num = std::stoi(input);
			isValid = true;
		}
		catch (const std::invalid_argument& e) {
			std::cout << "Invalid input. Please enter an integer." << std::endl;
			std::cin.clear();
			std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
		}
	}
	return num;
}

int main() {
	cout << "Welcome to the C++ Calculator Program, This is a Calculator Designed by VSL for use in Unorthodox Mathmatical Expressions" << endl << "Please Enter A Command, For List of Commands type help" << endl;
	
Start:
	string input;
	cin >> input;
	input = toLowercase(input);
	if (input == "help")
	{
		cout << "This Version of the C++ Calculator Supports the following functions" << endl;
		cout << "Pixel Converter: Convert from Pixels to actual measurments" << endl; 
		wait_for_enter;
		goto Start;
	}
	if ((input == "pixel converter") || (input == "pixel"))
	{
		string object;
		cout << "Welcome to the Pixel Converter, In order to covert from ingame Pixels to Real Measurements" << endl;
		cout << "To use first enter the object you are using as a pixel base" << endl;
		cin >> object;
		object = toLowercase(object);
		if (object == "elster")
		{
			int reference = 178;
			cout << "please enter the relative pixel height of elster that you found";
			int pixel = getInteger();
			float conversion = reference / pixel;
			cout << "This measurement in question has a conversion rate of" << conversion << "cm per pixel";
			goto Start;
		}
		if (object == "leon")
		{
			int reference = 180;
			cout << "please enter the relative pixel height of leon that you found";
			int pixel = getInteger();
			float conversion = reference / pixel;
			cout << "This measurement in question has a conversion rate of" << conversion << "cm per pixel";
			goto Start;
		}
		else
		{
			cout << "Object not recognized, in order for this program to convert please enter a reference set for us to use" << endl << "Please enter the ingame measured pixel height" << endl;
			int pixel = getInteger();
			cout << "Please now enter the lore height of that item that you measured without the size marker" << endl;
			int reference = getInteger();
			float conversion = reference / pixel;
			cout << "The game in question has a conversion rate of" << conversion << "of the reletive unit per pixel";
			goto Start;
		}
	}
	if (input == "exit")
	{
		return 0;
	}
	return 0;
}