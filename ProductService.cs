using Spectre.Console;

namespace Bank;

internal class ProductService
{
    static internal Product GetAccountOptionInput()
    {
        var products = ProductController.GetProduct();
        var productsArray = products.Select(x => x.Name).ToArray();
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("choose account")
            .AddChoices(productsArray));
        var id=products.Single(x => x.Name == option).Id;
        var product=ProductController.GetProductById(id);
        return product;
    }

    static internal void DeleteProduct()
    {
        var product= GetAccountOptionInput();
        ProductController.DeleteProduct(product);
    }



    static internal void SeeAllAccounts(List<Product> products)
    {
        foreach (var product in products)
        {
            Console.WriteLine($"Id: P{product.Id}, Name: {product.Name}, Balance:{product.Balance}");
        }
        
    }
    internal static double GetAmount()
    {
        var Amount = AnsiConsole.Ask<double>("Deposit amount: ");
        return Amount;
    }
    internal static double GetWithdraw()
    {
        var Amount = AnsiConsole.Ask<double>("Withdraw amount: ");
        return Amount;
    }
}
