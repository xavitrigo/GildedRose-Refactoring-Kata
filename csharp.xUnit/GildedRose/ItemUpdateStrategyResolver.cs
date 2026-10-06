using System.Collections.Generic;
using System.Linq;
using GildedRoseKata.Strategy.Contract;
using GildedRoseKata.Strategy.Implementation;

namespace GildedRoseKata;

public class ItemUpdateStrategyResolver
{
    private readonly IReadOnlyList<IItemUpdateStrategy> _strategies = [
        new AgedBrieUpdateStrategy(),
        new BackstagePassUpdateStrategy(),
        new SulfurasUpdateStrategy(),
        new ConjuredItemUpdateStrategy()
    ];
    
    private readonly IItemUpdateStrategy _defaultStrategy = new StandardItemUpdateStrategy();

    public IItemUpdateStrategy Resolve(Item item)
    {
        return _strategies.FirstOrDefault(s => s.Match(item)) ?? _defaultStrategy;
    }
}