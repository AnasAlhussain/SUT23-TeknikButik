using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SUT23_TeknikButikModels
{
    [Serializable]
    //Serialization in C# is the process of converting an object into a
    //stream of bytes to store the object to memory, a database, or a file.

    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public DateTime OrderPlaced { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
