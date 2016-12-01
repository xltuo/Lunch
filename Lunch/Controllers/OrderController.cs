using Lunch.App_Start;
using Lunch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lunch.Controllers
{
    [LoginFilter]
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult AdminList()
        {
            return View();
        }

        public ActionResult Add(Order order)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", order);
            }
            var Name = User.Identity.Name;
            DbEntities db = new DbEntities();
            var userinfo = db.Set<User>().FirstOrDefault(S => S.Name == Name);
            if (userinfo == null)
            {
                ModelState.AddModelError("", "获取用户失败，无法下单。");
                return View("Index", order);
            }
            var neworder = new Order();
            neworder.Id = Guid.NewGuid().ToString();

            neworder.CreateDate = DateTime.Now;
            neworder.UserID = userinfo.Id;
            neworder.UserName = userinfo.UserName;
            neworder.OrderDate = order.OrderDate;
            neworder.BusinessName = order.BusinessName;
            neworder.DishName = order.DishName;
            neworder.Price = order.Price;
            neworder.Remark = order.Remark;
            neworder.Ispay = false;
            db.Order.Add(neworder);
            db.SaveChanges();
            return View("List");
        }

        public JsonResult Pay()
        {
            var id = Request.QueryString["ID"];
            DbEntities db = new DbEntities();
            var ety = db.Order.FirstOrDefault(s => s.Id == id);
            ety.Ispay = true;
            db.SaveChanges();
            return Json("ok");
        }

        public JsonResult Del()
        {
            var id = Request.QueryString["ID"];
            DbEntities db = new DbEntities();
            var ety = db.Order.FirstOrDefault(s => s.Id == id);
            db.Order.Remove(ety);
            db.SaveChanges();
            return Json("ok");
        }
    }
}