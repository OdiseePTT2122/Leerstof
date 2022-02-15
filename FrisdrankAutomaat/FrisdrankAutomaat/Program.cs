using System;
using System.Collections.Generic;
using System.Linq;

namespace FrisdrankAutomaat
{
    class Program
    {
        static Vendingmachine machine = new Vendingmachine();
        static void Main(string[] args)
        {
            List<Drink> drinks = GenerateDrinksList();
            machine.FillRandomly(drinks);


            Menu();

            Console.ReadKey();
        }

        private static void Menu(string message = "")
        {
            PrintHeader(message);
            Console.WriteLine("1) munten inwerpen");
            Console.WriteLine("2) drankje kopen");
            Console.WriteLine("3) refund");
            Console.WriteLine("Make a choice");
            string choice = Console.ReadLine();
            int choiceInt;
            bool success = int.TryParse(choice, out choiceInt);
            if (!success || (choiceInt != 1 && choiceInt != 2 && choiceInt != 3))
            {
                Menu("Geef een geldige keuze in");
            }
            else
            {
                switch (choiceInt)
                {
                    case 1:
                        AddCoin();
                        break;
                    case 2:
                        OrderDrink();
                        break;
                    case 3:
                        refund();
                        break;
                }
            }

        }

        private static void refund()
        {
            double value = machine.Refund();
            Menu($"Je krijgt {value} euro terug");
        }

        private static void OrderDrink(string message = "")
        {

            PrintHeader(message);
            Console.WriteLine("Geef rij in:");
            string row = Console.ReadLine();

            Console.WriteLine("Geef kolom in:");
            string column = Console.ReadLine();
            int rowInt = 0;
            int columnInt = 0;
            bool success = int.TryParse(row, out rowInt) && int.TryParse(column, out columnInt);
            if (!success)
            {
                OrderDrink("Geef geldige waarden in");
            } else
            {
                try
                {
                    Drink drink = machine.buy(rowInt, columnInt);
                    Menu($"Je kocht een {drink.Name}");
                }
                catch (IndexOutOfRangeException)
                {
                    OrderDrink("Geef geldige waarden in");
                }
                catch (NoInventoryException)
                {
                    OrderDrink("Geef geldige waarden in");
                }
                catch (NotEnougMoneyException)
                {
                    Menu("Je hebt onvoldoende budget");
                }
                
            }

            

        }

        private static void AddCoin(string message = "" )
        {
            PrintHeader(message);

            Console.WriteLine("Kies een munt:");
            Console.WriteLine("1) 2 euro");
            Console.WriteLine("2) 1 euro");
            Console.WriteLine("3) 50 cent");
            Console.WriteLine("4) 20 cent");
            Console.WriteLine("5) 10 cent");
            Console.WriteLine("6) 5 cent");
            Console.WriteLine("7) keer terug");

            string choice = Console.ReadLine();
            int choiceInt;
            bool success = int.TryParse(choice, out choiceInt);
            if (!success || (choiceInt != 1 && choiceInt != 2 && choiceInt != 3 && choiceInt != 4 && choiceInt != 5 && choiceInt != 6 && choiceInt != 7))
            {
                AddCoin("Geef een geldige keuze in");
            }
            else
            {
                switch (choiceInt)
                {
                    case 1:
                        machine.InsertCoins(Coins.TWOEURO);
                        AddCoin();
                        break;
                    case 2:
                        machine.InsertCoins(Coins.ONEEURO);
                        AddCoin();
                        break;
                    case 3:
                        machine.InsertCoins(Coins.FIFTYCENTS);
                        AddCoin();
                        break;
                    case 4:
                        machine.InsertCoins(Coins.TWENTYCENTS);
                        AddCoin();
                        break;
                    case 5:
                        machine.InsertCoins(Coins.TENCENTS);
                        AddCoin();
                        break;
                    case 6:
                        machine.InsertCoins(Coins.FIVECENTS);
                        AddCoin();
                        break;
                    case 7:
                        Menu();
                        break;
                }
            }
        }

        private static void PrintHeader(string message)
        {
            Console.Clear();
            PrintInventory(machine.Inventory);
            Console.WriteLine();

            if (message != "")
            {
                Console.WriteLine(message);
            }
        }

        private static void PrintInventory(Dictionary<(int, int), Drink> inventory)
        {
            int maxRows = inventory.Keys.Max(x => x.Item1);
            int maxColumns = inventory.Keys.Max(x => x.Item2);
            int maxCharacters = inventory.Values.Max(x => x == null ? 0 : x.Name.Length) + 2;


            Console.Write(" |");

            for (int j = 0; j <= maxColumns; j++)
            {

                AddSpaces((maxCharacters - 1) / 2);
                Console.Write(j);
                AddSpaces((maxCharacters - 1) / 2 + (maxCharacters - 1) % 2);
                Console.Write("|");
            }
            Console.WriteLine();

            for (int i = 0; i <= maxRows; i++)
            {
                Console.Write($"{i}|");
                for (int j = 0; j <= maxColumns; j++)
                {
                    if (inventory[(i, j)] == null)
                    {
                        AddSpaces((maxCharacters - 1) / 2);
                        Console.Write("-");
                        AddSpaces((maxCharacters - 1) / 2 + (maxCharacters - 1) % 2);
                        Console.Write("|");
                    }
                    else
                    {
                        AddSpaces((maxCharacters - inventory[(i, j)].Name.Length) / 2);
                        Console.Write($"{inventory[(i, j)].Name}");
                        AddSpaces((maxCharacters - inventory[(i, j)].Name.Length) / 2 + (maxCharacters - inventory[(i, j)].Name.Length) % 2);
                        Console.Write("|");

                    }
                }
                Console.WriteLine();
            }


        }

        private static void AddSpaces(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                Console.Write(" ");
            }
        }

        private static List<Drink> GenerateDrinksList()
        {
            Drink coke = new Drink("cola", 1.5);
            Drink fanta = new Drink("fanta", 1.5);
            Drink water = new Drink("water", 1);
            Drink aquarius = new Drink("aquarius", 1.8);
            Drink icetea = new Drink("ice tea", 1.7);

            List<Drink> drinks = new List<Drink>();
            AddDrink(drinks, coke, 10);
            AddDrink(drinks, fanta, 10);
            AddDrink(drinks, water, 10);
            AddDrink(drinks, aquarius, 10);
            AddDrink(drinks, icetea, 10);
            return drinks;
        }

        private static List<Drink> AddDrink(List<Drink> drinks, Drink drink, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                drinks.Add(drink);
            }
            return drinks;
        }
    }
}
