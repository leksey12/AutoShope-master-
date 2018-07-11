using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.AutoShop;

namespace WebUl.Controllers
{
    public class AdminLadaController : Controller
    {
        ILadaRepository repository;

        public AdminLadaController(ILadaRepository repo)
        {
            repository = repo;
        }

        //public ViewResult Index()
        //{
        //    return View(repository.Lada);
        //}
        public ViewResult Index(string sortOrder)
        {
            ViewBag.ModelSortParm = String.IsNullOrEmpty(sortOrder) ? "model_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";
            var students = from s in repository.Lada
                           select s;
            switch (sortOrder)
            {
                case "model_desc":
                    students = students.OrderByDescending(s => s.Model);
                    break;
                case "Price":
                    students = students.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    students = students.OrderByDescending(s => s.Price);
                    break;
                default:
                    students = students.OrderBy(s => s.Model);
                    break;
            }
            return View(students.ToList());
        }
        public ViewResult Edit(int Id)
        {
            Lada game = repository.Lada
                 .FirstOrDefault(g => g.Id == Id);
            return View(game);
        }
        // Перегруженная версия Edit() для сохранения изменений
        [HttpPost]
        public ActionResult Edit(Lada game)
        {
            if (ModelState.IsValid)
            {
                repository.SaveLada(game);
                TempData["message"] = string.Format("Изменения в ВИКИНГИ \"{0} {1}\" были сохранены", game.Name, game.Model);
                return RedirectToAction("Index");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(game);
            }
        }
             public ViewResult Create()
        {
            return View("Edit", new Lada());
        }
        [HttpPost]
        public ActionResult Delete(int Id)
        {
            Lada deletedLada = repository.DeleteLada(Id);
            if (deletedLada != null)
            {
                TempData["message"] = string.Format("Машина \"{0}\" была удалена",
                    deletedLada.Name);
            }
            return RedirectToAction("Index");
        }

    }
}