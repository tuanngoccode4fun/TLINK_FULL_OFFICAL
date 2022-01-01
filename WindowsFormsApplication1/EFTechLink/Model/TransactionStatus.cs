namespace EFTechLink
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WMS.TransactionStatus")]
    public partial class TransactionStatus
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public TransactionStatus()
        //{
        //    ImportTransactions = new HashSet<ImportTransaction>();
        //}

        [Key]
        public int TransactionStatusId { get; set; }

        [Required]
        [StringLength(10)]
        public string StatusName { get; set; }

        public DateTimeOffset LastModifiedDateTimeOffset { get; set; }

        [Required]
        [StringLength(50)]
        public string LastModifiedUser { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] VersionNumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImportTransaction> ImportTransactions { get; set; }
    }
}
