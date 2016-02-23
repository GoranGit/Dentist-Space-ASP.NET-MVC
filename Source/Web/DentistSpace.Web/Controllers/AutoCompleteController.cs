namespace DentistSpace.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using Infrastructure.Mapping;
    using Models.AutoCompleteModels;
    using Services.Contracts;

    public class AutoCompleteController : BaseController
    {

        private IDentistService dentists;

        public AutoCompleteController(IDentistService dentists)
        {
            this.dentists = dentists;
        }

        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult AutoCompleteDentists(string term)
        {
            var entity = this.dentists.GetDentists(term);

            var result = entity.To<DentistAutoCompleteResponseModel>().ToList();

            return this.Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}