namespace DentistSpace.Web.Areas.Patients.Controllers
{
    using System.Web.Mvc;
    using Services.Contracts;
    using Models.Patients;
    using Web.Controllers;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Infrastructure.ModelFilters;

    public class RequestController : BaseController
    {
        private IRequestService requests;

        public RequestController(IRequestService requests)
        {
            this.requests = requests;
        }

        // GET: Patients/PatientRequests
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "Make patient request to you dentist";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateModelState]
        public ActionResult Index(InputParientRequestViewModel request)
        {
            var result = this.Mapper.Map<PatientRequest>(request);
            result.UserId = this.User.Identity.GetUserId();
            this.requests.AddPatientRequest(result);
            return this.RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}