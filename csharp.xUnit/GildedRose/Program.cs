using System;
using GildedRoseKata.Factory.Implementation;
using GildedRoseKata.Formatter.Implementation;
using GildedRoseKata.Output.Implementation;
using GildedRoseKata.Report.Implementation;

namespace GildedRoseKata;

public class Program
{
    public static void Main(string[] args)
    {
        var items = new DefaultInventoryFactory()?.Create();
        var app = new GildedRose(items);

        var days = args.Length > 0 ? int.Parse(args[0]) + 1 : 2;
        
        var formatter = new CommaSeparatedFormatter(); 
        var reportGenerator = new InventoryReportGenerator(app, items, formatter);
        var outputWriter = new ConsoleOutputWriter();

        var report = reportGenerator.Generate(days);

        outputWriter.Write(report);
    }
}