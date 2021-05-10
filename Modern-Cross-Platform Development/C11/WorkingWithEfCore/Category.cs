using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Packt.Shared
{
    public class Catergory
    {
        public int CatergoryID { get; set; }
        public string CatergoryName { get; set; }
        [Column(TypeName="ntext")]
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public Catergory(){
            this.Products = new HashSet<Product>();
        }

    }
}