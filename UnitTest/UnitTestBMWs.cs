using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Abstract;
using Domain.AutoShop;
using System.Web.Mvc;
using WebUl.HtmlHelpers;
using Moq;
using WebUl.Controllers;
using WebUl.Models;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class UnitTestBMWs
    {
        [TestMethod]
        public void Can_Paginate()
        { // Организация (arrange)
          // Организация (arrange)
            Mock<IBMWRepository> mock = new Mock<IBMWRepository>();
            mock.Setup(m => m.BMWs).Returns(new List<BMW>
    {
        new BMW { Id = 1, Name = "Игра1"},
        new BMW { Id = 2, Name = "Игра2"},
        new BMW { Id = 3, Name = "Игра3"},
        new BMW { Id = 4, Name = "Игра4"},
        new BMW { Id = 5, Name = "Игра5"}
    });
            BMWsController controller = new BMWsController(mock.Object);
            controller.pageSize = 3;

            // Act
            BMWsListViewModel result
                 = (BMWsListViewModel)controller.List(2).Model;

            // Утверждение (assert)
            List<BMW> games = result.BMWs.ToList();
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
            Mock<IBMWRepository> mock = new Mock<IBMWRepository>();
            mock.Setup(m => m.BMWs).Returns(new List<BMW>
    {
        new BMW { Id = 1, Name = "Игра1"},
        new BMW { Id = 2, Name = "Игра2"},
        new BMW { Id = 3, Name = "Игра3"},
        new BMW { Id = 4, Name = "Игра4"},
        new BMW { Id = 5, Name = "Игра5"}
    });
            BMWsController controller = new BMWsController(mock.Object);
            controller.pageSize = 3;

            // Act
            BMWsListViewModel result
                 = (BMWsListViewModel)controller.List(2).Model;

            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }
    }
}
