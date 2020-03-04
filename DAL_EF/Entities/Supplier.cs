using System.Collections.Generic;

namespace DAL_EF.Entities
{
    public class Supplier
    {
        public int SupplierId {get; set;}
        public string Name {get; set;}

        public virtual ICollection<ProductSupplier> ProductSuppliers {get; set;}
        
    }
}