using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUl.Models;

namespace WebUl.Controllers
{
    public class LadaController : Controller
    {
        // конструктор, который объявляет зависимость от интерфейса IAutoRepository
        private ILadaRepository repository;
        public int pageSize = 4;
        public LadaController(ILadaRepository repo)
        {
            repository = repo;
        }
        // метод действия List(), который создает представление
        public ViewResult List(int page = 1)
        {
            /*обновить метод действия Skoda() класса SkodasController так, чтобы он использовал класс SkodasSkodaViewModel 
          для снабжения представления сведениями о товарах, отображаемых на страницах, и информацией о разбиении на страницы*/

            LadaListViewModel model = new LadaListViewModel
            {
               Lada = repository.Lada
                     .OrderBy(game => game.Id)
                     .Skip((page - 1) * pageSize)
                     .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = repository.Lada.Count()
                }
            };
            return View(model);
            //Внесенные изменения обеспечивают передачу объекта SkodasSkodaViewModel представлению в качестве данных модели
        }
    }
}