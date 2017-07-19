using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Web.Controllers;
using SportsStore.Web.Models;
using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;

namespace SportsStore.Tests.Controllers
{
    [TestClass]
    public class ProductControllerTest
    {
        #region Public Methods

        [TestMethod]
        public void CanPaginate()
        {
            //Arrange
            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            productRepository.Setup(p => p.Products).Returns(new List<Product>
            {
                new Product {Id = 1, Name = "P1"},
                new Product {Id = 2, Name = "P2"},
                new Product {Id = 3, Name = "P3"},
                new Product {Id = 4, Name = "P4"},
                new Product {Id = 5, Name = "P5"},
                new Product {Id = 6, Name = "P6"},
            });

            var productController = new ProductController(productRepository.Object) {PageSize = 2};

            //Act
            var viewResult = (ProductsListViewModel)productController.List(null, 2).Model;

            //Assert
            var products = viewResult.Products as Product[] ?? viewResult.Products.ToArray();
            Assert.IsTrue(products.Count() == 2);
            Assert.AreEqual(products.ElementAt(0).Name, "P3");
            Assert.AreEqual(products.ElementAt(1).Name, "P4");
        }

        [TestMethod]
        public void ReturnsAllOrderedProducts()
        {
            //Arrange
            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            productRepository.Setup(repo => repo.Products).Returns(new List<Product>
            {
                new Product {Id = 3, Name = "P3"},
                new Product {Id = 1, Name = "P1"},
                new Product {Id = 2, Name = "P2"}
            });
            ProductController productController = new ProductController(productRepository.Object) {PageSize = 5};

            //Act
            var returnedModel = (ProductsListViewModel) productController.List(null).Model;
            var returnedProducts = returnedModel.Products;

            //Assert
            var products = returnedProducts as Product[] ?? returnedProducts.ToArray();
            Assert.IsTrue(products.Count() == 3);
            Assert.AreEqual(products.ElementAt(0).Id, 1);
            Assert.AreEqual(products.ElementAt(1).Id, 2);
            Assert.AreEqual(products.ElementAt(2).Id, 3);
        }

        [TestMethod]
        public void ReturnsSpecificCategoryOnly()
        {
            //Arrange
            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            productRepository.Setup(repo => repo.Products).Returns(new List<Product>
            {
                new Product {Name = "P3", Category = "Cat1"},
                new Product {Name = "P1", Category = "Cat1"},
                new Product {Name = "P2", Category = "Cat1"},
                new Product {Name = "C1", Category = "Cat2"},
                new Product {Name = "C2", Category = "Cat2"}
            });
            ProductController productController = new ProductController(productRepository.Object) { PageSize = 5 };

            //Act
            var returnedModel = (ProductsListViewModel)productController.List("Cat2").Model;
            var returnedProducts = returnedModel.Products;

            //Assert
            var products = returnedProducts as Product[] ?? returnedProducts.ToArray();
            Assert.IsTrue(products.Count() == 2);
            Assert.IsTrue(products.All(product => product.Category == "Cat2"));
        }
        #endregion
    }
}
