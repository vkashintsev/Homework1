using Homework1.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homework1.Entities
{
    [Table("Order", Schema = "eBay")]
    public class Order : Entity
    {
        [Key]
        public long order_id { get; set; }
        public long price { get; set; }
        public virtual Product Product { get; set; }
        public virtual Buyer Buyer { get; set; }
        public override string ToString()
        {
            return $@"| {order_id} | {price} | {Product.product_name} | {Buyer.buyer_name} |";
        }
    }
}
