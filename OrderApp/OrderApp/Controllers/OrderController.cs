using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using OrderApp.Models;
using PagedList;

namespace OrderApp.Controllers
{
   
    public class OrderController : Controller
    {


        // GET: Order

        DataContext db = new DataContext();
       
        public ActionResult OrderList()
        {
            return View();
        }

        public JsonResult GetOrders()
        {
            var result = db.Orders.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
      
        // GET: Order/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Order/Create
        [HttpPost]
        public JsonResult Create(Order order)
        {
            try
            {
                order.DateCreate = DateTime.Now;
                order.DateAdd = DateTime.Now.AddMonths(2);
                order.Old = false;
                db.Orders.Add(order);
                db.SaveChanges();
                return Json(new { status = "Ваш заказ успешно добавлен." });            
            }
            catch
            {
                return Json(new { status = "Произошла ошибка!Повторите заказ." });
                
            }
          
        }
        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Order/Delete/5
        [HttpPost]
        public JsonResult DeleteOrder(int id)
        {
            try
            {
                var order = db.Orders.Find(id);
                db.Orders.Remove(order);
                db.SaveChanges();
                return Json(new { status = "Заказ удален" });
               
            }
            catch
            {
                return Json(new { status = "Произошла ошибка" });
            }
        }
    }
}
