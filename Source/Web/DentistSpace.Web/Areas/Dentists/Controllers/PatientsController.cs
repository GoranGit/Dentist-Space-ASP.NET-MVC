namespace DentistSpace.Web.Areas.Dentists.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Common;
    using DentistSpace.Data.Models;
    using DentistSpace.Services.Contracts;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNet.Identity;
    using Models.Requests;
    using Web.Controllers;

    [Authorize(Roles =Roles.Dentist)]
    public class PatientsController : BaseController
    {
       // private DentistSpaceDbContext db = new DentistSpaceDbContext();
        private IRequestService requests;
        private IPatientService patients;
        private IDentistService dentists;

        public PatientsController(IRequestService requests, IPatientService patients, IDentistService dentists)
        {
            this.requests = requests;
            this.patients = patients;
            this.dentists = dentists;
        }

        public ActionResult Requests()
        {
            this.ViewBag.Title = "Patients requests";
            return this.View();
        }

        public ActionResult PatientRequests_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<EditPatientRequestViewModel> patientrequests = this.requests.GetPatientsRequestsForDentist(this.User.Identity.GetUserId()).To<EditPatientRequestViewModel>();

            DataSourceResult result = patientrequests.ToDataSourceResult(request, patientRequest => new {
                Id = patientRequest.Id,
                Content = patientRequest.Content,
                IsAccepted = patientRequest.IsAccepted,
                UserId = patientRequest.UserId,
                DentistId = patientRequest.DentistId,
                PatientName = patientRequest.PatientName
            });

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult PatientRequests_Update([DataSourceRequest]DataSourceRequest request, EditPatientRequestViewModel patientRequest)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.requests.GetById(patientRequest.Id);
                entity.IsAccepted = patientRequest.IsAccepted;

                string dentistId = this.User.Identity.GetUserId();

                Dentist dentist = this.dentists.GetDentistById(dentistId);

                this.patients.CreateNewPatient(patientRequest.UserId, dentist);

                this.requests.AcceptPatientRequest(entity);
            }

            return this.Json(new[] { patientRequest }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return this.File(fileContents, contentType, fileName);
        }
    }
}
