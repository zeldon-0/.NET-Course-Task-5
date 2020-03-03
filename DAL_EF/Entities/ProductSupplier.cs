namespace DAL_EF.Entities
{
    public class ProductSupplier
    {
        public int ProductId {get; set;}
        public Product Product {get; set;}

        public int SupplierId {get; set;}
        public Supplier Supplier{get; set;}
    }
}