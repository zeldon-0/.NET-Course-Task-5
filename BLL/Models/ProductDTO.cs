using System.Collections.Generic;
namespace BLL.Models
{
    public class ProductDTO
    {
        public int ProductId {get; set;}
        public string Name {get; set;}
        public int Price {get; set;}
        public int CategoryId {get; set;}
        public  CategoryDTO Category {get; set;}
    }
}