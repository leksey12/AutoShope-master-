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
    public class UnitTestPeugeot
    {
        [TestMethod]
        public void Can_Paginate()
        { // Организация (arrange)
            Mock<IPeugeotRepository> mock = new Mock<IPeugeotRepository>();
            mock.Setup(m => m.Peugeot).Returns(new List<Peugeot>
            {
               new Peugeot { Id = 1, Name = "Игра1"},
        new Peugeot { Id = 2, Name = "Игра2"},
        new Peugeot { Id = 3, Name = "Игра3"},
        new Peugeot { Id = 4, Name = "Игра4"},
        new Peugeot { Id = 5, Name = "Игра5"}
            });
            PeugeotController controller = new PeugeotController(mock.Object);
            controller.pageSize = 3;

            // Действие (act)
            // IEnumerable<Skoda> result = (IEnumerable<Skoda>)controller.List(2).Model;
            PeugeotListViewModel result = (PeugeotListViewModel)controller.List(2).Model;

            // Утверждение (assert)
            List<Peugeot> games = result.Peugeot.ToList();
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
            Mock<IPeugeotRepository> mock = new Mock<IPeugeotRepository>();
            mock.Setup(m => m.Peugeot).Returns(new List<Peugeot>
   {
        new Peugeot { Id = 1, Name = "Игра1"},
        new Peugeot { Id = 2, Name = "Игра2"},
        new Peugeot { Id = 3, Name = "Игра3"},
        new Peugeot { Id = 4, Name = "Игра4"},
        new Peugeot { Id = 5, Name = "Игра5"}
            });
            PeugeotController controller = new PeugeotController(mock.Object);
            controller.pageSize = 3;

            // Act
            PeugeotListViewModel result
                 = (PeugeotListViewModel)controller.List(2).Model;

            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }
    }
}
