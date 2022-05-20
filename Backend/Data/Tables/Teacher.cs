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

        public virtual Class? ClasskeyNavigation { get; set; }
        public virtual Account? IdAccountNavigation { get; set; }

        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher
                {
                    Id = 1,
                    Name = "Nguyễn Giáo Thị Viên",
                    Age = 23,
                    Birthday = new DateTime(1999, 06, 24),
                    Address = "24/22 đường 23, Phường Hiệp Bình Chánh, Q.Thủ Đức, TP.HCM",
                    Email = "giaovien1@gmail.com",
                    Phone = "0961444651",
                    IdAccount = 3,
                    Classkey = null
                }
                );
        }
    }
}
