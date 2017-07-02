namespace SocietyManager.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Payment")]
    public partial class Payment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Payment()
        {
            Receipts = new HashSet<Receipt>();
        }

        [Key]
        public int PmntId { get; set; }

        public int MtnId { get; set; }

        public decimal Amount { get; set; }

        [Column(TypeName = "date")]
        public DateTime PmntDate { get; set; }

        [Required]
        [StringLength(50)]
        public string PmntMode { get; set; }

        [StringLength(50)]
        public string PmntDetail { get; set; }

        [Required]
        [StringLength(10)]
        public string PmntMadeBy { get; set; }

        public int OwnerId { get; set; }

        public virtual Maintenance Maintenance { get; set; }

        public virtual Owner Owner { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}
