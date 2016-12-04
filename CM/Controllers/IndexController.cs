﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CM.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.Ajax;
using System.Collections;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Profile;
using System.Web.Security;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;


namespace CM.Controllers
{
    public class IndexController : Controller
    {
        private CrownContext db = new CrownContext();

        public ActionResult Index()
        {
            var Cate = from s in db.Cat
                       select s;
            
            return View(Cate.ToList());

        }

        public ActionResult Search(string SearchString)
        {
            var result = from s in db.Pro
                         select s;

            if (!String.IsNullOrEmpty(SearchString))
            {
                var Result = result.Where(s => s.Name.Contains(SearchString));

                return View(Result);
            }

            else
            { return View(); }
        }

        public JsonResult GetCate()
        {
            var cate = from s in db.Cat
                       select s;

            var result = cate.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Cate(int id)
        {
            var result = from s in db.Pro
                         where s.CategoryId == id
                         select s;

            return View(result);

        }

        public ActionResult Detail(int id)
        {
            var result = from s in db.Pro
                         where s.ProductId == id
                         select s;


            return View(result);

        }



        public ActionResult ShoppingCart(string Qty,string id,string Name)
        { 
           
            ViewBag.CurrentU = User.Identity.GetUserName();


            var myprofile = Profile as ProfileCommon;

            myprofile.ProId = id;

            myprofile.ProName = Name;

            myprofile.ProQty = Qty;

            ViewBag.Id = myprofile.ProId;
            ViewBag.Name = myprofile.ProName;
            ViewBag.Qty = myprofile.ProQty;

            int idint= Int32.Parse(id);
            var result = from s in db.Pro
                         where s.ProductId == idint
                         select s;
            var Resu = result.First();
            int Qtyint = Int32.Parse(Qty);
            System.Decimal Totalpri = Resu.Listprice * Qtyint;
            ViewBag.TotalPrice = Totalpri;

            return View();
        }
    }
}
