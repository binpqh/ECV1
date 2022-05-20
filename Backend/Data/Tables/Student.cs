using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Data.Tables
{
    public partial class Student
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

        public virtual Class? ClasskeyNavigation { get; set; }
        public virtual Account? IdAccountNavigation { get; set; }

        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    Name = "Trần Học Quang Sinh",
                    Age = 17,
                    Birthday = new DateTime(2005, 09, 21),
                    Address = "24/22 đường 23, Phường Hiệp Bình Chánh, Q.Thủ Đức, TP.HCM",
                    Email = "hocvien1@gmail.com",
                    Phone = "0961444651",
                    IdAccount = 4,
                    Classkey = null
                }
                );
        }
    }
}
