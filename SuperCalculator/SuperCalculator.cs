using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SuperCalculator
{
    public class SuperCalculator
    {
        private string Demiliter = ",";

        public int Add(string stringOfNumbers)
        {
            var arrayOfNumbers = ConvertStringToAnArrayOfNumbers(stringOfNumbers);

            return arrayOfNumbers.Sum();
        }

        private string DetectDelimiterAndRemoveIt(ref string stringOfNumbers)
        {
            if (stringOfNumbers.StartsWith("//"))
            {
                Demiliter = stringOfNumbers[2].ToString();
                stringOfNumbers = stringOfNumbers[4..];
            }

            return stringOfNumbers;
        }

        private List<int> ParseStringElementsToNumbers(List<string> ArrayOfStrings)
        {
            List<int> arrayOfNumbers = new();

            foreach (var number in ArrayOfStrings)
            {
                arrayOfNumbers.Add(int.Parse(number));

                if (arrayOfNumbers[^1] > 1000 || arrayOfNumbers[^1] < 0)
                    arrayOfNumbers[arrayOfNumbers.IndexOf(arrayOfNumbers[^1])] = 0;
            }

            return arrayOfNumbers;
        }

        public List<int> ConvertStringToAnArrayOfNumbers(string stringOfNumbers)
        {
            try
            {
                stringOfNumbers = DetectDelimiterAndRemoveIt(ref stringOfNumbers);

                List<string> ArrayOfNumberStrings = stringOfNumbers.Split(Demiliter).ToList();

                List<int> arrayOfNumbers = ParseStringElementsToNumbers(ArrayOfNumberStrings);

                return arrayOfNumbers;
            }
            catch (Exception)
            {
                throw new CustomException("The string of numbers must be separated by commas.");
            }
        }
    }
}