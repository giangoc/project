using CafeManagement.Dao;
using CafeManagement.Logic;
using CafeManagement.Models;
using System.Web.Mvc;


namespace CafeManagement.Controllers
{
    public class MenuController : Controller
    {
        MenuDao dao = new MenuDao();
        MenuLogic logic = new MenuLogic();
        // GET: MenuManagement
        public ActionResult Index()
        {
            ViewBag.Flat = 1;
            return View();
        }

        public ActionResult Add()
        {
            ViewBag.Flat = 2;
            return View();
        }

        [HttpPost]
        public ActionResult Add(MenuModel model)
        {
            ViewBag.Flat = 2;
            model.Price = float.Parse(model.PriceString.Replace(",", ""));
            model.IsActiveString = model.IsActive == true ? "0" : "1";
            model.Code = logic.CreateCode(model.IsFood);
            int returnCode = dao.Add(model);
            return View();
        }
    }
}