namespace SocietyManager.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Owner")]
    public partial class Owner
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Owner()
        {
            Payments = new HashSet<Payment>();
            Tenants = new HashSet<Tenant>();
        }

        public int OwnerId { get; set; }

        public int FlatId { get; set; }

        public int SocietyId { get; set; }

        public int? PersonId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RegistrationDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DeregistrationDate { get; set; }

        public bool? IsActive { get; set; }

        public virtual Flat Flat { get; set; }

        public virtual Person Person { get; set; }

        public virtual Society Society { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tenant> Tenants { get; set; }
    }
}
