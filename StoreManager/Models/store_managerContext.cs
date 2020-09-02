using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StoreManager.Models
{
    public partial class store_managerContext : DbContext
    {
        public store_managerContext()
        {
        }

        public store_managerContext(DbContextOptions<store_managerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bills> Bills { get; set; }
        public virtual DbSet<Dashboard> Dashboard { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Items> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=Admin;password=leela0209;database=store_manager");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bills>(entity =>
            {
                entity.ToTable("bills");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.BillDate)
                    .HasColumnName("bill_date")
                    .HasColumnType("date");

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'home'");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<Dashboard>(entity =>
            {
                entity.ToTable("dashboard");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MonthlyAmount).HasColumnName("monthly_amount");

                entity.Property(e => e.MonthlyBills).HasColumnName("monthly_bills");

                entity.Property(e => e.TotalAmount).HasColumnName("total_amount");

                entity.Property(e => e.TotalBills).HasColumnName("total_bills");

                entity.Property(e => e.TotalItems).HasColumnName("total_items");

                entity.Property(e => e.TotalWorth).HasColumnName("total_worth");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("inventory");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'home'");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Size)
                    .HasColumnName("size")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.BillId })
                    .HasName("PRIMARY");

                entity.ToTable("items");

                entity.HasIndex(e => e.BillId)
                    .HasName("bill_idx");

                entity.Property(e => e.ItemId)
                    .HasColumnName("itemId")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.BillId).HasColumnName("billId");

                entity.HasOne(d => d.Bill)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.BillId)
                    .HasConstraintName("bill0");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("inventory0");
            });

            

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
