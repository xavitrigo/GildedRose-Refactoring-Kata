using GildedRoseKata.Shared;
using GildedRoseKata.Strategy.Contract;

namespace GildedRoseKata.Strategy.Implementation;

public class BackstagePassUpdateStrategy : IItemUpdateStrategy
{
    public bool Match(Item item) => item.Name == ItemName.BackstagePass; 
    
    public void Update(Item item)
    {
        if (item.SellIn <= 0)
        {
            item.Quality = 0;
            item.SellIn--;

            return;
        }

        var qualityIncrease = item.SellIn switch
        {
            <= 5 => 3,
            <= 10 => 2,
            _ => 1
        };

        QualityHelper.Increase(item, qualityIncrease);

        item.SellIn--;
    }
}