using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class ClassesLog
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public DateTime ModifyDate { get; set; }

        public virtual Class Class { get; set; } = null!;
    }
}
