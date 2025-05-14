using System;
using System.Linq;
using System.Text;

namespace HomeworkSolution {
    public abstract class Homework4Solutions {
        public static void EvenNumbers() {
            var evenNumbers = new int[50];
            for (var i = 0; i < 50; i++) evenNumbers[i] = i * 2;
            foreach (var num in evenNumbers) Console.WriteLine($"Element: {num}");
        }

        public static void CountEvenFromRandom() {
            var rng = new Random();
            var array = new int[rng.Next(24, 51)];
            for (var i = 0; i < array.Length; i++) array[i] = rng.Next(0, 100);
            
            var evenNumbers = array.Where(num => num % 2 == 0).ToArray();
            var stringBuilder = new StringBuilder();
            foreach (var number in evenNumbers) stringBuilder.Append(number).Append(", ");
            stringBuilder.Remove(stringBuilder.Length - 2, 2);
            
            Console.WriteLine(
                $"There are {evenNumbers.Length} even numbers in generated array\n" +
                $"They are: {stringBuilder}");
        }

        public static void CountCharsFromConsole() {
            Console.Write("Enter your text: ");
            var input = Console.ReadLine() ?? string.Empty;
            Console.Write($"Your text contains {input.Length} character\n" +
                           "Now enter single character you want to count: ");

            Console.WriteLine(
                char.TryParse(Console.ReadLine(), out var charToCount)
                    ? $"There are {input.Count(ch => char.ToLower(ch) == char.ToLower(charToCount))} characters \'{charToCount}\' in your word!"
                    : "Can't parse the string");
        }

        public static void LetterAsAscii() {
            const int letterCount = 26;
            var letters = new char[letterCount];
            // From ascii to ascii
            for (var i = 0; i < letterCount; i++) letters[i] = (char)('a' + i);
            foreach (var ch in letters) Console.Write($"{(int)ch}: {ch};  ");
        }
    }
}