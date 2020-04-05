using System;
using System.Collections.Generic;

namespace Boxters.Domain.Entities
{
    public partial class Account
    {
        public Account()
        {
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime Created { get; set; }
        public bool IsSuperUser { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
