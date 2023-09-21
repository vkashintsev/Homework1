using Homework1.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homework1.Entities
{
    [Table("Salesman", Schema = "eBay")]
    public class Salesman : Entity
    {
        [Key]
        public long salesman_id { get; set; } 
        public string salesman_name { get; set; }
        public List<Product> Products { get; set; }

        public override string ToString()
        {
            return $@"| {salesman_id} | {salesman_name} |";
        }
    }
}
