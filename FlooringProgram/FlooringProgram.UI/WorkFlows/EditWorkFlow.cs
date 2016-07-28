using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.BLL;
using FlooringProgram.Models;
using FlooringProgram.UI.Utilities;

namespace FlooringProgram.UI.WorkFlows
{
    public class EditWorkFlow
    {
        Order newOrder = new Order();
        private DateTime _date;
        private int _orderID;
        private Response _response;
        private OrderResponse _orderResponse;
        private ProductResponse _productResponse;
        ProductManager pm = new ProductManager();
        TaxManager tm = new TaxManager();
        OrderManager om = new OrderManager();
        DisplayWorkFlow dsp = new DisplayWorkFlow();

        public void Execute()
        {
            var manager = new OrderManager();
            _date = ConsoleIO.PromptDateTime("\nDate of the order which you want to edit: ");
            dsp.Execute(_date);
            _orderID = ConsoleIO.PromptInt("\nEnter the order number you want to edit: ");
            _response = manager.GetOrderById(_orderID, _date);
            _orderResponse = manager.GetOrderById(_orderID, _date);

            ConsoleIO.Display("\nGreat! Fill in all of the fields");
            ConsoleIO.Display("If you leave a section blank, it will stay the same.");
            ConsoleIO.Display("Otherwise, enter what you want to update it to...");
            var input = ConsoleIO.PromptString("Press enter to continue or Q to quit...");

            if (input.ToUpper() != "Q")
            {
                EditOrder(_response, _orderResponse);
            }
        }

        private void EditOrder(Response _response, OrderResponse _orderResponse)
        {
            if (_response.Success)
            {
                newOrder.OrderId = _orderResponse.OrderList[0].OrderId;
                newOrder.OrderDate = DateTime.Now;

                string name = ConsoleIO.PromptString("\nEnter Name: ");
                if (string.IsNullOrEmpty(name))
                {
                    newOrder.CustomerName = _orderResponse.OrderList[0].CustomerName;
                }
                newOrder.CustomerName = name;

                decimal area = ConsoleIO.PromptDecimal("Enter Area: ");
                if (area <= 0)
                {
                    newOrder.Area = _orderResponse.OrderList[0].Area;
                }
                newOrder.Area = area;

                AddWorkFlow add = new AddWorkFlow();
                newOrder.ProductOrdered = pm.GetProductBy(add.GetProduct().ToUpper());
                if (newOrder.ProductOrdered == null)
                {
                    newOrder.ProductOrdered = _orderResponse.OrderList[0].ProductOrdered;
                }

                newOrder.State = tm.GetTaxBy(add.GetState());
                if (newOrder.State == null)
                {
                    newOrder.State = _orderResponse.OrderList[0].State;
                }

                Console.Clear();

                ConsoleIO.PrintOrderInfo(newOrder, _date);
                string commit = ConsoleIO.PromptString("\nAre you sure you want to commit? (Y/N): ");
                if (commit.ToUpper() == "Y")
                {
                    om.DeleteOrder(newOrder.OrderId, _date);
                    om.CreateOrder(newOrder);
                    ConsoleIO.Display($"Order number {newOrder.OrderId} has been updated.");
                }
                else if (commit.ToUpper() == "YES")
                {
                    om.DeleteOrder(newOrder.OrderId, _date);
                    om.CreateOrder(newOrder);
                    ConsoleIO.Display($"Order number {newOrder.OrderId} has been updated.");
                }
                else
                {
                    ConsoleIO.Display("No changes have been made...");
                }
                ConsoleIO.PromptString("Press any key to continue...");
            }
            Console.ReadLine();
        }
        }
    }

