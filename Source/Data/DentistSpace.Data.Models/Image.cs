namespace DentistSpace.Data.Models
{
    using System;
    using DentistSpace.Data.Common.Models;

    public class Image : BaseModel<int>
    {
        public Guid Title { get; set; }
    }
}