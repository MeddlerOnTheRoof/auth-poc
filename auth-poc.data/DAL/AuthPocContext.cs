using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace auth_poc.data.DAL
{
    public partial class AuthPocContext : DbContext
    {
        public virtual DbSet<ArmorType> ArmorType { get; set; }
        public virtual DbSet<AttackType> AttackType { get; set; }
        public virtual DbSet<Build> Build { get; set; }
        public virtual DbSet<Civilization> Civilization { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
        public virtual DbSet<UnitArmor> UnitArmor { get; set; }
        public virtual DbSet<UnitType> UnitType { get; set; }
        public virtual DbSet<UserAccount> UserAccount { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\MSSQLSERVER01;Database=AuthPoc;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArmorType>(entity =>
            {
                entity.HasIndex(e => e.ArmorTypeName)
                    .HasName("uq_ArmorType_ArmorTypeName")
                    .IsUnique();

                entity.Property(e => e.ArmorTypeName)
                    .IsRequired()
                    .HasColumnType("varchar(25)");

                entity.Property(e => e.CreatedByDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedByUser)
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.ModifiedByDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedByUser)
                    .IsRequired()
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<AttackType>(entity =>
            {
                entity.HasIndex(e => e.ArmorTypeId)
                    .HasName("uq_AttackType_ArmorTypeId")
                    .IsUnique();

                entity.HasIndex(e => e.AttackTypeName)
                    .HasName("uq_AttackType_AttackTypeName")
                    .IsUnique();

                entity.Property(e => e.AttackTypeName)
                    .IsRequired()
                    .HasColumnType("varchar(25)");

                entity.Property(e => e.CreatedByDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedByUser)
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.ModifiedByDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedByUser)
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.HasOne(d => d.ArmorType)
                    .WithOne(p => p.AttackType)
                    .HasForeignKey<AttackType>(d => d.ArmorTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_AttackType_ArmorType");
            });

            modelBuilder.Entity<Build>(entity =>
            {
                entity.HasIndex(e => new { e.BuilderId, e.UnitId })
                    .HasName("uq_Build_BuilderId_UnitId")
                    .IsUnique();

                entity.Property(e => e.CreatedByDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedByUser)
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.ModifiedByDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedByUser)
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.HasOne(d => d.Builder)
                    .WithMany(p => p.BuildBuilder)
                    .HasForeignKey(d => d.BuilderId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_Build_Builder");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.BuildUnit)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_Build_Unit");
            });

            modelBuilder.Entity<Civilization>(entity =>
            {
                entity.HasIndex(e => e.CivilizationName)
                    .HasName("uq_Civilization_CivilizationName")
                    .IsUnique();

                entity.Property(e => e.CivilizationDescription)
                    .IsRequired()
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.CivilizationName)
                    .IsRequired()
                    .HasColumnType("varchar(25)");

                entity.Property(e => e.CreatedByDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedByUser)
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.ModifiedByDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedByUser)
                    .IsRequired()
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.HasIndex(e => e.UnitName)
                    .HasName("uq_Unit_UnitName")
                    .IsUnique();

                entity.Property(e => e.CreatedByDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedByUser)
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.ModifiedByDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedByUser)
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasColumnType("varchar(25)");

                entity.HasOne(d => d.AttackType)
                    .WithMany(p => p.Unit)
                    .HasForeignKey(d => d.AttackTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_Unit_AttackType");

                entity.HasOne(d => d.UnitType)
                    .WithMany(p => p.Unit)
                    .HasForeignKey(d => d.UnitTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_Unit_UnitType");
            });

            modelBuilder.Entity<UnitArmor>(entity =>
            {
                entity.Property(e => e.CreatedByDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedByUser)
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.ModifiedByDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedByUser)
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.HasOne(d => d.ArmorType)
                    .WithMany(p => p.UnitArmor)
                    .HasForeignKey(d => d.ArmorTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_UnitArmor_ArmorType");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.UnitArmor)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_UnitArmor_Unit");
            });

            modelBuilder.Entity<UnitType>(entity =>
            {
                entity.HasIndex(e => e.UnitTypeName)
                    .HasName("uq_UnitType_UnitTypeName")
                    .IsUnique();

                entity.Property(e => e.CreatedByDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedByUser)
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.ModifiedByDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedByUser)
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.UnitTypeName)
                    .IsRequired()
                    .HasColumnType("varchar(25)");
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.HasIndex(e => e.UserAccountName)
                    .HasName("uq_UserAccount_UserAccountName")
                    .IsUnique();

                entity.Property(e => e.CreatedByDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedByUser)
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.ModifiedByDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedByUser)
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.UserAccountName)
                    .IsRequired()
                    .HasColumnType("varchar(25)");

                entity.Property(e => e.UserAccountPassword)
                    .IsRequired()
                    .HasColumnType("varchar(16)");

                entity.HasOne(d => d.UserRole)
                    .WithMany(p => p.UserAccount)
                    .HasForeignKey(d => d.UserRoleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_UserAccount_UserRole");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasIndex(e => e.UserRoleName)
                    .HasName("uq_UserRole_UserRoleName")
                    .IsUnique();

                entity.Property(e => e.CreatedByDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedByUser)
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.ModifiedByDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedByUser)
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.UserRoleName)
                    .IsRequired()
                    .HasColumnType("varchar(25)");
            });
        }
    }
}