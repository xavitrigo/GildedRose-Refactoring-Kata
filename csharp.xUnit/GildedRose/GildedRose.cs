using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose(IList<Item> items)
{
    private readonly ItemUpdateStrategyResolver _itemUpdateStrategyResolver = new();

    public void UpdateQuality()
    {
        foreach (var item in items)
        {
            var strategy = _itemUpdateStrategyResolver.Resolve(item);

            strategy.Update(item);
        }
    }
}