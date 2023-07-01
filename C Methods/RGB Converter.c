//RBG Struct 
typedef struct {
    int red;
    int green;
    int blue;
} RGB;

//Manual Style
void rgbToHex(const RGB* rgb, char* hexcode) {
    sprintf(hexcode, "#%02x%02x%02x", rgb->red, rgb->green, rgb->blue);
}

//RGB Style
void rbgToHex (int red, int green, int blue, char* hexcode){
    sprintf(hexcode, "#%02x%02x%02x", red, green, blue);
}