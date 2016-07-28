using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.BLL;
using FlooringProgram.Data;
using FlooringProgram.Models;
using NUnit.Framework;

namespace FlooringProgram.Tests.RepositoryTests
{
    [TestFixture]
    public class ManagerTests
    {

        [Test]
        public void GetOrderByID()
        {
            IOrderRepository repo = RepositoryFactory.GetOrderRepo();

            Order order = repo.GetOrderById(4, new DateTime(2010, 10, 10));
            Assert.AreEqual(4, order.OrderId);
        }

        [Test]
        public void GetAllOrders()
        {
            IOrderRepository repo = RepositoryFactory.GetOrderRepo();
            
            Assert.AreEqual(2, repo.GetAllOrders("10102010").Count);
        }

        [Test]
        public void CreateOrder()
        {
            var newOrder = new Order();
            IOrderRepository repo = RepositoryFactory.GetOrderRepo();

            newOrder.CustomerName = "Sam";
            newOrder.Area = 453m;
            newOrder.OrderDate = DateTime.Now;
            var actual = repo.CreateOrder(newOrder);
            Assert.AreEqual("Sam", actual.CustomerName);
        }

        [Test]
        public void DeleteOrder()
        {
            IOrderRepository repo = RepositoryFactory.GetOrderRepo();

            repo.DeleteOrder(5, new DateTime(2010, 10, 10));
            Assert.AreEqual(1, repo.GetAllOrders("10102010").Count);
        }

        [Test]
        public void UpdateOrder()
        {
            IOrderRepository repo = RepositoryFactory.GetOrderRepo();

            var newOrder = new Order();
            newOrder.CustomerName = "Samantha DelBrocco";
            repo.UpdateOrder(5, newOrder, DateTime.Today);

            Assert.AreEqual("Samantha DelBrocco", newOrder.CustomerName);
            Assert.AreEqual(DateTime.Today, newOrder.OrderDate);
        }

        [Test]
        public void OrderNotFoundReturnsFalse()
        {
            OrderManager om = new OrderManager();
            var response = new OrderResponse();
            
            response = om.GetOrderById(100, new DateTime(2010, 10, 10));

            Assert.AreEqual(false, response.Success);
        }

        [Test]
        public void OrderFoundReturnsSuccess()
        {
            OrderManager om = new OrderManager();
            var response = new OrderResponse();
            
            response = om.GetOrderById(5, new DateTime(2010, 10, 10));

            Assert.AreEqual(true, response.Success);
        }
    }
}
