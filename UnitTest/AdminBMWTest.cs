using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Domain.Abstract;
using Domain.AutoShop;
using WebUl.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace UnitTest
{
    [TestClass]
    public class AdminBMWTest
    {
        [TestMethod]
        public void Index_Contains_All_Games()
        {
            // Организация - создание имитированного хранилища данных
            Mock<IBMWRepository> mock = new Mock<IBMWRepository>();
            mock.Setup(m => m.BMWs).Returns(new List<BMW>
            {
                new BMW { Id = 1, Name = "Игра1"},
                new BMW { Id = 2, Name = "Игра2"},
                new BMW { Id = 3, Name = "Игра3"},
                new BMW { Id = 4, Name = "Игра4"},
                new BMW { Id = 5, Name = "Игра5"}
            });

            // Организация - создание контроллера
            AdminBMWController controller = new AdminBMWController(mock.Object);

            // Действие
            List<Skoda> result = ((IEnumerable<Skoda>)controller.Index().
                ViewData.Model).ToList();

            // Утверждение
            Assert.AreEqual(result.Count(), 5);
            Assert.AreEqual("Игра1", result[0].Name);
            Assert.AreEqual("Игра2", result[1].Name);
            Assert.AreEqual("Игра3", result[2].Name);
        }
        [TestMethod]
        public void Can_Edit_Game()
        {
            // Организация - создание имитированного хранилища данных
            Mock<IBMWRepository> mock = new Mock<IBMWRepository>();
            mock.Setup(m => m.BMWs).Returns(new List<BMW>
    {
        new BMW { Id = 1, Name = "Игра1"},
        new BMW { Id = 2, Name = "Игра2"},
        new BMW { Id = 3, Name = "Игра3"},
        new BMW { Id = 4, Name = "Игра4"},
        new BMW { Id = 5, Name = "Игра5"}
    });

            // Организация - создание контроллера
            AdminBMWController controller = new AdminBMWController(mock.Object);

            // Действие
            BMW game1 = controller.Edit(1).ViewData.Model as BMW;
            BMW game2 = controller.Edit(2).ViewData.Model as BMW;
            BMW game3 = controller.Edit(3).ViewData.Model as BMW;

            // Assert
            Assert.AreEqual(1, game1.Id);
            Assert.AreEqual(2, game2.Id);
            Assert.AreEqual(3, game3.Id);
        }

        [TestMethod]
        public void Cannot_Edit_Nonexistent_Game()
        {
            // Организация - создание имитированного хранилища данных
            Mock<IBMWRepository> mock = new Mock<IBMWRepository>();
            mock.Setup(m => m.BMWs).Returns(new List<BMW>
    {
        new BMW { Id = 1, Name = "Игра1"},
        new BMW { Id = 2, Name = "Игра2"},
        new BMW { Id = 3, Name = "Игра3"},
        new BMW { Id = 4, Name = "Игра4"},
        new BMW { Id = 5, Name = "Игра5"}
    });

            // Организация - создание контроллера
            AdminBMWController controller = new AdminBMWController(mock.Object);

            // Действие
            BMW result = controller.Edit(6).ViewData.Model as BMW;

            // Assert
        }
        [TestMethod]
        public void Can_Save_Valid_Changes()
        {
            // Организация - создание имитированного хранилища данных
            Mock<IBMWRepository> mock = new Mock<IBMWRepository>();

            // Организация - создание контроллера
            AdminBMWController controller = new AdminBMWController(mock.Object);

            // Организация - создание объекта Game
            BMW game = new BMW { Name = "Test" };

            // Действие - попытка сохранения товара
            ActionResult result = controller.Edit(game);

            // Утверждение - проверка того, что к хранилищу производится обращение
            mock.Verify(m => m.SaveBMW(game));

            // Утверждение - проверка типа результата метода
            Assert.IsNotInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Cannot_Save_Invalid_Changes()
        {
            // Организация - создание имитированного хранилища данных
            Mock<IBMWRepository> mock = new Mock<IBMWRepository>();

            // Организация - создание контроллера
            AdminBMWController controller = new AdminBMWController(mock.Object);

            // Организация - создание объекта Game
            BMW game = new BMW { Name = "Test" };

            // Организация - добавление ошибки в состояние модели
            controller.ModelState.AddModelError("error", "error");

            // Действие - попытка сохранения товара
            ActionResult result = controller.Edit(game);

            // Утверждение - проверка того, что обращение к хранилищу НЕ производится 
            mock.Verify(m => m.SaveBMW(It.IsAny<BMW>()), Times.Never());

            // Утверждение - проверка типа результата метода
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
        [TestMethod]
        public void Can_Delete_Valid_Games()
        {
            // Организация - создание объекта Game
            BMW game = new BMW { Id = 2, Name = "Игра2" };

            // Организация - создание имитированного хранилища данных
            Mock<IBMWRepository> mock = new Mock<IBMWRepository>();
            mock.Setup(m => m.BMWs).Returns(new List<BMW>
    {
        new BMW { Id = 1, Name = "Игра1"},
        new BMW { Id = 2, Name = "Игра2"},
        new BMW { Id = 3, Name = "Игра3"},
        new BMW { Id = 4, Name = "Игра4"},
        new BMW { Id = 5, Name = "Игра5"}
    });

            // Организация - создание контроллера
            AdminBMWController controller = new AdminBMWController(mock.Object);

            // Действие - удаление игры
            controller.Delete(game.Id);

            // Утверждение - проверка того, что метод удаления в хранилище
            // вызывается для корректного объекта Game
            mock.Verify(m => m.DeleteBMW(game.Id));
        }
    }
}
