using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ManageInvoiceService.Models
{
    public partial class VirtuagymFinancialTestContext : DbContext
    {


        public VirtuagymFinancialTestContext(DbContextOptions<VirtuagymFinancialTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<InvoiceStatus> InvoiceStatus { get; set; }
        public virtual DbSet<Invoices> Invoices { get; set; }
        public virtual DbSet<Memberships> Memberships { get; set; }
        public virtual DbSet<Users> Users { get; set; }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvoiceStatus>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Invoices>(entity =>
            {
                entity.HasKey(e => e.InvoiceId)
                    .HasName("PK__Invoices__D796AAB585F151CF");

                entity.HasIndex(e => e.InvoiceNumber)
                    .HasName("invoice_number")
                    .IsUnique();

                entity.Property(e => e.InvoiceAmount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.InvoiceDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.InvoiceStatus)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.InvoiceStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Invoices__Invoic__36B12243");

                entity.HasOne(d => d.Membership)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.MembershipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Invoices__Member__35BCFE0A");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Invoices__UserId__34C8D9D1");
            });

            modelBuilder.Entity<Memberships>(entity =>
            {
                entity.HasKey(e => e.MembershipId)
                    .HasName("PK__Membersh__92A78679C3A38E24");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.MembershipCredits)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MembershipStatus)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Memberships)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Membershi__UserI__31EC6D26");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__1788CC4C7939A0CA");

                entity.HasIndex(e => new { e.FirstName, e.LastName, e.ContactNumber })
                    .HasName("usr_info")
                    .IsUnique();

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
