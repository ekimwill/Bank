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
        var id = products.Single(x => x.Name == option).Id;
        var product = ProductController.GetProductById(id);
        return product;
    }

    static internal void CreateProduct()
    {
        var name = AnsiConsole.Ask<string>("Name: ");
        var I_Deposit = AnsiConsole.Ask<double>("Initial Deposit: ");
        ProductController.CreateAccount(name, I_Deposit);
    }

    static internal void DeleteProduct()
    {
        var product = GetAccountOptionInput();
        ProductController.DeleteProduct(product);
    }
    internal static void Deposit()
    {
        var product = GetAccountOptionInput();
        var Deposit = AnsiConsole.Ask<double>("Deposit: ");
        ProductController.Deposit(product, Deposit);

    }
    internal static void Withdraw()
    {
        var product = GetAccountOptionInput();
        var Withdraw = AnsiConsole.Ask<double>("Withdaw Ammount: ");
        ProductController.Deposit(product, Withdraw);
    }


    static internal void SeeAllAccounts()
    {
        var products = ProductController.GetProduct();
        foreach (var product in products)
        {
            Console.WriteLine($"Id: P{product.Id}, Name: {product.Name}, Balance:{product.Balance}");
        }

    }
}
   
