using System.Collections.Generic;

namespace NorthwindCMS.Models
{
    public class CatalogViewModel
    {
        public CatalogPage CatalogPage { get; set; }
        public IEnumerable<CategoryItem> Categories { get; set; }
    }
}