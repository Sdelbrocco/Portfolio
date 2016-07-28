using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Data;
using FlooringProgram.Models;

namespace FlooringProgram.BLL
{

    public class OrderManager
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IProductRepository _productRepo;
     
        public OrderManager()
        {
            //_orderRepo = new MockOrderRepository();
            _orderRepo = RepositoryFactory.GetOrderRepo();
            _productRepo = RepositoryFactory.GetProductRepo();
        }
        
        public OrderResponse GetOrderById(int id, DateTime dateTime)
        {
            var response = new OrderResponse();
            var order = _orderRepo.GetOrderById(id, dateTime);

            try
            {

                if (order == null)
                {
                    response.Success = false;
                    response.Message = "Invalid order, try again...";
                }
                else
                {
                    response.Success = true;
                    //response.OrderList = new List<Order>();
                    List<Order> Orders = new List<Order>();
                    Orders.Add(order);
                    response.OrderList = Orders;
                }
            }
            catch
            {
                response.Success = false;
                response.Message = "Something went terribly wrong, lets go back...";
            }
            return response;
        }

        public OrderResponse GetAllOrders(string dateTime)
        {
            var response = new OrderResponse();
            var order = _orderRepo.GetAllOrders(dateTime);

            try
            {
                if (order == null || order.Count == 0)
                {
                    response.Success = false;
                    response.Message = "Invlid date, try again...";
                    ErrorLog.Write(response.Message);
                }
                else
                {
                    response.Success = true;
                    response.OrderList = order;
                }
            }
            catch
            {
                response.Success = false;
                response.Message = "Something went terrible wrong, lets go back...";
            }
            return response;
        }
        
        public OrderResponse CreateOrder(Order order)
        {
            var response = new OrderResponse();
            
            Order newOrder = _orderRepo.CreateOrder(order);

            try
            {
                if (newOrder == null)
                {
                    response.Success = false;
                    response.Message = "Invalid order, try again...";
                }
                else
                {
                    response.Success = true;
                    response.OrderList = new List<Order>() { newOrder };
                }
            }
            catch (Exception)
            {

                response.Success = false;
                response.Message = $"Failed to create order for {newOrder.CustomerName}";
            }
            return response;
        }

        public OrderResponse DeleteOrder(int id, DateTime dateTime)
        {
            var response = new OrderResponse();
            
            try
            {
                _orderRepo.DeleteOrder(id, dateTime);
                response.Success = true;
            }
            catch 
            {
                response.Success = false;
                response.Message = "Failed to delete order";
            }
            return response;
        }

        public bool ValidateProduct(string result)
        {
            if (_productRepo.GetProductByName(result) != null)
            {
                return true;
            }
            return false;
        }
    }
}
