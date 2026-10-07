using System.Collections.Generic;
using System.Text;
using GildedRoseKata.Formatter.Contract;
using GildedRoseKata.Report.Contract;

namespace GildedRoseKata.Report.Implementation;

public sealed class InventoryReportGenerator(GildedRose app, IEnumerable<Item> items, IReportFormatter formatter) : IReportGenerator
{
    public string Generate(int days)
    {
        var report = new StringBuilder();

        report.AppendLine("OMGHAI!");

        for (var day = 0; day < days; day++)
        {
            report.Append(formatter.FormatDay(day, items));

            app.UpdateQuality();
        }

        return report.ToString();
    }
}