using System;
using System.Collections.Generic;

namespace Ex1
{
    internal class Wine
    {
        public Wine()
        {
        }

        public Wine(int price, int aging, string manufactureCountry, string sort)
        {
            Price = price;
            Aging = aging;
            ManufactureCountry = manufactureCountry;
            Sort = sort;
        }

        public int Price { get; set; }
        public int Aging { get; set; }
        public string ManufactureCountry { get; set; }
        public string Sort { get; set; }
    }
    internal class Wines : Wine
    {
        private readonly List<Wine> wines = new List<Wine>();

        public void AddWine(int price, int aging, string manufactureCountry, string sort)
        {
            wines.Add(new Wine(price, aging, manufactureCountry, sort));
        }

        public void SearchWineByPrice(int price)
        {
            var findedWines = new List<Wine>();
            for (var i = 0; i < wines.Count; i++)
            {
                if (wines[i].Price.Equals(price)) findedWines.Add(wines[i]);
            }

            if (findedWines.Count != 0)
            {
                Console.WriteLine("Have you been looking for these wines?:");
                foreach (var wine in findedWines)
                    Console.WriteLine(
                        $"Price: {wine.Price} | Aging: {wine.Aging} | Country: {wine.ManufactureCountry} | Sort: {wine.Sort}");
            }
            else
            {
                Console.WriteLine("No wine found for your search :(");
            }
        }

        public void SearchWineByYear(int aging)
        {
            var findedWines = new List<Wine>();
            for (var i = 0; i < wines.Count; i++)
            {
                if (wines[i].Aging.Equals(aging))
                    findedWines.Add(wines[i]);
            }

            if (findedWines.Count != 0)
            {
                Console.WriteLine("Have you been looking for these wines?:");
                foreach (var wine in findedWines)
                    Console.WriteLine(
                        $"Price: {wine.Price} | Aging: {wine.Aging} | Country: {wine.ManufactureCountry} | Sort: {wine.Sort}");
            }
            else
            {
                Console.WriteLine("No wine found for your search :(");
            }
        }

        public void SearchWineByCountry(string manufactureCountry)
        {
            var findedWines = new List<Wine>();
            for (var i = 0; i < wines.Count; i++)
            {
                wines[i].ManufactureCountry = wines[i].ManufactureCountry.ToLower();
                if (wines[i].ManufactureCountry.Contains(manufactureCountry.ToLower())) findedWines.Add(wines[i]);
            }
               
            if (findedWines.Count != 0)
            {
                Console.WriteLine("Have you been looking for these wines?:");
                foreach (var wine in findedWines)
                    Console.WriteLine(
                        $"Price: {wine.Price} | Aging: {wine.Aging} | Country: {wine.ManufactureCountry} | Sort: {wine.Sort}");
            }
            else
            {
                Console.WriteLine("No wine found for your search :(");
            }
        }

        public void SearchWineBySort(string sort)
        {
            var findedWines = new List<Wine>();
            for (var i = 0; i < wines.Count; i++)
            {
                wines[i].Sort = wines[i].Sort.ToLower();
                if (wines[i].Sort.Contains(sort.ToLower())) findedWines.Add(wines[i]);
            }
            if (findedWines.Count != 0)
            {
                Console.WriteLine("Have you been looking for these wines?:");
                foreach (var wine in findedWines)
                    Console.WriteLine(
                        $"Price: {wine.Price} | Aging: {wine.Aging} | Country: {wine.ManufactureCountry} | Sort: {wine.Sort}");
            }
            else
            {
                Console.WriteLine("No wine found for your search :(");
            }
        }

        public void SearchWine(int price, int aging, string manufactureCountry, string sort)
        {
            var findedWines = new List<Wine>();
            for (var i = 0; i < wines.Count; i++)
                if (wines[i].Price.Equals(price) &&
                    wines[i].Aging.Equals(aging) &&
                    wines[i].ManufactureCountry.Contains(manufactureCountry.ToLower()) &&
                    wines[i].Sort.Contains(sort.ToLower()))
                    findedWines.Add(wines[i]);
            if (findedWines.Count != 0)
            {
                Console.WriteLine("Have you been looking for these wines?:");
                foreach (var wine in findedWines)
                    Console.WriteLine(
                        $"Price: {wine.Price} | Aging: {wine.Aging} | Country: {wine.ManufactureCountry} | Sort: {wine.Sort}");
            }
            else
            {
                Console.WriteLine("No wine found for your search :(");
            }
        }
    }
    
    internal class Program
    { 
        public static void Main(string[] args)
        {
            int input;

            var wineStore = new Wines();

            wineStore.AddWine( 30_000, 15, "Canada", "Grapes frozen on the vine");
            wineStore.AddWine(100_000, 233, "France", "Vintage");
            wineStore.AddWine(27_000, 155, "France", "Lafite");
            wineStore.AddWine(500_000, 20, "United States", "Nappa");
            wineStore.AddWine(225_000, 233, "France", "Margaux");
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Find Wine by:\n" +
                                  "1)Price\n" +
                                  "2)Aging\n" +
                                  "3)Country\n" +
                                  "4)Sort\n" +
                                  "5)In all respects\n");
                input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.Write("Enter the price of wine: ");
                        wineStore.SearchWineByPrice(Convert.ToInt32(Console.ReadLine()));
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Write("Enter the age of wine: ");
                        wineStore.SearchWineByYear(Convert.ToInt32(Console.ReadLine()));
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Enter the country of wine: ");
                        wineStore.SearchWineByCountry(Console.ReadLine());
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("Enter the sort of wine: ");
                        wineStore.SearchWineBySort(Console.ReadLine());
                        Console.ReadKey();
                        break;
                    case 5:
                    {
                        Console.WriteLine("Enter wine parameters");
                        
                        Console.Write("Enter the price of wine: ");
                        int price = Convert.ToInt32(Console.ReadLine());
                        Console.Write("\nEnter the age of wine: ");
                        int age = Convert.ToInt32(Console.ReadLine());
                        Console.Write("\nnter the country of wine: ");
                        string country = Console.ReadLine();
                        Console.Write("\nEnter the sort of wine: ");
                        string sort = Console.ReadLine();

                        wineStore.SearchWine(price, age, country, sort);
                    }
                    break;
                }
            }
        }
    }
}