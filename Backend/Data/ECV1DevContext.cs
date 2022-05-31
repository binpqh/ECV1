using System;
using System.Collections.Generic;
using Data.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data
{
    public partial class ECV1DevContext : DbContext
    {
        public ECV1DevContext()
        {
        }

        public ECV1DevContext(DbContextOptions<ECV1DevContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Classday> Classdays { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Manager> Managers { get; set; } = null!;
        public virtual DbSet<Point> Points { get; set; } = null!;
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;
        public virtual DbSet<Transcript> Transcripts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=EC.V1.Dev;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Uid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UID")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.HasIndex(e => e.IdCourse, "IX_Class_IdCourse");

                entity.Property(e => e.LinkGgmeet).HasColumnName("LinkGGMeet");

                entity.HasOne(d => d.IdCourseNavigation)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.IdCourse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Class_Course");
            });

            modelBuilder.Entity<Classday>(entity =>
            {
                entity.ToTable("Classday");

                entity.HasOne(d => d.ClassNavigation)
                    .WithMany(p => p.Classdays)
                    .HasForeignKey(d => d.Class)
                    .HasConstraintName("FK_Class_Classday");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.Level).HasMaxLength(20);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.ToTable("Manager");

                entity.HasIndex(e => e.IdAccount, "IX_Manager_IdAccount");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.IdAccountNavigation)
                    .WithMany(p => p.Managers)
                    .HasForeignKey(d => d.IdAccount)
                    .HasConstraintName("FK_Manager_Account");
            });

            modelBuilder.Entity<Point>(entity =>
            {
                entity.ToTable("Point");

                entity.Property(e => e.Point1).HasColumnName("Point");
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasIndex(e => e.IdAccountNavigationId, "IX_RefreshTokens_IdAccountNavigationId");

                entity.HasOne(d => d.IdAccountNavigation)
                    .WithMany(p => p.RefreshTokens)
                    .HasForeignKey(d => d.IdAccountNavigationId);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.HasIndex(e => e.Classkey, "IX_Student_Classkey");

                entity.HasIndex(e => e.IdAccount, "IX_Student_IdAccount");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.ClasskeyNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.Classkey)
                    .HasConstraintName("FK_Student_Class");

                entity.HasOne(d => d.IdAccountNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.IdAccount)
                    .HasConstraintName("FK_Student_Account");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teacher");

                entity.HasIndex(e => e.Classkey, "IX_Teacher_Classkey");

                entity.HasIndex(e => e.IdAccount, "IX_Teacher_IdAccount");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.ClasskeyNavigation)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.Classkey)
                    .HasConstraintName("FK_Teacher_Class");

                entity.HasOne(d => d.IdAccountNavigation)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.IdAccount)
                    .HasConstraintName("FK_Teacher_Account");
            });

            modelBuilder.Entity<Transcript>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Transcript");

                entity.HasIndex(e => e.IdClass, "IX_Transcript_IdClass");

                entity.HasIndex(e => e.IdManager, "IX_Transcript_IdManager");

                entity.HasIndex(e => e.IdPoint, "IX_Transcript_IdPoint");

                entity.HasIndex(e => e.IdStudent, "IX_Transcript_IdStudent");

                entity.HasIndex(e => e.IdTeacher, "IX_Transcript_IdTeacher");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdClassNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdClass)
                    .HasConstraintName("FK_Transcript_Class");

                entity.HasOne(d => d.IdManagerNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdManager)
                    .HasConstraintName("FK_Transcript_Manager");

                entity.HasOne(d => d.IdPointNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPoint)
                    .HasConstraintName("FK_Transcript_Point");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdStudent)
                    .HasConstraintName("FK_Transcript_Student");

                entity.HasOne(d => d.IdTeacherNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdTeacher)
                    .HasConstraintName("FK_Transcript_Teacher");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
