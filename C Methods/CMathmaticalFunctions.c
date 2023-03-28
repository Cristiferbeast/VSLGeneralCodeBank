#include <stdio.h>

double average (int arr[])
{
    int length = array_length(arr);
    int sum = 0;
    double average;
    for (int i = 0; i < length; i++)
    {
        sum += arr[i];
    }
    average = (double) sum / length;
    return average;
}

int array_length (int arr[])
{
    int length = sizeof(arr) / sizeof(arr[0]);
    return length;
}
void swap (int *num1, int *num2)
{
    int temp;
    temp = *num1;
    *num1 = *num2;
    *num2 = temp;
}
