namespace SocietyManager.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tenant")]
    public partial class Tenant
    {
        public int id { get; set; }

        public int FlatId { get; set; }

        public int OwnerId { get; set; }

        public int PersonId { get; set; }

        [Column(TypeName = "date")]
        public DateTime RegistrationDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DeregistrationDate { get; set; }

        public bool IsActive { get; set; }

        public virtual Flat Flat { get; set; }

        public virtual Owner Owner { get; set; }

        public virtual Person Person { get; set; }
    }
}
