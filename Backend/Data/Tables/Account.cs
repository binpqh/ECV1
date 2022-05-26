using Data.Defined.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Data.Tables
{
    public partial class Account
    {
        public int Id { get; set; }
        public string? Uid { get; set; }
        public string? Password { get; set; }
        public RoleEnum Role { get; set; }

        public virtual List<Manager>? Managers { get; set; }
        public virtual List<Student>? Students { get; set; }
        public virtual List<Teacher>? Teachers { get; set; }
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(
                    new Account
                    {
                        Id = 1,
                        Uid = "admin",
                        Password = "123",
                        Role = RoleEnum.Admin
                    },
                    new Account
                    {
                        Id = 2,
                        Uid = "manager",
                        Password = "123",
                        Role = RoleEnum.Manager
                    },
                    new Account
                    {
                        Id = 3,
                        Uid = "teacher",
                        Password = "123",
                        Role = RoleEnum.Teacher
                    },
                    new Account
                    {
                        Id = 4,
                        Uid = "student",
                        Password = "123",
                        Role = RoleEnum.Student
                    }
                );
        }
    }
}
