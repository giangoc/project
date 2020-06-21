using CafeManagement.Dao;
using CafeManagement.Models;
using System.Text;
using System.Web.Mvc;


namespace CafeManagement.Controllers
{
    public class MenuController : Controller
    {
        MenuDao dao = new MenuDao();
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
            model.Code = "D001";
            model.Price = float.Parse(model.PriceString.Replace(",", ""));
            model.IsActiveString = model.IsActive == true ? "0" : "1";
            int returnCode = dao.Add(model);
            return View();
        }
    }
}