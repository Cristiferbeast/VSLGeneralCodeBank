string tolower(string inputString) {
	for (char& c : inputString) {
		c = std::tolower(c);
	}
	return inputString;
}
void waitenter() {
	std::string line;
	std::getline(std::cin, line);
	std::cin.clear();
}
int getInt() {
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
static float CertainityRange(float participants, float percentage)
{
    float temp;
    temp = 1-percentage;
    float temp3 = percentage/100; 
    temp *= temp3;
    float temp2; 
    temp2 = sqrt(percentage);
    temp /= temp2;
    temp *= 1.96f;
    return temp; 
}
