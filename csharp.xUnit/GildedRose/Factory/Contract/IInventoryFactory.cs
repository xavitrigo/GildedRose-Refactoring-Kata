using System.Collections.Generic;

namespace GildedRoseKata.Factory.Contract;

public interface IInventoryFactory
{
    public IList<Item> Create();
}