using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebSite.Controllers;
using WebSite.Data.Services;
using WebSite.Data.ViewModels;
using WebSite.Models;

namespace TestsProject.ProductTests
{
    [TestClass]
    public class Tests
    {

        [Fact]
        public void Cannot_Edit_Not_Existed_Product()
        {
            Mock<IProductService> mock = new Mock<IProductService>();
            mock.Setup(m => m.products).Returns(new List<Product>
            {
                new Product {
                    PictureURL = "https://ketokotleta.ru/wp-content/uploads/1/a/0/1a046952b4481bf1f8daa22bc0d7d834.jpeg",
                    Name = "test name",
                    Id = 0,
                    IsAvailable = true,
                    Quantity = 1,
                    Description = "test desc",
                    Price = 10,
                    ManufacturerId = 0,
                }
            });
            var controller = new ProductsController(mock.Object);

            var result = controller.Edit(0);

            var viewResult = Xunit.Assert.IsType<Task<IActionResult>>(result);
            var modelResult = Xunit.Assert.IsType<ViewResult>(viewResult.Result);
            Xunit.Assert.Equal("NotFound", modelResult.ViewName);
        }
        [Fact]
        public void Can_Create_New_Product()
        {
            Mock<IProductService> mock = new Mock<IProductService>();
            mock.Setup(m => m.products).Returns(new List<Product>
            {
                new Product {
                    PictureURL = "https://ketokotleta.ru/wp-content/uploads/1/a/0/1a046952b4481bf1f8daa22bc0d7d834.jpeg",
                    Name = "test name",
                    Id = 0,
                    IsAvailable = true,
                    Quantity = 1,
                    Description = "test desc",
                    Price = 10,
                    ManufacturerId = 0,
                }
            });
            NewProductVM newProduct = new NewProductVM
            {
                ImageURL = "https://ketokotleta.ru/wp-content/uploads/1/a/0/1a046952b4481bf1f8daa22bc0d7d834.jpeg",
                Name = "test name",
                Id = 1,
                Quantity = 1,
                Description = "test desc",
                Price = 10,
                ManufacturerId = 0,
            };
            var controller = new ProductsController(mock.Object);

            var result = controller.Create(newProduct);

            var viewResult = Xunit.Assert.IsType<Task<IActionResult>>(result);
            var modelResult = Xunit.Assert.IsType<RedirectToActionResult>(viewResult.Result);
            Xunit.Assert.Equal("Index", modelResult.ActionName);
        }
    }
}
