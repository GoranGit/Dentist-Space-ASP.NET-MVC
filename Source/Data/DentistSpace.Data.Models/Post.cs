namespace DentistSpace.Data.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using DentistSpace.Data.Common.Models;

    public class Post : BaseModel<int>
    {
        private ICollection<Image> images;
        private ICollection<Rating> ratings;

        public Post()
        {
            this.images = new HashSet<Image>();
            this.ratings = new HashSet<Rating>();
        }

        [Required]
        [MinLength(10)]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MinLength(200)]
        [MaxLength(3000)]
        public string Content { get; set; }

        [Index]
        public bool IsPublic { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string DentistId { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual Dentist Dentist { get; set; }

        public virtual ICollection<Image> Images
        {
            get
            {
                return this.images;
            }

            set
            {
                this.images = value;
            }
        }

        public virtual ICollection<Rating> Ratings
        {
            get
            {
                return this.ratings;
            }
            set
            {
                this.ratings = value;
            }
        }
    }
}
