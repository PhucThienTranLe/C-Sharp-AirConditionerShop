using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AirConditionerShop.DAL.Entities;
using Microsoft.Extensions.Configuration;

namespace AirConditionerShop.DAL
{
    public partial class AirConditionerShop2024DBContext : DbContext
    {
        public AirConditionerShop2024DBContext()
        {
        }

        public AirConditionerShop2024DBContext(DbContextOptions<AirConditionerShop2024DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AirConditioner> AirConditioners { get; set; }
        public virtual DbSet<StaffMember> StaffMembers { get; set; }
        public virtual DbSet<SupplierCompany> SupplierCompanies { get; set; }

        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            var strConn = config["ConnectionStrings:DefaultConnectionStringDB"];
            return strConn;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AirConditioner>(entity =>
            {
                entity.ToTable("AirConditioner");

                entity.Property(e => e.AirConditionerName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.FeatureFunction).HasMaxLength(250);

                entity.Property(e => e.SoundPressureLevel).HasMaxLength(80);

                entity.Property(e => e.SupplierId).HasMaxLength(20);

                entity.Property(e => e.Warranty).HasMaxLength(60);

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.AirConditioners)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__AirCondit__Suppl__29572725");
            });

            modelBuilder.Entity<StaffMember>(entity =>
            {
                entity.HasKey(e => e.MemberId)
                    .HasName("PK__StaffMem__0CF04B3865A0F031");

                entity.ToTable("StaffMember");

                entity.HasIndex(e => e.EmailAddress, "UQ__StaffMem__49A147402B08F51D")
                    .IsUnique();

                entity.Property(e => e.MemberId)
                    .ValueGeneratedNever()
                    .HasColumnName("MemberID");

                entity.Property(e => e.EmailAddress).HasMaxLength(60);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<SupplierCompany>(entity =>
            {
                entity.HasKey(e => e.SupplierId)
                    .HasName("PK__Supplier__4BE666B4F3645C4C");

                entity.ToTable("SupplierCompany");

                entity.Property(e => e.SupplierId).HasMaxLength(20);

                entity.Property(e => e.PlaceOfOrigin).HasMaxLength(60);

                entity.Property(e => e.SupplierDescription).HasMaxLength(250);

                entity.Property(e => e.SupplierName)
                    .IsRequired()
                    .HasMaxLength(80);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
