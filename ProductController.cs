using Spectre.Console;

namespace Bank;

internal class ProductController
{
    internal static void CreateAccount()
    {
        var name = AnsiConsole.Ask<string>("Name: ");
        var I_Deposit = AnsiConsole.Ask<double>("Initial Deposit: ");
        using var db = new ProductContext();
        db.Add(new Product { Name = name,Balance= I_Deposit });
        db.SaveChanges();
    }


    internal static void DeleteProduct(Product product)
    {
        using var db = new ProductContext();
        db.Remove(product);
        db.SaveChanges();
    }

    internal static void Deposit(Product product, double amount)
    {

        
       
        using var db = new ProductContext();
        var id = product.Id;
        var account = db.Products.SingleOrDefault(p => p.Id == id);
        account.Balance += amount;
        db.SaveChanges();
    }
    internal static void withdraw(Product product, double amount)
    {

        var id = product.Id;
        using var db = new ProductContext();
        var account = db.Products.SingleOrDefault(p => p.Id == id);
        account.Balance -= amount;
        db.SaveChanges();
    }

    internal static List<Product> GetProduct()
    {
        using var db = new ProductContext();
        var products = db.Products.ToList();
        return products;
    }


    internal static Product GetProductById(int id)
    {
        using var db = new ProductContext();
        var product = db.Products.SingleOrDefault(x=>x.Id== id);
        return product;
    }

    internal static List<Product> SeeAllAccounts()
    {
        var db=new ProductContext();
        var products=db.Products.ToList();
        return products;
        
    }
}
