using System.Collections.Generic;
namespace BLL.Models
{
    public class ProductDTO
    {
        public int ProductId {get; set;}
        public string Name {get; set;}
        public  CategoryDTO Category {get; set;}
    }
}