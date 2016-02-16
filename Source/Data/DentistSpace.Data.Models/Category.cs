namespace DentistSpace.Data.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using DentistSpace.Data.Common.Models;

    public class Category : BaseModel<int>
    {
        private ICollection<Post> posts;

        public Category()
        {
            this.posts = new HashSet<Post>();
        }

        public string Name { get; set; }

        public virtual ICollection<Post> Posts
        {
            get
            {
                return this.posts;
            }

            set
            {
                this.posts = value;
            }
        }
    }
}
