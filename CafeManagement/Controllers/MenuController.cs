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
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(MenuModel model)
        {          
            model.Price = float.Parse(model.PriceString.Replace(",", ""));
            model.IsActiveString = model.IsActive == true ? "0" : "1";
            model.Code = logic.CreateCode(model.IsFood);
            int returnCode = dao.Add(model);
            return View();
        }
    }
}