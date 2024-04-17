// See https://aka.ms/new-console-template for more information
using Bank;
using Spectre.Console;

Console.WriteLine("Hello, World!");

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
            MenuOPtion.Quit));



    switch (options)
    {
        case MenuOPtion.CreateAccount:
            ProductController.CreateAccount();
            break;
        case MenuOPtion.Deposit:
            ProductController.Deposit();
            break;
        case MenuOPtion.withdraw:
            ProductController.withdraw();
            break;
        case MenuOPtion.Quit:
            ProductController.Quit();
            break;
    }
}









enum MenuOPtion
{
    CreateAccount,
    Deposit,
    withdraw,
    Quit
}