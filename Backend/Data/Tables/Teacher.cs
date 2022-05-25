using Data.Defined.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Data.Tables
{
    public partial class Teacher
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public int? Classkey { get; set; }
        public int? IdAccount { get; set; }
        public string? Phone { get; set; }
        public Status Status { get; set; }

        public virtual Class? ClasskeyNavigation { get; set; }
        public virtual Account? IdAccountNavigation { get; set; }
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().HasData
                (
                    new Teacher
                    {
                        Id = 1,
                        Name = "Lê Giáo Ngọc Viên",
                        Age = 23,
                        Birthday = new DateTime(1999,05,06),
                        Address = "25/38a DD17,LT,TD",
                        Email = "teacher1@gmail.com",
                        Classkey = 1,
                        IdAccount = 3,
                        Phone = "0961444651",
                        Status = Status.Active
                    }
                );
        }
    }
}
