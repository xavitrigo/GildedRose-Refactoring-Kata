using System;
using GildedRoseKata.Factory.Implementation;

namespace GildedRoseKata;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("OMGHAI!");

        var items = new DefaultInventoryFactory()?.Create();
        var app = new GildedRose(items);

        var days = 2;

        if (args.Length > 0)
        {
            days = int.Parse(args[0]) + 1;
        }

        for (var day = 0; day < days; day++)
        {
            Console.WriteLine("-------- day " + day + " --------");
            Console.WriteLine("name, sellIn, quality");

            foreach (var item in items)
            {
                Console.WriteLine(item.Name + ", " + item.SellIn + ", " + item.Quality);
            }

            Console.WriteLine("");

            app.UpdateQuality();
        }
    }
}