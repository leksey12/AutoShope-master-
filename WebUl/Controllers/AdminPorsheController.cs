using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.AutoShop;

namespace WebUl.Controllers
{
    public class AdminPorsheController : Controller
    {
        IPorsheRepository repository;

        public AdminPorsheController(IPorsheRepository repo)
        {
            repository = repo;
        }

        //public ViewResult Index()
        //{
        //    return View(repository.Porshe);
        //}
        public ViewResult Index(string sortOrder)
        {
            ViewBag.ModelSortParm = String.IsNullOrEmpty(sortOrder) ? "model_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";
            var students = from s in repository.Porshe
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
            Porshe game = repository.Porshe
                 .FirstOrDefault(g => g.Id == Id);
            return View(game);
        }
        // Перегруженная версия Edit() для сохранения изменений
        [HttpPost]
        public ActionResult Edit(Porshe game)
        {
            if (ModelState.IsValid)
            {
                repository.SavePorshe(game);
                TempData["message"] = string.Format("Изменения в PORSHE \"{0} {1}\" были сохранены", game.Name, game.Model);
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
            return View("Edit", new Porshe());
        }
        [HttpPost]
        public ActionResult Delete(int Id)
        {
            Porshe deletedPorshe = repository.DeletePorshe(Id);
            if (deletedPorshe != null)
            {
                TempData["message"] = string.Format("Машина \"{0}\" была удалена",
                    deletedPorshe.Name);
            }
            return RedirectToAction("Index");
        }
    }
}