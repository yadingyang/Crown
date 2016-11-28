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

        public ActionResult Index()
        {
            var Cate = from s in db.Cat
                            select s;
          
            return View(Cate.ToList());

        }

        public ActionResult Search (string SearchString)
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
                    where s.CategoryId==id
                     select s;
                       
            return View(result);
        
    }







  }
}
