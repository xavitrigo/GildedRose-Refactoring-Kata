using GildedRoseKata.Shared;
using GildedRoseKata.Strategy.Contract;

namespace GildedRoseKata.Strategy.Implementation;

public class ConjuredItemUpdateStrategy : IItemUpdateStrategy
{
    public bool Match(Item item) => item.Name == ItemName.Conjured;

    public void Update(Item item)
    {
        var qualityDegradation = item.SellIn <= 0 ? 4 : 2;

        QualityHelper.Decrease(item, qualityDegradation);

        item.SellIn--;
    }
}