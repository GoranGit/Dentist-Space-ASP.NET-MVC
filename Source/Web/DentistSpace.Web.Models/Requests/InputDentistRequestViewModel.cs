namespace DentistSpace.Web.Models.Requests
{
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public class InputDentistRequestViewModel
    {
        [Required]
        [MinLength(100)]
        [MaxLength(300)]
        public string Content { get; set; }

        [Display(Name ="Upload File")]
        [Required]
        public HttpPostedFileBase File { get; set; }
    }
}
