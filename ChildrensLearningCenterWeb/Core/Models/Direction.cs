using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Direction
    {
        public Direction()
        {
            Specialists = new HashSet<Specialist>();
        }

        public int DirectionId { get; set; }
        public string Title { get; set; } = null!;
        public string Purpose { get; set; } = null!;
        public int Price { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Specialist> Specialists { get; set; }
    }
}
