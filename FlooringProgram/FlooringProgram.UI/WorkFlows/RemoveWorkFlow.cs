using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.BLL;
using FlooringProgram.Models;
using FlooringProgram.UI.Utilities;

namespace FlooringProgram.UI.WorkFlows
{
    public class RemoveWorkFlow
    {
        OrderManager om = new OrderManager();
        DisplayWorkFlow disp = new DisplayWorkFlow();
        //public List<Order> CurrentOrder;

        public void Execute()
        {
            var date = ConsoleIO.PromptDateTime("\n\nFrom what date would you like to delete an order (ex. 10/10/2010) : ");
            disp.Execute(date);
            var orderID = ConsoleIO.PromptInt("\n\nWhat order, by number would you like to delete : ");

            bool isValid = false;
            string commit = ConsoleIO.PromptString("Are you sure you want to delete this order? (Y)es/(N)o :");
            do
            {
                switch (commit.ToUpper())
                {
                    case "N":
                    case "NO":
                        ConsoleIO.Display("Okay, lets go back to the main menu...");
                        ConsoleIO.PromptString("\nPress enter to return to Main Menu: ");
                        isValid = true;
                        break;
                    case "Y":
                    case "YES":
                        om.DeleteOrder(orderID, date);
                        ConsoleIO.Display("Your order has been deleted");
                        disp.Execute(date);
                        ConsoleIO.PromptString("Press enter to continue...");
                        isValid = true;
                        break;
                    default:
                        ConsoleIO.Display($"{commit} is not valid!");
                        ConsoleIO.Display("Press enter to continue...");
                        Console.ReadLine();
                        break;
                }
            } while (!isValid);
        }
    }
}
