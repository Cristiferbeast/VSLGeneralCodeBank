#include <stdio.h>

int average (int arr [])
{
    int length = array_length(arr);
    int sum = 0;
    int average;
    for (int i = 0; i < length; i++)
    {
        sum += arr[i];
    }
    average = (int) sum / length;
    return average;
}
float average (int arr [])
{
    int length = array_length(arr);
    int sum = 0;
    float average;
    for (int i = 0; i < length; i++)
    {
        sum += arr[i];
    }
    average = (float) sum / length;
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
