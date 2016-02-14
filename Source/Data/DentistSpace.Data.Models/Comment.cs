namespace DentistSpace.Data.Models
{
    using DentistSpace.Data.Common.Models;

    public class Comment : BaseModel<int>
    {
        public string Content { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
