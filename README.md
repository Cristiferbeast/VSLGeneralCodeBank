# VSLCodeBank
A Collection of Methods Written for Ease of Programming by VSL
VSL has created a custom code bank for use in Signalis, this code bank can help with using methods that are easier to reference then doing the command normally through C#.

**TEXTURE FIND**
This Method returns the texture of an object, and can be invoked with the following,
*SignalisCodeBank.TextureFind(GameObject)* 
The code by which the Method runs results in a easier accessibility of the method for newer programmers, as well as reducing the number of lines required to write it from 3 to 1 which can help make large programs which use lots of texture calls run more efficiently. \
TextureFind is used heavily within the SURS Database to write easier calls. If you are writing an add on for SURS from base please use the TextureFind Method to ensure compatibility and readability of your code.

**SURS IMAGE CALL**
SURSImageCall is a method where one can input a filename as a string and if that file exists within the SURS Library it will convert the file into a 2D Texture. This is the Method that SURS is based around and all SURS Extensions use. When writing a SURS Extension be sure to use this method to ensure compatibility and readability of your code.
