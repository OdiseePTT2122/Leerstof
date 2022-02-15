using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrisdrankAutomaat
{
    public class Vendingmachine
    {
        Dictionary<(int,int), List<Drink>> inventory;
        int rows = 10;
        int columns = 5;
        double budget = 0;

        public Vendingmachine()
        {
            GenerateVendingmachine();
        }

        #region properties
        public Dictionary<(int, int), Drink> Inventory { get {
                Dictionary<(int, int), Drink> drinksToShow = new Dictionary<(int, int), Drink>();
                foreach (var item in inventory)
                {
                    drinksToShow.Add(item.Key, item.Value.FirstOrDefault());
                }
                return drinksToShow;
            }
        }

        public double Budget { get => budget;  }

        #endregion


        #region public methods
        public void FillRandomly(List<Drink> drinks)
        {
            Random random = new Random();
            foreach (var drink in drinks)
            {
                int randomRow = random.Next(rows);
                int randowColumn = random.Next(columns);
                AddDrink(drink, randomRow, randowColumn);
            }
        }

        public void AddDrink(Drink drink, int row, int colunmn)
        {
            inventory[(row, colunmn)].Add(drink);
        }

        public void InsertCoins(Coins coin)
        {
            switch (coin)
            {
                case Coins.TWOEURO:
                    budget += 2;
                    break;
                case Coins.ONEEURO:
                    budget += 1;
                    break;
                case Coins.FIFTYCENTS:
                    budget += 0.5;
                    break;
                case Coins.TWENTYCENTS:
                    budget += 0.2;
                    break;
                case Coins.TENCENTS:
                    budget += 0.1;
                    break;
                case Coins.FIVECENTS:
                    budget += 0.05;
                    break;
            }
        }

        public double Refund()
        {
            double temp = budget;
            budget = 0;
            return temp;
        }

        public Drink buy(int row, int column)
        {

            if (row> rows || column>columns)
            {
                throw new IndexOutOfRangeException();
            }
            if (inventory[(row, column)].Count == 0)
            {
                throw new NoInventoryException();
            }
            if(inventory[(row,column)].First().Price >= budget)
            {
                throw new NotEnougMoneyException(budget);
            }

            //act 1
            budget = budget - inventory[(row, column)].First().Price;
            //act 2
            Drink drink = inventory[(row, column)].First();
            //act 3
            inventory[(row, column)].RemoveAt(0);
            
            return drink;
        }
        #endregion

        #region private methods
        private void GenerateVendingmachine()
        {
            inventory = new Dictionary<(int, int), List<Drink>>();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    inventory.Add((i,j), new List<Drink>());
                }
            }
        }
        #endregion
    }
}
