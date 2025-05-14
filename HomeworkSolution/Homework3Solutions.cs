using System;
using System.Globalization;
// ReSharper disable UnusedMember.Local

namespace HomeworkSolution {
    public class Homework3Solutions {
        private static double[] ReadNumbersFromConsole(int amountOfNumbers) {
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
        
        public static void DefineNumberFromConsole() {
            Console.Write("Enter your number: ");
            var number = ReadNumbersFromConsole(1)[0];
            if (number == 0) {
                Console.WriteLine("Number is Zero");
            }
            else if (number > 0) {
                Console.WriteLine("Number is Positive");
            }
            else {
                Console.WriteLine("Number is Negative");
            }
        }

        public static void NumberInRangeFromConsole() {
            Console.Write("Enter your number: ");
            var number = ReadNumbersFromConsole(1)[0];
            Console.WriteLine(number >= 10 && number <= 20 ? "Number within [10; 20]"
                : number >= 30 && number <= 40 ? "Number within [30; 40]"
                : "Number is outside of this magic diapason");
        }

        public static void CompareTwoNumbersFromConsole() {
            Console.Write("Enter two numbers: ");
            var numbers = ReadNumbersFromConsole(2);
            const double precision = 0.0001;
            Console.WriteLine(Math.Abs(numbers[0] - numbers[1]) < precision ? "Numbers are equal" :
                "Bigger number is " + (numbers[0] > numbers[1] ? numbers[0] : numbers[1]));
        }
        
        enum Months {   // For screenshot size sake, I made it fit in a single line
            January = 1, February, March, April, May, June, July, August, September, October, November, December
        }

        public static void MonthNameFromNumber() {
            Console.Write("Enter number of month: ");
            var monthNumber = (int)ReadNumbersFromConsole(1)[0];
            if (Enum.IsDefined(typeof(Months), monthNumber)) {
                Console.WriteLine((Months)monthNumber);
            }
            else {
                Console.WriteLine("Probably Thirteentober or something else...");
            }
        }

        enum DaysOfWeek {
            Monday = 1, Tuesday = 2, Wednesday = 3, Thursday = 4, Friday = 5, Saturday = 6, Sunday = 7
        }
        public static void DayOfWeekFromNumber() {
            Console.Write("Enter number of day in a week: ");
            var dayOfWeek = (int)ReadNumbersFromConsole(1)[0];
            if (Enum.IsDefined(typeof(DaysOfWeek), dayOfWeek)) {
                Console.WriteLine((DaysOfWeek)dayOfWeek);
            }
            else {
                // BONUS
                var currentMonth = DateTime.Today.Month;
                var currentYear = 2025;
                if (dayOfWeek <= DateTime.DaysInMonth(currentYear, currentMonth)) {
                    var dateInMonth = new DateTime(currentYear, currentMonth, dayOfWeek);
                    Console.WriteLine("This day in current month will be " + dateInMonth.DayOfWeek);
                }
                else if (dayOfWeek <= 365) {    // we use only 2025th year, so no leap year
                    // Very first day + number of days -> date from day of year 
                    var dayInYear = new DateTime(currentYear, 1, 1).AddDays(dayOfWeek - 1);
                    Console.WriteLine("This day in current year will be " + dayInYear.DayOfWeek);
                }
                else {
                    Console.WriteLine("This is too many days for me...");
                }
            }
        }
    }
}