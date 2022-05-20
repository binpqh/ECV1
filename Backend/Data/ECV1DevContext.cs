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
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;
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
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Uid)
                    .HasMaxLength(10)
                    .HasColumnName("UID")
                    .IsFixedLength();

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Role");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.ClassName).HasMaxLength(50);

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.LinkGgmeet)
                    .HasMaxLength(50)
                    .HasColumnName("LinkGGMeet");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Class_Courses");

                entity.HasMany(d => d.Weekdays)
                    .WithMany(p => p.Classes)
                    .UsingEntity<Dictionary<string, object>>(
                        "Classday",
                        l => l.HasOne<Weekday>().WithMany().HasForeignKey("WeekdayId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Classday_Weekday"),
                        r => r.HasOne<Class>().WithMany().HasForeignKey("ClassId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Classday_Class"),
                        j =>
                        {
                            j.HasKey("ClassId", "WeekdayId");

                            j.ToTable("Classday");
                        });
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.CourseName).HasMaxLength(50);

                entity.Property(e => e.EndDay).HasColumnType("date");

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Level).HasMaxLength(50);

                entity.Property(e => e.StartDay).HasColumnType("date");
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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Manager_Account");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK_Payment_Manager");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_Payment_Student");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.ClassKeyNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClassKey)
                    .HasConstraintName("FK_Student_Class");

                entity.HasOne(d => d.IdAccountNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.IdAccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Teacher_Account");
            });

            modelBuilder.Entity<Weekday>(entity =>
            {
                entity.ToTable("Weekday");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
