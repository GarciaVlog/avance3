using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Merkur.Web.Controllers
{
    public class HomeMerkurController : Controller
    {
        // GET: HomeMerkur
        public ActionResult Index()
        {
            return View();
        }
    }
}