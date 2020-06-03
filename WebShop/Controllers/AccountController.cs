using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShop.Logic;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult SignUp()
        {
            var model = new UserModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult SignUp(UserModel model)
        {
            if(ModelState.IsValid)
            {
                // pārbaude - vai paroles sakrīt?
                // vai lietotājs ar e-pastu jau eksistē?

                if(model.Password != model.PasswordRepeat)
                {
                    ModelState.AddModelError("pass", "Passwords do not match!");
                }
                else
                {
                    //  user atlase no DB tikai pēc email. Izmanto UserManager.

                    UserModel user = UserManager.GetByEmail(model.Email).ToModel();

                    if(user != null)
                    {
                        ModelState.AddModelError("pass", "User with this e-mail already exists!!");
                    }
                    else
                    {
                        //  saglabāt ievadītos datus DB. Izm. UserManager.
                        UserManager.Create(model.Email, model.Name, model.Password);

                        return RedirectToAction(nameof(SignIn));
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            var model = new LoginModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult SignIn(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                //  user atlase no DB pēc epasta un paroles. izm. UserManager.

                UserModel user = UserManager.GetByEmailAndPassword(model.Email, model.Password).ToModel();

                    if (user == null)
                    {
                        ModelState.AddModelError("pass", "Invalid e-mail/password!!");
                    }
                    else
                    {
                           //   saglabā user datus sesijā
                    
                         HttpContext.Session.SetUserName(user.Name);
                         HttpContext.Session.SetUserId(user.Id);
                         HttpContext.Session.SetIsAdmin(user.IsAdmin);

                    return RedirectToAction("Index", "Home");
                    }
            }

            return View(model);
        }

        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult MyCart()
        {
            // veikt user groza atlasi no DB, izm. UserCartManager.GetByUser()

            var userCart = UserCartManager.GetByUser(HttpContext.Session.GetUserId());

            // pārvērš par modeļiem un attēlot user groza saturu (tikai preces), izm. MyCart skatu.
            // grupē pēc ItemId un skaita preces, cik tās ir

            var items = userCart.Select(c => c.Item.ToModel())
                .GroupBy(i => i.Id)
                .Select(g =>
                {
                    var item = g.First();
                    item.ItemCount = g.Count();

                    return item;
                }).ToList();

            return View(items);
        }

        public IActionResult Confirm(int id)
        {
            // pārbauda, ka lietotājs ir pieslēdzies

            UserCartManager.RemoveByUser(HttpContext.Session.GetUserId());
            TempData["message"] = "Your order has been successfully received!";

            return RedirectToAction(nameof(MyCart));
        }

        [HttpGet]
        public IActionResult DeleteItemFromCart(int id)
        {
            // nepieciešams norādīt arī UserId no sesijas, lai nedzēstu cita lietotāja preces.

            UserCartManager.RemoveByItem(HttpContext.Session.GetUserId(), id);
            TempData["message"] = "Item removed!";

            return RedirectToAction(nameof(MyCart));
        }
    }
}