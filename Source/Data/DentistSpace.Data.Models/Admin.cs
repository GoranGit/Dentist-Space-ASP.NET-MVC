namespace DentistSpace.Data.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using DentistSpace.Data.Common.Models;

    public class Admin : BaseModel<string>
    {
        private ICollection<Dentist> accptedDentists;

        public Admin()
        {
            this.accptedDentists = new HashSet<Dentist>();
        }

        [ForeignKey("User")]
        public override string Id
        {
            get
            {
                return base.Id;
            }

            set
            {
                base.Id = value;
            }
        }

        public virtual User User { get; set; }

        public virtual ICollection<Dentist> AcceptedDentists
        {
            get
            {
                return this.accptedDentists;
            }

            set
            {
                this.accptedDentists = value;
            }
        }
    }
}
