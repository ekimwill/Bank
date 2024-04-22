using Bank.Controller;
using Bank.Models;
using Spectre.Console;

namespace Bank.Services;

internal class ProductService
{
    static internal Product GetAccountOptionInput()
    {
        var products = ProductController.GetProduct();
        var productsArray = products.Select(x => x.Name).ToArray();
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("choose account")
            .AddChoices(productsArray));
        var id = products.Single(x => x.Name == option).ProductId;
        var product = ProductController.GetProductById(id);
        return product;
    }

    static internal void CreateProduct()
    {
        var product = new Product();
        product.Name = AnsiConsole.Ask<string>("Name: ");
        product.Balance = AnsiConsole.Ask<double>("Initial Deposit: ");
        product.sex = AnsiConsole.Ask<string>("Sex: ");
        var Categorys = CategoryController.GetCategory();
        var CategoryArray = Categorys.Select(x => x.Name).ToArray();
        var Category_name= AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Choose Account type")
            .AddChoices(CategoryArray));
        product.CategoryId = Categorys.Single(x => x.Name == Category_name).CategoryId;

        ProductController.CreateAccount(product);
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
            Console.WriteLine($"Id: P{product.ProductId}, Name: {product.Name}, Balance:{product.Balance}, Sex:{product.sex}");
        }

    }

    internal static void EditName()
    {
        var product = GetAccountOptionInput();
        product.Name = AnsiConsole.Ask<string>("New name: ");
        ProductController.EditName(product);
    }
}

