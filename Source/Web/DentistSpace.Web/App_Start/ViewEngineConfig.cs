namespace DentistSpace.Web
{
    using System.Web.Mvc;

    public class ViewEngineConfig
    {
        public static void Init()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}