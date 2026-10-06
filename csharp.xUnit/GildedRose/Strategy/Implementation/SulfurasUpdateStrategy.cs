using GildedRoseKata.Shared;
using GildedRoseKata.Strategy.Contract;

namespace GildedRoseKata.Strategy.Implementation;

public class SulfurasUpdateStrategy : IItemUpdateStrategy
{
    public bool Match(Item item) => item.Name == ItemName.Sulfuras;

    public void Update(Item item)
    {
        // Sulfuras never changes.
    }
}