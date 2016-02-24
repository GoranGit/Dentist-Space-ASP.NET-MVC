namespace DentistSpace.Web.Areas.Dentists.Controllers
{
    using System.IO;
    using System.Web.Mvc;
    using Common;
    using Data.Models;
    using Infrastructure.ModelFilters;
    using Microsoft.AspNet.Identity;
    using Models.Requests;
    using Services.Contracts;
    using Web.Controllers;

    [Authorize(Roles = Roles.User)]
    public class RequestController : BaseController
    {
        private IDentistRequestService dentistRequests;
        private const string RequestsPath = "~/App_Data/uploads/dentistsRequests/";

        public RequestController(IDentistRequestService dentistRequests)
        {
            this.dentistRequests = dentistRequests;
        }

        [HttpGet]
        public ActionResult Index()
        {
            this.ViewBag.Title = "Make dentist request to admin!";
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateModelState]
        public ActionResult Index(InputDentistRequestViewModel request)
        {
            if (request.File.ContentLength > 0)
            {
                var file = request.File;
                var fileExtension = Path.GetExtension(file.FileName);

                var dentistRequest = new DentistRequest()
                {
                    Content = request.Content,
                    UserId = this.User.Identity.GetUserId(),
                    Extension = fileExtension
                };

                this.dentistRequests.AddRequest(dentistRequest);

                var folder = dentistRequest.Id % 10;
                var realFileName = dentistRequest.FileName.ToString();

                var path = Path.Combine(this.Server.MapPath(RequestsPath + folder), realFileName + fileExtension);
                file.SaveAs(path);
            }
            else
            {
                this.TempData["ErrorMessage"] = "File can't be empty!";
            }

            //TODO: Write the right redirect view.
            return this.RedirectToAction("Index", "Home", new { area = string.Empty });
        }
    }
}