using System.Collections.Generic;
using GildedRoseKata.Formatter.Contract;

namespace GildedRoseKata.Formatter.Implementation;

public class CommaSeparatedFormatter : IReportFormatter
{
    public string FormatDay(int day, IEnumerable<Item> items)
    {
        var sb = new System.Text.StringBuilder();
        
        sb.AppendLine($"-------- day {day} --------");
        sb.AppendLine("name, sellIn, quality");
        
        foreach (var item in items)
        {
            sb.AppendLine($"{item.Name}, {item.SellIn}, {item.Quality}");
        }
        
        sb.AppendLine(); 
        
        return sb.ToString();
    }
}