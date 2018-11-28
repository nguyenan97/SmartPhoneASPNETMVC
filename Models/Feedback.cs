using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Feedback
    {
        [Key]
        public int FId { get; set; }

        [StringLength(100)]
        public string FTitle { get; set; }

        public string FContent { get; set; }

        public DateTime FDate { get; set; }

        [StringLength(30)]
        [ForeignKey("Customer")]
        public string CustomerID { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
