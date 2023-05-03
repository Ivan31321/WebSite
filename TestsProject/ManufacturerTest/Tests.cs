using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebSite.Controllers;
using WebSite.Data.Services;
using WebSite.Models;

namespace TestsProject.ManufacturerTest
{
    [TestClass]
    public class Tests
    {
        [Fact]
        public void Can_Edit_Existed_Manufacturer()
        {
            Mock<IManufacturerService> mock = new Mock<IManufacturerService>();
            mock.Setup(m => m.manufacturers).Returns(new List<Manufacturer> {
                new Manufacturer {
                    PictureURL = "https://ketokotleta.ru/wp-content/uploads/1/a/0/1a046952b4481bf1f8daa22bc0d7d834.jpeg",
                    Adress = "test adress",
                    Phone = "test phone",
                    Name = "test name",
                    Id = 0,
                }
            });
            ManufacturersController controller = new ManufacturersController(mock.Object);

            var result = controller.Edit(0);
            var viewResult = Xunit.Assert.IsType<Task<IActionResult>>(result);
            var modelResult = Xunit.Assert.IsType<ViewResult>(viewResult.Result);
            Xunit.Assert.NotEqual("Not Found", modelResult.ViewName);
        }
        [Fact]
        public void Can_Add_New_Manufacturer()
        {
            Mock<IManufacturerService> mock = new Mock<IManufacturerService>();
            mock.Setup(m => m.manufacturers).Returns(new List<Manufacturer> {
                new Manufacturer {
                    PictureURL = "https://ketokotleta.ru/wp-content/uploads/1/a/0/1a046952b4481bf1f8daa22bc0d7d834.jpeg",
                    Adress = "test adress",
                    Phone = "test phone",
                    Name = "test name",
                    Id = 0,
                }
            });
            Manufacturer manufacturer = new Manufacturer
            {
                PictureURL = "https://ketokotleta.ru/wp-content/uploads/1/a/0/1a046952b4481bf1f8daa22bc0d7d834.jpeg",
                Adress = "test adress",
                Phone = "test phone",
                Name = "test name",
                Id = 1,
            };
            ManufacturersController controller = new ManufacturersController(mock.Object);

            var result = controller.Create(manufacturer);

            var viewResult = Xunit.Assert.IsType<Task<IActionResult>>(result);
            var modelResult = Xunit.Assert.IsType<RedirectToActionResult>(viewResult.Result);
            Xunit.Assert.Equal("Index", modelResult.ActionName);
        }
        [Fact]
        public void Can_Delete_Existed_Manufacturer()
        {
            var mock = new Mock<IManufacturerService>();
            mock.Setup(m => m.manufacturers).Returns(new List<Manufacturer> {
                new Manufacturer {
                    PictureURL = "https://ketokotleta.ru/wp-content/uploads/1/a/0/1a046952b4481bf1f8daa22bc0d7d834.jpeg",
                    Adress = "test adress",
                    Phone = "test phone",
                    Name = "test name",
                    Id = 0
                }
            });
            Manufacturer manufacturer = new Manufacturer
            {
                PictureURL = "https://ketokotleta.ru/wp-content/uploads/1/a/0/1a046952b4481bf1f8daa22bc0d7d834.jpeg",
                Adress = "test adress2",
                Phone = "test phone2",
                Name = "test name2",
                Id = 0
            };
            ManufacturersController controller = new ManufacturersController(mock.Object);

            var result = controller.DeleteConfirmed(0);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, manufacturer.Id);
        }
        [Fact]
        public void Can_Edit_Valid_Manufacturer()
        {
            Mock<IManufacturerService> mock = new Mock<IManufacturerService>();
            mock.Setup(m => m.manufacturers).Returns(new List<Manufacturer>
            {
                new Manufacturer {
                    PictureURL = "https://ketokotleta.ru/wp-content/uploads/1/a/0/1a046952b4481bf1f8daa22bc0d7d834.jpeg",
                    Adress = "test adress",
                    Phone = "test phone",
                    Name = "test name",
                    Id = 0
                }
            });
            var controller = new ManufacturersController(mock.Object);
            Manufacturer manufacturer = new Manufacturer
            {
                PictureURL = "https://ketokotleta.ru/wp-content/uploads/1/a/0/1a046952b4481bf1f8daa22bc0d7d834.jpeg",
                Adress = "test adress2",
                Phone = "test phone2",
                Name = "test name2",
                Id = 0
            };
            var result = controller.Edit(0, manufacturer);
            var viewResult = Xunit.Assert.IsType<Task<IActionResult>>(result);
            var modelResult = Xunit.Assert.IsType<RedirectToActionResult>(viewResult.Result);
            Xunit.Assert.Equal("Index", modelResult.ActionName);
        }
        [Fact]
        public void Cannot_Delete_Not_Existed_Manufacturer()
        {
            Mock<IManufacturerService> mock = new Mock<IManufacturerService>();
            mock.Setup(m => m.manufacturers).Returns(new List<Manufacturer>
            {
                new Manufacturer {
                    PictureURL = "https://ketokotleta.ru/wp-content/uploads/1/a/0/1a046952b4481bf1f8daa22bc0d7d834.jpeg",
                    Adress = "test adress",
                    Phone = "test phone",
                    Name = "test name",
                    Id = 0
                }
            });
            var controller = new ManufacturersController(mock.Object);

            var result = controller.Delete(0);

            var viewResult = Xunit.Assert.IsType<Task<IActionResult>>(result);
            var modelResult = Xunit.Assert.IsType<ViewResult>(viewResult.Result);
            Xunit.Assert.Equal("Not Found", modelResult.ViewName);
        }
    }
}
