using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.UI.WorkFlows;

namespace FlooringProgram.UI.Utilities
{
    public class Display
    {
        public void DisplayMenu()
        {
            string input;

            do
            {
                Console.Clear();
                Console.WriteLine("+----------------------------------------------------------------+");
                Console.WriteLine("|                     WELCOME TO FLOORING BY SAM                 |");
                Console.WriteLine("+----------------------------------------------------------------+");
                Console.WriteLine("|                      PLEASE SELECT AN OPTION                   |");
                Console.WriteLine("|                                                                |");
                Console.WriteLine("|                     1. Display Order                           |");
                Console.WriteLine("|                     2. Add An Order                            |");
                Console.WriteLine("|                     3. Edit An Existing Order                  |");
                Console.WriteLine("|                     4. Remove An Existing Order                |");
                Console.WriteLine("|                                                                |");
                Console.WriteLine("|                          (Q) to Quit                           |");
                Console.WriteLine("+----------------------------------------------------------------+");
                Console.WriteLine();
                input = ConsoleIO.PromptString("                            Enter Choice:  ");
                
                if (input.ToUpper() != "Q")
                {
                    ProcessChoice(input);
                }

            } while (input.ToUpper() != "Q");
        }

        private void ProcessChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    DisplayWorkFlow displayOrder = new DisplayWorkFlow();
                    displayOrder.Execute();
                    break;
                case "2":
                    AddWorkFlow addOrder = new AddWorkFlow();
                    addOrder.Execute();
                    break;
                case "3":
                    EditWorkFlow editOrder = new EditWorkFlow();
                    editOrder.Execute();
                    break;
                case "4":
                    RemoveWorkFlow removeOrder = new RemoveWorkFlow();
                    removeOrder.Execute();
                    break;
                case "":
                    ConsoleIO.Display("Please enter a number 1-4...");
                    ConsoleIO.PromptString("Press enter to continue...");
                    break;
                default:
                    ConsoleIO.Display($"{choice} is not valid!");
                    ConsoleIO.PromptString("Press enter to continue...");
                    break;
            }
        }
    }
}
