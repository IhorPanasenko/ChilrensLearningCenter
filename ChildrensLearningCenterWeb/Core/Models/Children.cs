using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Children
    {
        public Children()
        {
            Classes = new HashSet<Class>();
        }

        public int ChildId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? SecondName { get; set; }
        public DateTime BirthdayDate { get; set; }
        public int ClientId { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual ICollection<Class> Classes { get; set; }
    }
}
