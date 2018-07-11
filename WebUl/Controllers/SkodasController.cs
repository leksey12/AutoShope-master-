using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUl.Models;

namespace WebUl.Controllers
{
    public class SkodasController : Controller
    {
        // конструктор, который объявляет зависимость от интерфейса IAutoRepository
        private ISkodaRepository repository;
        //Поле PageSize указывает, что на одной странице должны отображаться сведения о четырех товарах.
        public int pageSize = 4;
        public SkodasController(ISkodaRepository repo)
        {
            repository = repo;
        }
        // метод действия Skoda(), который создает представление
        public ViewResult Skoda(int page =1)
        {
            /*обновить метод действия Skoda() класса SkodasController так, чтобы он использовал класс SkodasSkodaViewModel 
          для снабжения представления сведениями о товарах, отображаемых на страницах, и информацией о разбиении на страницы*/
   
               SkodasSkodaViewModel model = new SkodasSkodaViewModel
            {
                Skodas = repository.Skodas
                    .OrderBy(game => game.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = repository.Skodas.Count()
                }
            };
            return View(model);
            //Внесенные изменения обеспечивают передачу объекта SkodasSkodaViewModel представлению в качестве данных модели
        }
    }
}