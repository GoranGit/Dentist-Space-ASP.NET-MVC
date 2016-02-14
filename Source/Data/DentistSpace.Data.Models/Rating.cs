namespace DentistSpace.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using DentistSpace.Data.Common.Models;

    public class Rating : BaseModel<int>
    {
        [Range(1, 5, ErrorMessage ="Rating must be  between 1 and 5 inclusive!")]
        public int Value { get; set; }

        public string UserId { get; set; }

        public virtual Patient User { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}