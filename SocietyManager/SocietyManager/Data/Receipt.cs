namespace SocietyManager.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Receipt")]
    public partial class Receipt
    {
        [Key]
        public int RcptId { get; set; }

        public int PmntId { get; set; }

        public int MtnId { get; set; }

        public decimal Received { get; set; }

        public DateTime RcptIssued { get; set; }

        public virtual Maintenance Maintenance { get; set; }

        public virtual Payment Payment { get; set; }
    }
}
