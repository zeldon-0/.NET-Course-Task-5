using System.Collections.Generic;
namespace BLL.Models
{
    public class SupplierDTO
    {
        public int SupplierId {get; set;}
        public string Name {get; set;}
        public IEnumerable<ProductDTO> Products {get; set;}
    }
}