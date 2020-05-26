using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShop.Logic;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new HomeModel();

            // atlasa visas kategorijas no DB - modeļa vietā
            // izmanto metodi GetAll() no CategoryManager šī modeļa aizpildei
            // jāizveido atsevišķa statiska klase, kas nodrošina Mapping 

            model.Categories = CategoryManager.GetAll().Select(c => c.ToModel()).ToList();
            model.Items = ItemManager.GetAll().Select(i => i.ToModel()).ToList();

            foreach(var cat in model.Categories)
            {
                cat.ItemCount = CategoryManager.GetItemCount(cat.Id);
            }
              
            return View(model);
        }
        
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
