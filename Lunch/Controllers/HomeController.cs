using Lunch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Lunch.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home


        public ViewResult Index()
        {
            return View();
        }


        public ViewResult Register()
        {
            return View();
        }



        public ActionResult Login(User user)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", user);
            }
            DbEntities db = new DbEntities();
            var userInfo = db.User.FirstOrDefault(s => s.Name == user.Name);
            if (userInfo != null && userInfo.Pwd == user.Pwd)
            {
                FormsAuthentication.SetAuthCookie(userInfo.Name, false);
                return RedirectToAction("Index", "Order");
            }
            else
            {
                ModelState.AddModelError("", "无效的登录尝试。");
            }
            return View("Index", user);
        }



        public ActionResult DoRegister(User user)
        {
            if (!ModelState.IsValid)
            {
                return View("Register", user);
            }
            DbEntities db = new DbEntities();
            var list = db.User.ToList();
            if (list.FirstOrDefault(s => s.Name == user.Name) != null)
            {
                ModelState.AddModelError("", "该用户名已被注册");
                return View("Register", user);
            }
            user.Id = Guid.NewGuid().ToString();
            user.CreateTime = DateTime.Now;
            db.User.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}