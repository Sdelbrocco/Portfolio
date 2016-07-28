using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    public class Calculator
    {
        public int Add (string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }
            else
            {
                char[] delimiters;
                var errorMessage = "Negatives not allowed: ";
                if (!numbers.StartsWith("//"))
                {
                    delimiters = new char[] { ',', '\n'};
                }
                else
                {
                    string[] parts = numbers.Split('\n');
                    numbers = parts[1];
                    delimiters = parts[0].Substring(2).ToCharArray();
                }
                string[] individualNumbers = numbers.Split(delimiters);

                int result = 0;

                for (int i = 0; i < individualNumbers.Length; i++)
                {
                    var x = int.Parse(individualNumbers[i]);
                    if(x > 0)
                    {
                        result += x;
                    }
                    else if (x > 1000)
                    {
                    
                    }
                    else
                    {
                        errorMessage += x.ToString();
                        throw new Exception(errorMessage);
                    }
                    
                }

            return result;
            }
        }
    }
}
