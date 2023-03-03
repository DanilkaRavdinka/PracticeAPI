using System;
using System.Collections.Generic;

namespace ApiBackend.Models
{
    public partial class Delivery
    {
        public Delivery()
        {
            Orders = new HashSet<Order>();
        }

        public int DeliveryId { get; set; }
        public string DeliveryType { get; set; } = null!;
        public bool IsDeleted { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
