#include <iostream>
#include <iomanip>
#include <sstream>
#include <string>

std::string rgbToHex(int red, int green, int blue) {
    std::stringstream stream;
    stream << "#" << std::setfill('0') << std::setw(2) << std::hex << red
           << std::setw(2) << std::hex << green
           << std::setw(2) << std::hex << blue;
    return stream.str();
}

class RGB {
    public:
        RGB(int red, int green, int blue) : red(red), green(green), blue(blue) {}
        int getRed() const { return red; }
        int getGreen() const { return green; }
        int getBlue() const { return blue; }
    private:
        int red;
        int green;
        int blue;
};

std::string rgbToHex(const RGB& rgb) {
    std::stringstream stream;
    stream << "#" << std::setfill('0') << std::setw(2) << std::hex << rgb.getRed()
           << std::setw(2) << std::hex << rgb.getGreen()
           << std::setw(2) << std::hex << rgb.getBlue();
    return stream.str();
}