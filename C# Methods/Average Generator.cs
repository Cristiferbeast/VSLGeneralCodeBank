using System;

class Average
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Enter a sequence of numbers separated by spaces (or \"quit\" to exit):");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                break; // exit the loop if the user enters "quit"
            }
            string[] numberStrings = input.Split(' '); // split the input into individual numbers
            double[] numbers = new double[numberStrings.Length]; // create an array to hold the numbers
            int count = 0; // current number of elements in the array

            for (int i = 0; i < numberStrings.Length; i++)
            {
                double number;
                if (double.TryParse(numberStrings[i], out number))
                {
                    // the string is a valid number, so add it to the array
                    numbers[count] = number;
                    count++;
                }
            }

            if (count == 0)
            {
                Console.WriteLine("No numbers were entered.");
            }
            else
            {
                double sum = 0;
                for (int i = 0; i < count; i++)
                {
                    sum += numbers[i];
                }
                double average = sum / count;
                Console.WriteLine("The average is: " + average);
            }
        }
    }
}
