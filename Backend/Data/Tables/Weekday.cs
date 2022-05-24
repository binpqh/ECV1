using System;
using System.Collections.Generic;

namespace Data.Tables
{
    public partial class Weekday
    {

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual List<Class>? IdClasses { get; set; }
    }
}
