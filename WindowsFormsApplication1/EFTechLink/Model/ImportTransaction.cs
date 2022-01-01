namespace EFTechLink
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WMS.ImportTransaction")]
    public partial class ImportTransaction
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ImportTransactionId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public string QRCode { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TransactionStatusId { get; set; }

        [StringLength(1000)]
        public string HighlightMessage { get; set; }

        [StringLength(4)]
        public string HeaderCode { get; set; }

        [StringLength(11)]
        public string HeaderNo { get; set; }

        [StringLength(4)]
        public string HeaderSTT { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(20)]
        public string ExecutedByUser { get; set; }

        [StringLength(20)]
        public string ProductionOrder { get; set; }

        [StringLength(50)]
        public string Lot { get; set; }

        [StringLength(10)]
        public string WareHouse { get; set; }

        [StringLength(20)]
        public string Location { get; set; }

        //public virtual TransactionStatus TransactionStatu { get; set; }
    }
}
