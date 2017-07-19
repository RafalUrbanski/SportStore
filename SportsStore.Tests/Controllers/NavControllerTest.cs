using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Web.Controllers;
using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;

namespace SportsStore.Tests.Controllers
{
    [TestClass]
    public class NavControllerTest
    {
        [TestMethod]
        public void DoesMenuReturnAllCategories()
        {
            //Arrange
            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            productRepository.Setup(repo => repo.Products).Returns(new List<Product>
            {
                new Product {Name = "Jabłko", Category = "Owoce"},
                new Product {Name = "Kredki", Category = "Artykuly biurowe"},
                new Product {Name = "Olowek", Category = "Artykuly biurowe"},
                new Product {Name = "Koszulka", Category = "Odziez"}
            });

            var navController = new NavController(productRepository.Object);

            //Act
            var categories = ((IEnumerable<string>) navController.Menu().Model).ToArray();

            //Assert
            Assert.AreEqual(categories.Length, 3);
            Assert.AreEqual(categories[0], "Artykuly biurowe");
            Assert.AreEqual(categories[1], "Odziez");
            Assert.AreEqual(categories[2], "Owoce");
        }
    }
}
