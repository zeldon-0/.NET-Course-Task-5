using System.Collections.Generic;

namespace DAL_ADONET.Models
{
    public class ADOCategory
    {
        public int CategoryId {get; set;}
        public string Name {get; set;}

        public  ICollection<ADOProduct> Products {get; set;}
        
    }
}