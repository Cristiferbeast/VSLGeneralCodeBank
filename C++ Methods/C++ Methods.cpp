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
