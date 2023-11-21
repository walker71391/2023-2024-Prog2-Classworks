﻿
using DatoriumBank.Business;
using DatoriumBank.Data;
using DatoriumBank.Data.Entity;
using DatoriumBank.Data.Managers;
using System;
using static System.Collections.Specialized.BitVector32;

public class Program
{
    private static UserManager _userManager { get; set; }
    public static void Main()
    {
        Console.WriteLine("Šeit ir jaunā datubāzes menedžēšana");

        var userService = new UserService();

        var bankDbContext = new BankDbContext();
        _userManager = new UserManager(bankDbContext);
        var clientsFromORM = _userManager.GetClients("Anna");
        foreach (var client in clientsFromORM)
        {
            Console.WriteLine($"{client.Name} {client.Surname} {client.Email}");
        }

        var accountManager = new AccountManager(bankDbContext);

        ShowMenu();
    }

    private static void ShowMenu()
    {
        Console.WriteLine("Pieejamās darbības:");
        Console.WriteLine("1. Pievienot jaunu klientu");
        Console.WriteLine("2. Dzēst klienta informāciju");
        ChooseAction();
    }

    private static void ChooseAction()
    {
        var action = Console.ReadLine();

        Console.WriteLine($"Klients veica {action}");

        if (int.Parse(action) == 1)
        {
            Console.WriteLine("Ir izvēlēts pievienot jaunu klientu!");
            AddClient();
        }
    }

    private static void AddClient()
    {
        Console.WriteLine("Norādi klienta vārdu:");
        var name = Console.ReadLine();
        Console.WriteLine("Norādi klienta uzvārdu:");
        var surname = Console.ReadLine();
        Console.WriteLine("Norādi klienta e-pastu:");
        var email = Console.ReadLine();

        var client = new Client(name, surname, email);
        _userManager.AddClient(client);
    }

    /*
    //Saraksts ar klientiem:
    //1. Anna Bērziņa - epasts
    //2. vārds uzvārds epasts
    //3.  asdasdas
    //4. asdasdasd
    //
    //Pieejamās darbības:
    //1. Pievienot jaunu klientu
    //2. Dzēst klienta informāciju



    1

    //Ievadi klienta vārdu
    //Ievadi klienta uzvārdu
    //Ievadi klienta e-pastu

    2

    Ievadi klienta ID
    //*/
}