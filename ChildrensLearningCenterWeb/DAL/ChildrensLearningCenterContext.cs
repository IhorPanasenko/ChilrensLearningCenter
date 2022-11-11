using System;
using System.Collections.Generic;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL
{
    public partial class ChildrensLearningCenterContext : DbContext
    {
        public ChildrensLearningCenterContext()
        {
        }

        public ChildrensLearningCenterContext(DbContextOptions<ChildrensLearningCenterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Children> Childrens { get; set; } = null!;
        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<ClassesLog> ClassesLogs { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Direction> Directions { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<Specialist> Specialists { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=IGORPC;Database=ChildrensLearningCenter;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Children>(entity =>
            {
                entity.HasKey(e => e.ChildId)
                    .HasName("PK__Children__BEFA073668BC7B87");

                entity.Property(e => e.ChildId).HasColumnName("ChildID");

                entity.Property(e => e.BirthdayDate).HasColumnType("date");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.FirstName).HasMaxLength(20);

                entity.Property(e => e.SecondName).HasMaxLength(20);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Children)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Childrens__Clien__267ABA7A");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.ChildId).HasColumnName("ChildID");

                entity.Property(e => e.DayOfWeek).HasMaxLength(10);

                entity.Property(e => e.SpecialistId).HasColumnName("SpecialistID");

                entity.HasOne(d => d.Child)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.ChildId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Classes__ChildID__31EC6D26");

                entity.HasOne(d => d.Specialist)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.SpecialistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Classes__Special__30F848ED");
            });

            modelBuilder.Entity<ClassesLog>(entity =>
            {
                entity.Property(e => e.ModifyDate).HasColumnType("datetime");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.ClassesLogs)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ClassesLo__Class__6FE99F9F");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.BirthdayDate).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(30);

                entity.Property(e => e.FirstName).HasMaxLength(20);

                entity.Property(e => e.SecondName).HasMaxLength(20);

                entity.Property(e => e.TelephoneNumber).HasMaxLength(12);
            });

            modelBuilder.Entity<Direction>(entity =>
            {
                entity.Property(e => e.DirectionId).HasColumnName("DirectionID");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Purpose).HasMaxLength(100);

                entity.Property(e => e.Title).HasMaxLength(20);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.MaterialsForWork).HasMaxLength(300);
            });

            modelBuilder.Entity<Specialist>(entity =>
            {
                entity.Property(e => e.SpecialistId).HasColumnName("SpecialistID");

                entity.Property(e => e.BirthdayDate).HasColumnType("date");

                entity.Property(e => e.DirectionId).HasColumnName("DirectionID");

                entity.Property(e => e.FirstName).HasMaxLength(20);

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.SecondName).HasMaxLength(20);

                entity.Property(e => e.Telephone).HasMaxLength(12);

                entity.HasOne(d => d.Direction)
                    .WithMany(p => p.Specialists)
                    .HasForeignKey(d => d.DirectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Specialis__Direc__2D27B809");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Specialists)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Specialis__RoomI__2E1BDC42");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
