using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Data.Tables
{
    public partial class Weekday
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual List<Class>? IdClasses { get; set; }
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Weekday>().HasData
                (
                new Weekday
                {
                    Id = 1,
                    Name = "Chủ nhật"
                },
                new Weekday
                {
                    Id = 2,
                    Name = "Thứ hai"
                },
                new Weekday
                {
                    Id = 3,
                    Name = "Thứ ba"
                },
                new Weekday
                {
                    Id = 4,
                    Name = "Thứ tư"
                },
                new Weekday
                {
                    Id = 5,
                    Name = "Thứ năm"
                },
                new Weekday
                {
                    Id = 6,
                    Name = "Thứ sáu"
                },
                new Weekday
                {
                    Id = 7,
                    Name = "Thứ bảy"
                }
                );
        }
    }
}
