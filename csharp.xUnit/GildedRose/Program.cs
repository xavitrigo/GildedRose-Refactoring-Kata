using System;
using GildedRoseKata.Factory.Implementation;
using GildedRoseKata.Formatter.Implementation;

namespace GildedRoseKata;

public class Program
{
    public static void Main(string[] args)
    {
        var items = new DefaultInventoryFactory()?.Create();
        var app = new GildedRose(items);

        var days = args.Length > 0 ? int.Parse(args[0]) + 1 : 2;
        
        var formatter = new CommaSeparatedFormatter(); 

        Console.WriteLine("OMGHAI!");
        
        for (var day = 0; day < days; day++)
        {
            var dayReport = formatter.FormatDay(day, items);
            
            Console.Write(dayReport);
        
            app.UpdateQuality();
        }
    }
}