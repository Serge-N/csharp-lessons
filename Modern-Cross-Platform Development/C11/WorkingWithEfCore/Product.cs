using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Packt.Shared
{
    public class Product
    {
        public int ProductID {get; set;}
        [Required]
        [StringLength(40)]
        public string ProductName {get ; set;}
        [Column("UnitPrice",TypeName="money")]
        public decimal? Cost {get; set;} // property name != field name
        [Column("UnitsInStock")]
        public short? Stock {get; set;}
        public bool Discontinued {get; set;}
        public int CategoryID {get; set;}
        public virtual Catergory Catergory {get; set;}
    }
}