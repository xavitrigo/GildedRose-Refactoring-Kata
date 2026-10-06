using GildedRoseKata.Shared;
using GildedRoseKata.Strategy.Contract;

namespace GildedRoseKata.Strategy.Implementation;

public class AgedBrieUpdateStrategy : IItemUpdateStrategy
{
    public bool Match(Item item) => item.Name == ItemName.AgedBrie;

    public void Update(Item item)
    {
        var qualityIncrease = item.SellIn <= 0 ? 2 : 1;

        QualityHelper.Increase(item, qualityIncrease);

        item.SellIn--;
    }
}