namespace DentistSpace.Data.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using DentistSpace.Data.Common.Models;

    public class Admin : BaseModel<int>
    {
        private ICollection<Dentist> accptedDentists;

        public Admin()
        {
            this.accptedDentists = new HashSet<Dentist>();
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
