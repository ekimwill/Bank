using Bank;
using Spectre.Console;




var isrunning = true;

while (isrunning)
{

    var options = AnsiConsole.Prompt(
        new SelectionPrompt<MenuOPtion>()
        .Title("This is Mikes bank")
        .AddChoices(
            MenuOPtion.CreateAccount,
            MenuOPtion.Deposit,
            MenuOPtion.withdraw,
            MenuOPtion.SeeAllAccounts,
            MenuOPtion.DeleteAccount,
            MenuOPtion.Quit));



    switch (options)
    {
        case MenuOPtion.CreateAccount:
            ProductService.CreateProduct();
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            Console.Clear();
            break;
        case MenuOPtion.DeleteAccount:
            ProductService.DeleteProduct();
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            Console.Clear();
            break;
        case MenuOPtion.Deposit:
            ProductService.Deposit();
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            Console.Clear();
            break;
        case MenuOPtion.withdraw:
            ProductService.Withdraw();
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            Console.Clear();
            break;
        case MenuOPtion.SeeAllAccounts:
            ProductService.SeeAllAccounts();
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            Console.Clear();
            break;
        case MenuOPtion.Quit:
            isrunning = false;
            break;
    }
}









enum MenuOPtion
{
    CreateAccount,
    Deposit,
    withdraw,
    SeeAllAccounts,
    DeleteAccount,
    Quit
}
