using System;

namespace GildedRoseKata.Shared;

public static class QualityHelper
{
    private const int MinimumQuality = 0;
    private const int MaximumQuality = 50;

    public static void Increase(Item item, int amount)
    {
        item.Quality = Math.Min(MaximumQuality, item.Quality + amount);
    }

    public static void Decrease(Item item, int amount)
    {
        item.Quality = Math.Max(MinimumQuality, item.Quality - amount);
    }
}