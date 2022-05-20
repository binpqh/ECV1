using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Data.Tables
{
    public partial class Weekday
    {
        public Weekday()
        {
            IdClasses = new HashSet<Class>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Class> IdClasses { get; set; }
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Weekday>().HasData(

                new Weekday
                {
                    Id = 1,
                    Name = "Chủ Nhật"
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
