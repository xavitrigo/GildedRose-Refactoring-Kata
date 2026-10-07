using System.Collections.Generic;

namespace GildedRoseKata.Formatter.Contract;

public interface IReportFormatter
{
    string FormatDay(int day, IEnumerable<Item> items);
}