using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApp.Logic;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
                var categories = CategoryManager.GetAllCategories().Select(c => c.ToModel()).ToList();

                return View(categories);
        }

        // lietotāja meklēšana
        public IActionResult ViewCat(int id)
        {
                var category = CategoryManager.GetCategory(id).ToModel();

                return View(category);
        }

        [HttpGet]
        public IActionResult AddCat()
        {
            var category = new CategoriesModel();

            return View(category);
        }

        [HttpPost]
        public IActionResult AddCat(CategoriesModel model)
        {
            // pārbauda vai ir ievadīti derīgi dati
            if (ModelState.IsValid)
            {
                // VISS OK - modelis ir derīgs, var veikt datu saglabāšanu
                // insert into Users(Email, Phone, Name)
                // values(@email, @phone, @name)
                // COMMIT;

                CategoryManager.CreateNewCategory(model.Name);

                    // aizsūtam viņu atpakaļ uz user list
                    return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}