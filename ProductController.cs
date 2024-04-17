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

    internal static void Deposit()
    {
        throw new NotImplementedException();
    }

    internal static void Quit()
    {
        throw new NotImplementedException();
    }

    internal static void withdraw()
    {
        throw new NotImplementedException();
    }
}
