using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Specialist
    {
        public Specialist()
        {
            Classes = new HashSet<Class>();
        }

        public int SpecialistId { get; set; }
        public string FirstName { get; set; } = null!;
        public string SecondName { get; set; } = null!;
        public string Telephone { get; set; } = null!;
        public int? YearsExperience { get; set; }
        public DateTime BirthdayDate { get; set; }
        public int DirectionId { get; set; }
        public int RoomId { get; set; }

        public virtual Direction Direction { get; set; } = null!;
        public virtual Room Room { get; set; } = null!;
        public virtual ICollection<Class> Classes { get; set; }
    }
}
