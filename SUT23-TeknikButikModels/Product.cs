using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SUT23_TeknikButikModels
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }


        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }

        public Category Category { get; set; }

    }
}
