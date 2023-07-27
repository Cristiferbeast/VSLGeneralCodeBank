float qRoot (float number)
{
    //This is the Doom Engine Quick Square Root.
    long i;
    float x2, y;
    
    x2 = number * 0.5F;
    y = number;
    i = * ( long *) &y;
    i = 0x5f3759df - ( i >> 1);
    y = * (float *) &i;
    y = y* (1.5F - (x2 * y * y));
}

long bitLongtoFloat(float number){
    //This Returns the Bit Result
    y = number;
    return * (long *) &y;
}

float bitLongtoFloat(long number){
    y = number;
    return *(float *) &y;
}