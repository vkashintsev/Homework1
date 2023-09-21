using Homework1;
using Homework1.Entities;
using Homework1.Interface;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        using (var db = new DataContext())
        { 
            FillAll(db);
            PrintAll(db);
        }
        Console.ReadKey();
    }
    static void FillAll(DataContext db)
    {
        var buyer1 = new Buyer { buyer_id = 1, buyer_name = "Buyer 1" };
        var buyer2 = new Buyer { buyer_id = 2, buyer_name = "Buyer 2" };
        var buyer3 = new Buyer { buyer_id = 3, buyer_name = "Buyer 3" };
        var buyer4 = new Buyer { buyer_id = 4, buyer_name = "Buyer 4" };
        var buyer5 = new Buyer { buyer_id = 5, buyer_name = "Buyer 5" };

        var category1 = new Category { category_id = 1, category_name = "Category 1" };
        var category2 = new Category { category_id = 2, category_name = "Category 2" };
        var category3 = new Category { category_id = 3, category_name = "Category 3" };
        var category4 = new Category { category_id = 4, category_name = "Category 4" };
        var category5 = new Category { category_id = 5, category_name = "Category 5" };

        var salesman1 = new Salesman { salesman_id = 1, salesman_name = "Salesman 1" };
        var salesman2 = new Salesman { salesman_id = 2, salesman_name = "Salesman 2" };
        var salesman3 = new Salesman { salesman_id = 3, salesman_name = "Salesman 3" };
        var salesman4 = new Salesman { salesman_id = 4, salesman_name = "Salesman 4" };
        var salesman5 = new Salesman { salesman_id = 5, salesman_name = "Salesman 5" };

        var product1 = new Product { product_id = 1, product_name = "Product 1", Category = category1, Salesman = salesman1 };
        var product2 = new Product { product_id = 2, product_name = "Product 2", Category = category2, Salesman = salesman2 };
        var product3 = new Product { product_id = 3, product_name = "Product 3", Category = category3, Salesman = salesman3 };
        var product4 = new Product { product_id = 4, product_name = "Product 4", Category = category4, Salesman = salesman4 };
        var product5 = new Product { product_id = 5, product_name = "Product 5", Category = category5, Salesman = salesman1 };

        var order1 = new Order { order_id = 1, price = 50, Buyer = buyer1, Product = product1 };
        var order2 = new Order { order_id = 2, price = 150, Buyer = buyer2, Product = product2 };
        var order3 = new Order { order_id = 3, price = 250, Buyer = buyer3, Product = product3 };
        var order4 = new Order { order_id = 4, price = 350, Buyer = buyer4, Product = product2 };
        var order5 = new Order { order_id = 5, price = 450, Buyer = buyer5, Product = product1 };

        Helper.Insert(db, new List<Entity> { buyer1, buyer2, buyer3, buyer4, buyer5 });
        Helper.Insert(db, new List<Entity> { category1, category2, category3, category4, category5 });
        Helper.Insert(db, new List<Entity> { salesman1, salesman2, salesman3, salesman4, salesman5 });
        Helper.Insert(db, new List<Entity> { product1, product2, product3, product4, product5 });
        Helper.Insert(db, new List<Entity> { order1, order2, order3, order4, order5 }); 
          
        db.SaveChanges();
    }
    static void AddOne(DataContext db)
    {
        Helper.Insert(db, new Buyer() { buyer_id = 1111, buyer_name = $"Buyer #{1111}" });
    }


    static void EFGetAll(DataContext db)
    {
        var objects = db.buyer.ToArray();
        Console.WriteLine("count:" + objects.Count());
    }

    static void PrintAll(DataContext db)
    {
        var buyers = db.buyer;
        var categories = db.category;
        var salesmans = db.salesman;
        var products = db.product.Include(m => m.Category).Include(m => m.Salesman);
        var orders = db.order.Include(m => m.Product).Include(m => m.Buyer);
        Console.WriteLine("Buyers");
        foreach (var buyer in buyers)
        {
            Console.WriteLine($@"{buyer}");
            Helper.PrintLine(buyer.ToString().Length);
        }
        Console.WriteLine("Categories");
        foreach (var category in categories)
        {
            Console.WriteLine($@"{category}");
            Helper.PrintLine(category.ToString().Length);
        }
        Console.WriteLine("Salesmans");
        foreach (var salesman in salesmans)
        {
            Console.WriteLine($@"{salesman}");
            Helper.PrintLine(salesman.ToString().Length);
        }

        Console.WriteLine("Products");
        foreach (var product in products)
        {
            Console.WriteLine($@"{product}");
            Helper.PrintLine(product.ToString().Length);
        }
        Console.WriteLine("Orders");
        foreach (var order in orders)
        {
            Console.WriteLine($@"{order}");
            Helper.PrintLine(order.ToString().Length);
        }
    }

    static void EFGetOne()
    {
        using (DataContext db = new DataContext())
        {
            var objects = db.buyer.FirstOrDefault(x => x.buyer_id == 1);
            //Console.WriteLine(objects.first_name);
        }
    }

    static void EFDelete()
    {
        using (DataContext db = new DataContext())
        {
            var obj = db.buyer.FirstOrDefault(x => x.buyer_id == 1);
            if (obj != null)
            {
                db.buyer.Remove(obj);
                db.SaveChanges();
                Console.WriteLine("объект удалён");
            }
            else
                Console.WriteLine("объект пустой");
        }
    }
}