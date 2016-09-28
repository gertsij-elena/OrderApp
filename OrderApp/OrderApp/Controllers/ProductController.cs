using System.Linq;
using System.Web.Mvc;
using OrderApp.Models;

namespace Solution.Controllers
{
    public class ProductController : Controller
    {
        DataContext db = new DataContext();
        // GET: Product
        public JsonResult GetProducts()
        {
            var result = db.Products.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetSumma(Product product)
        {
            if (product != null) {
            var id = product.ProductId;
            var pr = db.Products.Find(id);
            var price = pr.Price;
            var count = product.Count;
            var summa = price * count;
            var result = summa.ToString();
                return Json(result, JsonRequestBehavior.AllowGet);
                //return Json(new { status = "Ваш заказ успешно добавлен." });
            }
            else
            {
                var result = "Не выбран товар или не указано количество";
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
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

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
