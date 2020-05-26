using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using WebApp.Logic;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class GoodsController : Controller
    {
        // id -> kategorijas ID
        // (int? id) -> ID var nebūt definēts, ? ir nullējams
        public IActionResult Index()
        {
                var items = ItemManager.GetAllItems().Select(i => i.ToModel()).ToList();

               return View(items);
        }

        // id -> preces ID
        public IActionResult ViewGoods(int id)
        {
            var item = ItemManager.GetItem(id).ToModel();
               
                return View(item);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new GoodsModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(GoodsModel model)
        {
            if (ModelState.IsValid)
            {
                ItemManager.CreateNewItem(model.GoodsName, model.Price, model.Description, model.Location);
                           
                        return RedirectToAction(nameof(Index));
            }
            
            return View(model);
        }
    }
}