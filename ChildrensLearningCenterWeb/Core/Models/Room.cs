using System;
using System.Collections.Generic;

namespace ChildrensLearningCenterWeb.Models
{
    public partial class Room
    {
        public Room()
        {
            Specialists = new HashSet<Specialist>();
        }

        public int RoomId { get; set; }
        public int TotalSquare { get; set; }
        public string MaterialsForWork { get; set; } = null!;

        public virtual ICollection<Specialist> Specialists { get; set; }
    }
}
