namespace DentistSpace.Web.Areas.Dentists
{
    using System.Web.Mvc;

    public class DentistsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Dentists";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Dentists_default",
                "Dentists/{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "DentistSpace.Web.Areas.Dentists.Controllers" }
            );
        }
    }
}