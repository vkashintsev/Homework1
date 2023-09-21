using Homework1.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homework1.Entities
{
    [Table("Buyer", Schema = "eBay")]
    public class Buyer : Entity
    {
        [Key]
        public int buyer_id { get; set; } 
        public string buyer_name { get; set; } 
        public List<Order> Orders { get; set; }
        public override string ToString()
        {
            return $@"| {buyer_id} | {buyer_name} |";
        }
    }
}
