using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUT23_TeknikButikModels
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public DateTime OrderPlaced { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
