using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DentistSpace.Data.Common.Models;
namespace DentistSpace.Data.Models
{
    public class Message : BaseModel<int>
    {
        [Required]
        public string Content { get; set; }

        [ForeignKey("UserFrom")]
        public string UserFromId { get; set; }

        public virtual User UserFrom { get; set; }

        [ForeignKey("UserTo")]
        public string UserToId { get; set; }

        public virtual User UserTo { get; set; }
    }
}
