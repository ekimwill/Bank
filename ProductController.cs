using Bank.Models;
using Spectre.Console;

namespace Bank.Controller;

internal class ProductController
{
    internal static void CreateAccount(Product product)
    {

        using var db = new ProductContext();
        db.Add(product);
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
        product.Balance += amount;
        db.Update(product);
        db.SaveChanges();
    }
    internal static void Withdraw(Product product, double amount)
    {
        var id = product.ProductId;
        using var db = new ProductContext();
        var account = db.Products.SingleOrDefault(p => p.ProductId == id);
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
        var product = db.Products.SingleOrDefault(x => x.ProductId == id);
        return product;
    }

    internal static void EditName(Product new_product)
    {
        using var db = new ProductContext();
        db.Update(new_product);
        db.SaveChanges();
    }
}
