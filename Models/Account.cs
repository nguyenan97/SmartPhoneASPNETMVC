using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Account
    {
        [Key]
        public int AccountID { get; set; }
	//abc
        [Required]
        [StringLength(30)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(30)]
        public string FullName { get; set; }

        public int Type { get; set; }

        public string Role { get; set; }

        public bool? Status { get; set; }
    }
}
