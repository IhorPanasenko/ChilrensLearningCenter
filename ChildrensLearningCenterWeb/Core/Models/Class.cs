using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Class
    {
        public Class()
        {
            ClassesLogs = new HashSet<ClassesLog>();
        }

        public int ClassId { get; set; }
        public string DayOfWeek { get; set; } = null!;
        public TimeSpan Time { get; set; }
        public int SpecialistId { get; set; }
        public int ChildId { get; set; }

        public virtual Children Child { get; set; } = null!;
        public virtual Specialist Specialist { get; set; } = null!;
        public virtual ICollection<ClassesLog> ClassesLogs { get; set; }
    }
}
