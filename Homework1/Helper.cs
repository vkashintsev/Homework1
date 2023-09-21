using Homework1.Entities;
using Homework1.Interface;

namespace Homework1
{
    public static class Helper
    {
        public static void PrintLine(int symbols)
        {
            for (int i = 0; i < symbols; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("");
        }

        public static void Insert(DataContext db, Entity e)
        {
            var client = e;
            switch (e.GetType().ToString())
            {
                case "Homework1.Entities.Buyer":
                    db.buyer.Add(client as Buyer);
                    break;
                case "Homework1.Entities.Category":
                    db.category.Add(client as Category);
                    break;
                case "Homework1.Entities.Order":
                    db.order.Add(client as Order);
                    break;
                case "Homework1.Entities.Product":
                    db.product.Add(client as Product);
                    break;
                case "Homework1.Entities.Salesman":
                    db.salesman.Add(client as Salesman);
                    break;
            } 
        }
        public static void Insert(DataContext db, List<Entity> e)
        {
            foreach (var client in e)
            {
                Insert(db, client);
            }
        }
    }
}
