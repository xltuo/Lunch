using Lunch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lunch.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Add(Order order)
        {
            DbEntities db = new DbEntities();
            order.Id = Guid.NewGuid().ToString();
            order.CreateDate = DateTime.Now;
            db.Order.Add(order);
            db.SaveChanges();
            return null;
        }
    }
}