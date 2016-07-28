using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Data
{
    public class OrderRepository : IOrderRepository
    {
        ProductRepository Prod = new ProductRepository();
        TaxRepository tax = new TaxRepository();

        private const string FILENAME = @"Datafiles\Orders_";
        private const string FILEEXT = @".txt";

        public int GetNextID()
        {
            string date = DateTime.Today.ToString("MMddyyyy");
            List<Order> Orders = GetAllOrders(date);
            if (Orders.Count == 0)
            {
                return 1;
            }
            else
            {
                int id = Orders.First(x => x.OrderId == Orders.Max(n => n.OrderId)).OrderId;
                return ++id;
            }
        }

        public Order CreateOrder(Order order)
        {
            string date = DateTime.Today.ToString("MMddyyyy");
            List<Order> Orders = GetAllOrders(date);
            order.OrderDate = DateTime.Today;
            order.OrderId = GetNextID();
            Orders.Add(order);
            WriteToFile(date, Orders);
            return GetOrderById(order.OrderId, order.OrderDate);
            
        }

        public Order GetOrderById(int id, DateTime dateTime)
        {
            string newDateTime = dateTime.ToString("MMddyyyy");
            List<Order> Orders = GetAllOrders(newDateTime);
            return Orders.FirstOrDefault(o => o.OrderId == id);
        }
        
        public void UpdateOrder(int id, Order order, DateTime dateTime)
        {
            DeleteOrder(id, dateTime);
            CreateOrder(order);
        }

        public void DeleteOrder(int id, DateTime dateTime)
        {
            string newDateTime = dateTime.ToString("MMddyyyy");
            List<Order> Orders = GetAllOrders(newDateTime);
            Order OrderToRemove = Orders.FirstOrDefault(x => x.OrderId == id);
            Orders.Remove(OrderToRemove);

            using (StreamWriter sw = new StreamWriter(FILENAME + dateTime.ToString("MMddyyyy") + FILEEXT))
            {
                try
                {
                    foreach (var o in Orders)
                    {
                        sw.WriteLine($"{o.OrderId}|{o.CustomerName}|{o.Area}|{o.ProductOrdered.ProductType}|{o.State.StateAbbrev}");
                    }
                }
                catch 
                {
                    ErrorLog.Write("Failed to delete order...");
                }
            }
        }

        public List<Order> GetAllOrders(String date)
        {
            List<Order> order = new List<Order>();

            if (File.Exists(FILENAME + date + FILEEXT))
            {
                using (StreamReader sr = File.OpenText(FILENAME + date + FILEEXT))
                {
                    string inputLine = "";
                    string[] inputParts;
                    while ((inputLine = sr.ReadLine()) != null)
                    {
                        inputParts = inputLine.Split('|');
                        try
                        {
                            Product product = Prod.GetProductByName(inputParts[3]);
                            Order thisOrder =  new Order()
                            {
                                OrderId = int.Parse(inputParts[0]),
                                CustomerName = inputParts[1],
                                Area = decimal.Parse(inputParts[2]),
                                ProductOrdered = product,
                                State = tax.GetTaxByNameAbbrev(inputParts[4])
                            };
                            order.Add(thisOrder);
                        }
                        catch 
                        {
                            ErrorLog.Write($"Failed to read the file on {date}");
                        }
                    }
                }
            }

            return order;
        }

        private void WriteToFile(string date, List<Order> Orders )
        {
            using (StreamWriter sw = new StreamWriter(FILENAME + date + FILEEXT))
            {
                foreach (var o in Orders)
                {
                    sw.WriteLine($"{o.OrderId}|{o.CustomerName}|{o.Area}|{o.ProductOrdered.ProductType}|{o.State.StateAbbrev}|{o.State.TaxRate}|{o.ProductOrdered.CostPerSquareFoot}|{o.ProductOrdered.LaborCostPerSquareFoot}|{o.LaborCost}|{o.TaxCost}|{o.TotalCost}");

                }
            }
        }
    }
}
