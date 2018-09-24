using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebAPI;
using WebAPI.Controllers;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            var data = new List<Product>
            {
               new Product {Id = 4, Name = "Chest Set", Price = 14.99M },
               new Product {Id = 5, Name = "Operation", Price = 23 },
               new Product {Id = 6, Name = "Monopoly", Price = 17.49M }
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Product>>();
            var mockContext = new Mock<DataModel>();

            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            mockContext.Setup(c => c.Products).Returns(mockSet.Object);


            // Act
            var service = new ValuesController(mockContext.Object);

            // Assert
            Assert.IsNotNull(service);
            List<Product> lstProds = service.Get().ToList();
            Assert.AreEqual(data.Count(), lstProds.Count());
            Assert.AreEqual(data.FirstOrDefault().Name, lstProds.FirstOrDefault().Name);
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            string result = controller.Get(5);

            // Assert
            Assert.AreEqual("value", result);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            controller.Post("value");

            // Assert
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            controller.Put(5, "value");

            // Assert
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            controller.Delete(5);

            // Assert
        }
    }
}
