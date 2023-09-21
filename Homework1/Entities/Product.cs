using Homework1.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homework1.Entities
{
    [Table("Product", Schema = "eBay")]
    public class Product : Entity
    {
        [Key]
        public long product_id { get; set; }
        public string product_name { get; set; } 
        public List<Order> Orders { get; set; } 
        public virtual Category Category { get; set; } 
        public virtual Salesman Salesman { get; set; }
        public override string ToString()
        {
            return $@"| {product_id} | {product_name} | {Category.category_name} | {Salesman.salesman_name} |";
        }
    }
}
