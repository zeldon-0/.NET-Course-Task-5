using System.Collections.Generic;

namespace DAL_EF.Entities
{
    public class Product
    {
        public int ProductId {get; set;}
        public string Name {get; set;}
        public int Price {get; set;}
        public int CategoryId {get; set;}
        
        public virtual Category Category {get; set;}        
        public virtual ICollection<ProductSupplier> ProductSuppliers {get; set;}
    }
}