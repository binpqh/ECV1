using Data.Defined.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Data.Tables
{
    public partial class Manager
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Address { get; set; }
        public int? IdAccount { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public Status Status { get; set; }

        public virtual Account? IdAccountNavigation { get; set; }

        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manager>().HasData
                (
                    new Manager
                    {
                        Id = 1,
                        Name = "Trần Lý Ngược Quản",
                        Age = 23,
                        Birthday = new DateTime(1999, 05, 06),
                        Address = "25/38a DD17,LT,TD",
                        Email = "quanly1@gmail.com",
                        IdAccount = 2,
                        Phone = "0961444651",
                        Status = Status.Active
                    }
                );
        }
    }
}
