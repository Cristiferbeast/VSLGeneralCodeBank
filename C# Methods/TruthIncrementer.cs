using System;

class Program {
    static void Main(string[] args) {
        int yes = 0;
        int no = 0;

        while (true) {
            Console.WriteLine("Enter 'yes', 'no', 'results', or 'end': ");
            string input = Console.ReadLine();

            if (input == "yes") {
                yes++;
            }
            else if (input == "no") {
                no++;
            }
            else if (input == "results") {
                int total = yes + no;
                if (total == 0) {
                    Console.WriteLine("No votes have been entered yet.");
                }
                else {
                    double percentage = (double)yes / total * 100;
                    Console.WriteLine("Yes: " + yes);
                    Console.WriteLine("No: " + no);
                    Console.WriteLine("Percentage of yes votes: " + percentage.ToString("0.00") + "%");
                }
            }
            else if (input == "end") {
                break;
            }
            else {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }
    }
}
This program initializes two integer variables, yes and no, to 0. It then enters an infinite loop that repeatedly prompts the user to enter one of four possible inputs: "yes", "no", "results", or "end".

If the user enters "yes", the program increments the yes variable by



