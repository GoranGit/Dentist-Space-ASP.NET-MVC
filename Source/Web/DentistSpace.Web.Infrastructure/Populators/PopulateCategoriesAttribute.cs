namespace DentistSpace.Web.Infrastructure.Populators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Services.Contracts;
    using Services.Web;

    public class PopulateCategoriesAttribute : ActionFilterAttribute
    {
        public ICacheService Cache { private get; set; }

        public ICategoryService Categories { get; set; }

        public int CashingTime { get; set; }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.Categories = this.Cache
                .Get<IEnumerable<Category>>("Categories", () => { return this.Categories.GetAll().ToList(); }, this.CashingTime);
            base.OnResultExecuting(filterContext);
        }
    }
}
