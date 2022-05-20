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
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Manager> Managers { get; set; } = null!;
        public virtual DbSet<Point> Points { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;
        public virtual DbSet<Transcript> Transcripts { get; set; } = null!;
        public virtual DbSet<Weekday> Weekdays { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
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

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.LinkGgmeet).HasColumnName("LinkGGMeet");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.HasOne(d => d.IdCourseNavigation)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.IdCourse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Class_Course");

                entity.HasMany(d => d.IdWeekdays)
                    .WithMany(p => p.IdClasses)
                    .UsingEntity<Dictionary<string, object>>(
                        "ClassDay",
                        l => l.HasOne<Weekday>().WithMany().HasForeignKey("IdWeekday").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ClassDay_Weekday"),
                        r => r.HasOne<Class>().WithMany().HasForeignKey("IdClass").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ClassDay_Class"),
                        j =>
                        {
                            j.HasKey("IdClass", "IdWeekday");

                            j.ToTable("ClassDay");
                        });
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.DayEnd).HasColumnType("date");

                entity.Property(e => e.DayStart).HasColumnType("date");

                entity.Property(e => e.Level).HasMaxLength(20);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.ToTable("Manager");

                entity.Property(e => e.Birthday).HasColumnType("date");

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

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Birthday).HasColumnType("date");

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

                entity.Property(e => e.Birthday).HasColumnType("date");

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

            modelBuilder.Entity<Weekday>(entity =>
            {
                entity.ToTable("Weekday");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
