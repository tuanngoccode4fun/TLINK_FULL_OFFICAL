using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EFTechLink
{
    public partial class EFSOFTModel : DbContext
    {
        public EFSOFTModel()
            : base("name=EFSOFTModel")
        {
        }

        public virtual DbSet<TransactionStatus> TransactionStatus { get; set; }
        public virtual DbSet<ImportTransaction> ImportTransactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionStatus>()
                .Property(e => e.StatusName)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionStatus>()
                .Property(e => e.LastModifiedUser)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionStatus>()
                .Property(e => e.VersionNumber)
                .IsFixedLength();

            //modelBuilder.Entity<TransactionStatus>()
            //    .HasMany(e => e.ImportTransactions)
            //    .WithRequired(e => e.TransactionStatu)
            //    .WillCascadeOnDelete(false);

        }
    }
}
