using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Data
{
    public interface IOrderRepository
    {
        Order CreateOrder(Order order);
        Order GetOrderById(int id, DateTime dateTime);
        List<Order> GetAllOrders(string dateTime);
        void UpdateOrder(int id, Order order, DateTime dateTime);
        void DeleteOrder(int id, DateTime dateTime);
    }
}
