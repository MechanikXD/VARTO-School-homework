using System;

namespace HomeworkSolution {
    using System.Globalization;
    using System.Linq;

    // Homework for lecture 2 (01.05)
    public class Homework2Solutions {
        // Function to read specific amount of numbers from console
        public static double[] ReadNumbersFromConsole(int amountOfNumbers) {
            // Read user input, check for null and split by whitespace
            string[] userInput = (Console.ReadLine() ?? string.Empty).Split(' ');
            var numbersArray = new double[amountOfNumbers];
            for (var index = 0; index < amountOfNumbers; index++) {
                try {
                    numbersArray[index] = double.Parse(userInput[index], 
                        NumberStyles.Any, CultureInfo.InvariantCulture);
                }
                catch (IndexOutOfRangeException) { // replace missing numbers with zeros
                    numbersArray[index] = 0;
                }
                catch (FormatException) { // Ask again for input
                    Console.Write("One of numbers in incorrect format, try again: ");
                    while (true) {
                        if (!double.TryParse(Console.ReadLine(), out var newNumber)) {
                            continue;
                        }

                        numbersArray[index] = newNumber;
                        break;
                    }
                }
            }

            return numbersArray;
        }
        
        public static void Pow2FromConsole() {
            Console.Write("Enter your number: ");
            double number = ReadNumbersFromConsole(1)[0];
            Console.WriteLine($"Your number in power of 2 = {number * number}");
        }
        
        public static void SwapNamesFromConsole() {
            Console.Write("Enter your name and surname: ");
            // Read user input, check for null and split by whitespace -> [name, surname]
            string[] userInput = (Console.ReadLine() ?? string.Empty).Split(' ');
            string name, surname;
            try {
                name = userInput[0];
                surname = userInput[1];
            }
            catch (IndexOutOfRangeException) {
                Console.WriteLine("No surname found!");
                return; // Exit the function
            }
            Console.WriteLine($"Swapper name and username: {surname} {name}");
        }
        
        public static void Sum2NumbersFromConsole() {
            Console.Write("Enter two numbers: ");
            double[] twoNumbers = ReadNumbersFromConsole(2);
            Console.WriteLine($"Sum of your numbers: {twoNumbers[0] + twoNumbers[1]}");
        }
        
        public static void AverageOf3NumbersFromConsole() {
            Console.Write("Enter three numbers: ");
            // Read user input, check for null and split by whitespace
            double[] inputNumbers = ReadNumbersFromConsole(3);
            Console.WriteLine("Average of your numbers: " +
                              $"{(inputNumbers[0] + inputNumbers[1] + inputNumbers[2]) / 3}");
        }

        public static void AreaOfRectangleFromConsole() {
            Console.Write("Enter width and height of rectangle: ");
            // Read user input, check for null and split by whitespace
            double[] inputNumbers = ReadNumbersFromConsole(2);
            Console.WriteLine($"Area of Rectangle: {inputNumbers[0] * inputNumbers[1]}");
            Console.WriteLine("Bonus: Perimeter of Rectangle: " +
                              (inputNumbers[0] != 0 && inputNumbers[1] != 0
                                  ? (inputNumbers[0] + inputNumbers[1]) * 2
                                  // In context of perimeter this will return single line or nothing (zero)
                                  : inputNumbers.Max()));
        }
    }
}