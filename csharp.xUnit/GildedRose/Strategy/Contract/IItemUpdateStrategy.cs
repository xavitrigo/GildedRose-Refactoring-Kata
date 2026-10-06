namespace GildedRoseKata.Strategy.Contract;

public interface IItemUpdateStrategy
{
    bool Match(Item item);

    void Update(Item item);
}