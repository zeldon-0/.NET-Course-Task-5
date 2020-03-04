using System.Collections.Generic;
namespace BLL.Models
{
    public class CategoryDTO
    {
        public int CategoryId {get; set;}
        public string Name {get; set;}
        public IEnumerable<ProductDTO> Products {get; set;}
    }
}