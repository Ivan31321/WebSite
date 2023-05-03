using Microsoft.AspNetCore.Mvc;
using Moq;
namespace TestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Mock<IManufacturerService> mock = new Mock<IManufacturerService>();
            mock.Setup(m => m.manufacturers).Returns(new List<Manufacturer> {
                new Manufacturer {
                    PictureURL = "https://ketokotleta.ru/wp-content/uploads/1/a/0/1a046952b4481bf1f8daa22bc0d7d834.jpeg",
                    Adress = "test adress",
                    Phone = "test phone",
                    Name = "test name",
                    Id = 1,
                }
            });
            ManufacturersController controller = new ManufacturersController(mock.Object);

            var result = controller.Edit(1);
            var viewResult = Assert.IsType<Task<IActionResult>>(result);
            var modelResult = Assert.IsType<ViewResult>(viewResult.Result);
            Assert.NotEqual("Not Found", modelResult.ViewName);
        }
    }
}