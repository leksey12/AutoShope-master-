using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Abstract;
using Moq;
using Domain.AutoShop;
using WebUl.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebUl.Models;
using WebUl.HtmlHelpers;
namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        { // Организация (arrange)
            Mock<ISkodaRepository> mock = new Mock<ISkodaRepository>();
            mock.Setup(m => m.Skodas).Returns(new List<Skoda>
            {
                new Skoda { Id = 1, Name = "Игра1"},
                new Skoda { Id = 2, Name = "Игра2"},
                new Skoda { Id = 3, Name = "Игра3"},
                new Skoda { Id = 4, Name = "Игра4"},
                new Skoda { Id = 5, Name = "Игра5"}
            });
            SkodasController controller = new SkodasController(mock.Object);
            controller.pageSize = 3;

            // Действие (act)
            // IEnumerable<Skoda> result = (IEnumerable<Skoda>)controller.Skodas(2).Model;
            SkodasSkodaViewModel result = (SkodasSkodaViewModel)controller.Skoda(2).Model;

            // Утверждение (assert)
            List<Skoda> games = result.Skodas.ToList();
            Assert.IsTrue(games.Count == 2);
            Assert.AreEqual(games[0].Name, "Игра4");
            Assert.AreEqual(games[1].Name, "Игра5");
        }
//создание ссылок на страницы
        [TestMethod]
        public void Can_Generate_Page_Links()
        {

            // Организация - определение вспомогательного метода HTML - это необходимо
            // для применения расширяющего метода
            HtmlHelper myHelper = null;

            // Организация - создание объекта PagingInfo
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };

            // Организация - настройка делегата с помощью лямбда-выражения
            Func<int, string> pageUrlDelegate = i => "Page" + i;

            // Действие
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            // Утверждение
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
                + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
                + @"<a class=""btn btn-default"" href=""Page3"">3</a>",
                result.ToString());
        }
        [TestMethod]
//удостоверяемся, что контроллер отправляет представлению правильную информацию о разбиении на страницы
        public void Can_Send_Pagination_View_Model()
        {
            // Организация (arrange)
            Mock<ISkodaRepository> mock = new Mock<ISkodaRepository>();
            mock.Setup(m => m.Skodas).Returns(new List<Skoda>
    {
        new Skoda { Id = 1, Name = "Игра1"},
        new Skoda { Id = 2, Name = "Игра2"},
        new Skoda { Id = 3, Name = "Игра3"},
        new Skoda { Id = 4, Name = "Игра4"},
        new Skoda { Id = 5, Name = "Игра5"}
    });
            SkodasController controller = new SkodasController(mock.Object);
            controller.pageSize = 3;

            // Act
            SkodasSkodaViewModel result
                = (SkodasSkodaViewModel)controller.Skoda(2).Model;

            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }
    }
}
