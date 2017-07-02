namespace SocietyManager.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Society")]
    public partial class Society
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Society()
        {
            Owners = new HashSet<Owner>();
        }

        public int SocietyId { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(50)]
        public string BuilderName { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(50)]
        public string AccountNumber { get; set; }

        public int? TotalFlats { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Owner> Owners { get; set; }
    }
}
