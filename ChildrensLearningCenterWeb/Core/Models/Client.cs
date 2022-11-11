using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Client
    {
        public Client()
        {
            Children = new HashSet<Children>();
        }

        public int ClientId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? SecondName { get; set; }
        public string TelephoneNumber { get; set; } = null!;
        public string? Email { get; set; }
        public DateTime? BirthdayDate { get; set; }

        public virtual ICollection<Children> Children { get; set; }
    }
}
