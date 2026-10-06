using GildedRoseKata.Shared;
using GildedRoseKata.Strategy.Contract;

namespace GildedRoseKata.Strategy.Implementation;

internal sealed class StandardItemUpdateStrategy : IItemUpdateStrategy
{
    public bool Match(Item item) => true;

    public void Update(Item item)
    {
        var qualityDegradation = item.SellIn <= 0 ? 2 : 1;

        QualityHelper.Decrease(item, qualityDegradation);

        item.SellIn--;
    }
}