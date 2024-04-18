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
            MenuOPtion.Quit));



    switch (options)
    {
        case MenuOPtion.CreateAccount:
            ProductController.CreateAccount();
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            Console.Clear();
            break;
        case MenuOPtion.Deposit:
            var product = ProductService.GetAccountOptionInput();
            var amount = ProductService.GetAmount();
            ProductController.Deposit(product, amount);
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            Console.Clear();
            break;
        case MenuOPtion.withdraw:

            product = ProductService.GetAccountOptionInput();
            amount = ProductService.GetWithdraw();
            ProductController.withdraw(product, amount);
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            Console.Clear();
            break;
        case MenuOPtion.SeeAllAccounts:
            var products = ProductController.SeeAllAccounts();
            ProductService.SeeAllAccounts(products);
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
    Quit
}
