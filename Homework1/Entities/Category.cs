using Homework1.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homework1.Entities
{
    [Table("Category", Schema = "eBay")]
    public class Category : Entity
    {
        [Key]
        public long category_id { get; set; } 
        public string category_name { get; set; }
        public List<Product> Products { get; set; }

        public override string ToString()
        {
            return $@"| {category_id} | {category_name} |";
        }
        
    }
}

