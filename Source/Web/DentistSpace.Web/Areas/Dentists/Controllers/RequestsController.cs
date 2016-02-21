namespace DentistSpace.Web.Areas.Dentists.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class RequestsController : Controller
    {
        // GET: Dentists/Requests
        public ActionResult Index()
        {
            return View();
        }
    }
}