namespace DentistSpace.Web.Models.Posts
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;

    public class InputPostViewModel : IMapTo<Post>
    {
        [Required]
        [MinLength(10)]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        [MinLength(200)]
        [MaxLength(3000)]
        public string Content { get; set; }

        public bool IsPublic { get; set; }

        [Required]
        public string Image { get; set; }

        public int CategoryId { get; set; }
    }
}
