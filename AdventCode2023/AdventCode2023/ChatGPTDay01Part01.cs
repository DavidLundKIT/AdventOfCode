using System.Linq;
using System.Collections.Generic;
namespace AdventCode2023
{
    public class ChatGPTDay01Part01
    {
        [Fact]
        public void Day01_Part1_AI_OK()
        {
            // Read the calibration document from a file
            // David: Changed for my paths
            string[] lines = Utils.ReadLinesFromFile("Day01.txt");

            // Initialize the sum variable
            int sum = 0;

            // Loop through each line
            foreach (string line in lines)
            {
                // Find the first and last digit in the line
                char firstDigit = line.FirstOrDefault(char.IsDigit);
                char lastDigit = line.LastOrDefault(char.IsDigit);

                // If both digits are found, combine them into a two-digit number
                if (firstDigit != '\0' && lastDigit != '\0')
                {
                    int value = int.Parse(firstDigit.ToString() + lastDigit.ToString());

                    // Add the value to the sum
                    sum += value;
                }
            }

            // Print the sum
            Console.WriteLine("The sum of all of the calibration values is {0}.", sum);
            Assert.Equal(54916, sum);
        }

        /*
        [Fact]
        public void Day02_Part2_AI_OK()
        {
            // Read the calibration document from a file
            string[] lines = Utils.ReadLinesFromFile("Day01.txt");

            // Initialize the sum variable
            int sum = 0;

            // Create a dictionary to map the spelled out digits to their numeric values
            Dictionary<string, int> digitMap = new Dictionary<string, int>()
        {
            {"one", 1},
            {"two", 2},
            {"three", 3},
            {"four", 4},
            {"five", 5},
            {"six", 6},
            {"seven", 7},
            {"eight", 8},
            {"nine", 9}
        };

            // Loop through each line
            foreach (string line in lines)
            {
                // Find the first and last digit in the line, either as a char or a string
                // AI weirdness
                object firstDigit = line.FirstOrDefault(char.IsDigit) ?? line.Split(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
                object lastDigit = line.LastOrDefault(char.IsDigit) ?? line.Split(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault();

                // If both digits are found, combine them into a two-digit number
                if (firstDigit != null && lastDigit != null)
                {
                    // Convert the digits to integers, using the dictionary if needed
                    int firstValue = firstDigit is char ? int.Parse(firstDigit.ToString()) : digitMap[firstDigit.ToString()];
                    int lastValue = lastDigit is char ? int.Parse(lastDigit.ToString()) : digitMap[lastDigit.ToString()];

                    // Combine the values into a two-digit number
                    int value = firstValue * 10 + lastValue;

                    // Add the value to the sum
                    sum += value;
                }
            }

            // Print the sum
            Console.WriteLine("The sum of all of the calibration values is {0}.", sum);
        }
        */
    }
}
