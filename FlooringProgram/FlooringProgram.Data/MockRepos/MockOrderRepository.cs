using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Data
{
    public class MockOrderRepository :  IOrderRepository
    {
        public static List<Order> Orders = new List<Order>()
            {
                new Order { OrderDate = new DateTime(1990, 10, 10), OrderId = 1, CustomerName = "Sam DelBrocco", Area = 20.02m},
                new Order { OrderDate = new DateTime(1995, 10, 10), OrderId = 2, CustomerName = "Dan Smith", Area = 50.12m},
                new Order { OrderDate = new DateTime(2000, 10, 10), OrderId = 3, CustomerName = "Jan White", Area = 35.70m},
                new Order { OrderDate = new DateTime(2010, 10, 10), OrderId = 4, CustomerName = "Stan Mason", Area = 36.75m},
                new Order { OrderDate = new DateTime(2010, 10, 10), OrderId = 5, CustomerName = "Chris Mason", Area = 36.00m}
        };

        public MockOrderRepository()
        {
            MockProductRepository prodRepo = new MockProductRepository();
            MockTaxRepository taxRepo = new MockTaxRepository();

            foreach (var order in Orders)
            {
                if (order.ProductOrdered == null)
                {
                    order.ProductOrdered = prodRepo.GetProductByName("TILE");
                }

                if (order.State == null)
                {
                    order.State = taxRepo.GetTaxByNameAbbrev("OH");
                }
            }
        }
        
        public Order CreateOrder(Order newOrder)
        {
            newOrder.OrderDate = DateTime.Today;
            Orders.Add(newOrder);

            return newOrder;
        }
        
        public Order GetOrderById(int id, DateTime dateTime)
        {
            string newDateTime = dateTime.ToString("MMddyyyy");
            Orders = GetAllOrders(newDateTime);
            return Orders.FirstOrDefault(o => o.OrderId == id);
        }
        
        public List<Order> GetAllOrders(string dateTime)
        {
            int month = int.Parse(dateTime.Substring(0, 2));
            int day = int.Parse(dateTime.Substring(2, 2));
            int year = int.Parse(dateTime.Substring(4));

            DateTime newDateTime = new DateTime(year, month, day);
            return Orders.Where(o => o.OrderDate == newDateTime).ToList();
        }

        public void UpdateOrder(int id, Order order, DateTime dateTime)
        {
            DeleteOrder(id, dateTime);
            CreateOrder(order);
        }

        public void DeleteOrder(int id, DateTime dateTime)
        {
            string newDateTime = dateTime.ToString("MMddyyyy");
            Orders = GetAllOrders(newDateTime);
            Orders.Remove(Orders.FirstOrDefault(o => o.OrderId == id));
        }
        
        }
    }

