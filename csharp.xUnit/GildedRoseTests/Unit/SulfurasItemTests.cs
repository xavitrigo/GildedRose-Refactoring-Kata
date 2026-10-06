using System.Collections.Generic;
using GildedRoseKata;
using Xunit;

namespace GildedRoseTests.Unit;

public sealed class SulfurasItemTests
{
    [Theory]
    [InlineData(10)]
    [InlineData(1)]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-10)]
    public void UpdateQuality_DoesNotChangeSellInOrQuality(int initialSellIn)
    {
        // Arrange
        var items = new List<Item>();
        var sut = new GildedRose(items);

        var item = new Item
        {
            Name = ItemName.Sulfuras,
            SellIn = initialSellIn,
            Quality = 80
        };

        items.Add(item);

        var expectedSellIn = initialSellIn;
        var expectedQuality = 80;

        // Act
        sut.UpdateQuality();

        // Assert
        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }

    [Fact]
    public void UpdateQuality_WhenCalledForMultipleDays_DoesNotChangeSellInOrQuality()
    {
        // Arrange
        var items = new List<Item>();
        var sut = new GildedRose(items);

        var item = new Item
        {
            Name = ItemName.Sulfuras,
            SellIn = 0,
            Quality = 80
        };

        items.Add(item);

        var expectedSellIn = 0;
        var expectedQuality = 80;

        // Act
        sut.UpdateQuality();
        sut.UpdateQuality();
        sut.UpdateQuality();

        // Assert
        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }
}