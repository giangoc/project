﻿using CafeManagement.Dao;
using CafeManagement.Logic;
using CafeManagement.Models;
using System.Collections.Generic;
using System.Web.Mvc;


namespace CafeManagement.Controllers
{
    public class MenuController : Controller
    {
        readonly MenuDao dao = new MenuDao();
        readonly MenuLogic logic = new MenuLogic();
        // GET: MenuManagement
        public ActionResult Index()
        {
            List<MenuModel> listModel = dao.GetMenu();
            return View(listModel);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(MenuModel model)
        {
            model.Price = float.Parse(model.PriceString.Replace(",", ""));
            model.IsActive = model.IsActiveBool == true ? "0" : "1";
            model.Code = logic.CreateCode(model.IsFood);
            int returnCode = dao.Add(model);
            return View();
        }
    }
}