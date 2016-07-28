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
    public class DisplayWorkFlow
    {
        OrderManager om = new OrderManager();
        public List<Order> CurrentOrders;

        public void Execute()
        {
            var date = ConsoleIO.PromptDateTime("\n\nWhat date would you like orders from (ex. 10/10/2010) :  ");
            Execute(date);
            ConsoleIO.PromptString("\n\nPress enter to return to Main Menu: ");
        }

        public void Execute(DateTime date)
        {
            DisplayOrderInformation(date);
        }

        private void DisplayOrderInformation(DateTime date)
        {
            OrderResponse response = new OrderResponse();
            response = om.GetAllOrders(date.ToString("MMddyyyy"));

            if (response.Success)
            {
                CurrentOrders = response.OrderList;
                PrintOrderInformation(CurrentOrders);
            }
            else
            {
                ConsoleIO.Display("Error Occurred, sorry!");
                ConsoleIO.Display(response.Message);
                ConsoleIO.Display("Move along...");
                Console.ReadLine();
            }
        }

        private static void PrintOrderInformation(List<Order> orders)
        {
            foreach (var order in orders)
            {
                ConsoleIO.Display("\n\n         ORDER INFORMATION         ");
                ConsoleIO.Display("___________________________________");
                ConsoleIO.Display($"    Order Number:                {order.OrderId:d}");
                ConsoleIO.Display($"            Name:                {order.CustomerName}");
                ConsoleIO.Display($"            Area:                {order.Area}");
                ConsoleIO.Display($"      Labor Cost:                {order.LaborCost:c}");
                ConsoleIO.Display($"   Material Cost:                {order.MaterialCost:c}");
                ConsoleIO.Display($"    Cost/ Sq. Ft:                {order.ProductOrdered.CostPerSquareFoot:c}");
                ConsoleIO.Display($"Labor cost/sq ft:                {order.ProductOrdered.LaborCostPerSquareFoot:c}");
                ConsoleIO.Display($"        Tax Cost:                {order.TaxCost:c}");
                ConsoleIO.Display($"           Total:                {order.TotalCost:c}");
                ConsoleIO.Display($"      State Name:                {order.State.StateName}");
                ConsoleIO.Display($"    Product Type:                {order.ProductOrdered.ProductType}");
            }
        }
    }
}
