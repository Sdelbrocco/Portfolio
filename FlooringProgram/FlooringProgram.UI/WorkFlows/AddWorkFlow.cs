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
    public class AddWorkFlow
    {
        OrderManager om = new OrderManager();
        TaxManager tm = new TaxManager();
        ProductManager pm = new ProductManager();
        Order newOrder = new Order();

        public void Execute()
        {
            newOrder.CustomerName = GetNewName();
            newOrder.ProductOrdered = pm.GetProductBy(GetProduct());
            newOrder.State = tm.GetTaxBy(GetState().ToUpper());
            newOrder.Area = GetNewArea();
            om.CreateOrder(newOrder);
            ConsoleIO.Display("Your order has been added.");
            ConsoleIO.Display("Press any key to continue...");
            Console.ReadLine();
        }

        private static decimal GetNewArea()
        {
            return ConsoleIO.PromptDecimal("Enter the Area of the Order: ", 1);
        }

        public string GetState()
        {
            TaxResponse Taxes = tm.GetAllTaxes();
            IEnumerable<string> options = from tax in Taxes.TaxInfo
                                          select tax.StateAbbrev;
            var result = ConsoleIO.PromptOptions("Select State: ", options.Distinct());
            return result;
        }

        public string GetProduct()
        {
            bool validProduct;
            string result;

            do
            {
                result = ConsoleIO.PromptString("Enter product: ");
                validProduct = om.ValidateProduct(result);
            } while (validProduct == false);
            return result;
        }

        private static string GetNewName()
        {
            bool isValid = false;
            string name = "";
            do
            {
                name = ConsoleIO.PromptString("Enter the order name: ");
                if (!string.IsNullOrEmpty(name))
                {
                    return name;
                }
                ConsoleIO.Display("Thats not a valid name,");
                ConsoleIO.PromptString("Press enter to try again...");
            } while (!isValid);
            return name;
        }
    }
}
