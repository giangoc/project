using CafeManagement.Models;
using System.Web.Mvc;


namespace CafeManagement.Controllers
{
    public class MenuController : Controller
    {
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
            return View();
        }
    }
}