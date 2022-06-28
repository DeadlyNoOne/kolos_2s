using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public partial class s21962Context : DbContext
    {
        public s21962Context()
        {

        }

        public s21962Context(DbContextOptions<s21962Context> options)
            : base(options)
        {

        }

        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<Membership> Membership { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<File> File { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.HasKey(e => e.OrganizationID)
                    .HasName("Organization_pk");

                entity.ToTable("Organization");

                entity.Property(e => e.OrganizationName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.OrganizationDomain)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.TeamID)
                    .HasName("Team_pk");

                entity.ToTable("Team");

                entity.HasOne(d => d.OrganizationID)
                    .WithMany(p => p.Team)
                    .HasForeignKey(d => d.OrganizationID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Team_OID");

                entity.Property(e => e.TeamName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TeamDescription)
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Membership>(entity =>
            {
                entity.HasKey(e => new { e.MemberID, e.TeamID })
                    .HasName("Membership_pk");

                entity.ToTable("Membership");

                entity.HasOne(d => d.MemberID)
                    .WithMany(p => p.Member)
                    .HasForeignKey(d => d.MemberID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Membership_MID");

                entity.HasOne(d => d.TeamID)
                    .WithMany(p => p.Team)
                    .HasForeignKey(d => d.TeamID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Membership_TID");

                entity.Property(e => e.MembershipDate).HasColumnType("datetime")
                    .IsRequired();
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasKey(e => e.MemberID)
                    .HasName("Member_pk");

                entity.ToTable("Member");

                entity.HasOne(d => d.OrganizationID)
                    .WithMany(p => p.Member)
                    .HasForeignKey(d => d.OrganizationID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Member_Org");

                entity.Property(e => e.MemberName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.MemberSurname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MembeNickName)
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.HasKey(e => e.FileID)
                    .HasName("File_pk");

                entity.ToTable("File");

                entity.HasOne(d => d.TeamID)
                    .WithMany(p => p.File)
                    .HasForeignKey(d => d.TeamID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("File_TID");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FileExtension)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.FileSize).HasColumnType("int")
                    .IsRequired();
            });
        }
    }
}
