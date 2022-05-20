using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Data.Tables
{
    public partial class Manager
    {
        public Manager()
        {
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Position { get; set; }
        public int IdAccount { get; set; }

        public virtual Account IdAccountNavigation { get; set; } = null!;
        public virtual ICollection<Payment> Payments { get; set; }

        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manager>().HasData(
                new Manager
                {
                    Id = 1,
                    Name = "Lê Quản Lý",
                    Age = 27,
                    Birthday = new DateTime(1995,04,24),
                    Address = "24/22 đường 23, Phường Hiệp Bình Chánh, Q.Thủ Đức, TP.HCM",
                    Email = "quanly1@gmail.com",
                    Phone = "0961444651",
                    Position = "Quản lý trung tâm trụ sở chính",
                    IdAccount = 2,
                }
                );
        }
    }
}
