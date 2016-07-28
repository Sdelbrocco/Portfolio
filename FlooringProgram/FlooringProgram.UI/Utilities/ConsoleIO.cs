using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.UI.Utilities
{
    public class ConsoleIO
    {
        public static int PromptInt(string message)
        {
            bool isValid;
            int result;

            do
            {
                string userInput = PromptString(message);
                isValid = int.TryParse(userInput, out result);
                if (!isValid)
                {
                    Display("I said a number!");
                }
            } while (!isValid);
            return result;
        }

        public static decimal PromptDecimal(string message, int min)
        {
            decimal result = min-1;
            while ((result = PromptDecimal(message)) < min)
            {
                Display("That is not a valid area...");
            }
            return result;
        }

        public static decimal PromptDecimal(string message)
        {
            bool isValid;
            decimal result;

            do
            {
                string userInput = PromptString(message);
                isValid = decimal.TryParse(userInput, out result);
                if (!isValid)
                {
                    Display("I'm going to need a number...");
                }
            } while (!isValid);
            return result;
        }

        public static string PromptString(string message)
        {
            Display(message);
            return Console.ReadLine();
        }

        public static DateTime PromptDateTime(string message)
        {
            bool isValid;
            DateTime result;

            do
            {
                string userInput = PromptString(message);
                isValid = DateTime.TryParse(userInput, out result);
                if (!isValid)
                {
                    Display("That is not a valid date, try again...");
                    Display("Press enter to continue...");
                    Console.ReadLine();
                }
            } while (!isValid);
            return result;
        }

        public static void Display(string message)
        {
            Console.WriteLine(message);
        }

        public static string GetCustomerName()
        {
            string name;

            do
            {
                Console.Clear();
                name = PromptString("Please enter a name for the order: ");

                if (string.IsNullOrEmpty(name))
                {
                    PromptString("Please enter something...");
                }

            } while (string.IsNullOrEmpty(name));

            return name;
        }
        
        public static decimal GetArea()
        {
            decimal area;

            do
            {
                Console.Clear();
                area = PromptDecimal("Please enter the area of the order: ");

                if (area <= 0)
                {
                    PromptString("Please enter a valid number...");
                }
            } while (area == 0);

            return area;
        }

        public static string PromptOptions(string message, IEnumerable<string> options)
        {
            string result;
            bool isValid = false;
            do
            {
                foreach (var option in options)
                {
                    Console.WriteLine(option);
                }
                result = PromptString(message);
                if (options.Any(o => o == result))
                {
                    isValid = true;
                }
                if (!isValid)
                {
                    Display("Invalid type...try again...");
                }
            } while (!isValid);
            return result;
        }

        public static void PrintOrderInfo(Order newOrder, DateTime date)
        {
                ConsoleIO.Display("\n\n     NEW ORDER INFORMATION         ");
                ConsoleIO.Display("___________________________________");
                ConsoleIO.Display($"   Order Number:                {newOrder.OrderId}");
                ConsoleIO.Display($"           Name:                {newOrder.CustomerName}");
                ConsoleIO.Display($"           Area:                {newOrder.Area}");
                ConsoleIO.Display($"Product Ordered:                {newOrder.ProductOrdered.ProductType}");
                ConsoleIO.Display($"          State:                {newOrder.State.StateAbbrev}");
        }
    }
}
