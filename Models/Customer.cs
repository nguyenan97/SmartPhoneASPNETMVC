using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Customer
    {
        [StringLength(30)]
        [Key]
        public string CustomerID { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(30)]
        public string ContactName { get; set; }

        [StringLength(60)]
        public string Address { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }

        public bool? Status { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }


        public virtual ICollection<Order> Orders { get; set; }
    }
}
