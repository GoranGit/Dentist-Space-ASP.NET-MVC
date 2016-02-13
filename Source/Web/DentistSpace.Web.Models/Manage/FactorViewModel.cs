namespace DentistSpace.Web.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security;

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }
}