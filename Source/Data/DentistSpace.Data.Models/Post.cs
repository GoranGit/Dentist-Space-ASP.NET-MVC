namespace DentistSpace.Data.Models
{
    using System.Collections;
    using System.Collections.Generic;
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

        public string Content { get; set; }

        [Index]
        public bool IsPublic { get; set; }

        public int DentistId { get; set; }

        public Dentist Dentist { get; set; }

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
