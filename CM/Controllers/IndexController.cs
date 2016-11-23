using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CM.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.Ajax;
namespace CM.Controllers
{
    public class IndexController : Controller
    {
        private CrownContext db = new CrownContext();
        
            public ActionResult Index(string sortOrder)
            {

            //var cate = from s in db.Cat
            //                select s;

            //return View(cate.ToList());

            return View();

        }





        public JsonResult GetCate()
    {
        var cate = from s in db.Cat
                   select s;
       
        var result = cate.ToList();
        return Json(result, JsonRequestBehavior.AllowGet);

    }
    
        }

    








}
