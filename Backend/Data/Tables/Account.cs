using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Data.Tables
{
    public partial class Account
    {
        public Account()
        {
            Managers = new HashSet<Manager>();
            Students = new HashSet<Student>();
            Teachers = new HashSet<Teacher>();
        }

        public int Id { get; set; }
        public string? Uid { get; set; }
        public string? Password { get; set; }
        public int IdRole { get; set; }

        public virtual Role IdRoleNavigation { get; set; } = null!;
        public virtual ICollection<Manager> Managers { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }

        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    Id = 1,
                    Uid = "admin",
                    Password = "admin1",
                    IdRole = 1
                },
                new Account
                {
                    Id = 2,
                    Uid = "manager",
                    Password = "manager1",
                    IdRole = 2
                },
                new Account
                {
                    Id = 3,
                    Uid = "teacher1",
                    Password = "teacher1",
                    IdRole = 3
                },
                new Account
                {
                    Id = 4,
                    Uid = "student",
                    Password = "student1",
                    IdRole = 4
                }
                );
        }
    }
}
