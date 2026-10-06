using System.Collections.Generic;
using GildedRoseKata;
using Xunit;

namespace GildedRoseTests.Unit;

public sealed class AgedBrieItemTests
{
    [Theory]
    [InlineData(10, 20)]
    [InlineData(5, 7)]
    [InlineData(1, 0)]
    public void UpdateQuality_BeforeSellDate_IncreasesQualityByOne(int initialSellIn, int initialQuality)
    {
        // Arrange
        var items = new List<Item>();
        var sut = new GildedRose(items);

        var item = new Item
        {
            Name = ItemName.AgedBrie,
            SellIn = initialSellIn,
            Quality = initialQuality
        };

        items.Add(item);

        var expectedSellIn = initialSellIn - 1;
        var expectedQuality = initialQuality + 1;

        // Act
        sut.UpdateQuality();

        // Assert
        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }

    [Theory]
    [InlineData(0, 20)]
    [InlineData(-1, 20)]
    [InlineData(-10, 10)]
    public void UpdateQuality_OnOrAfterSellDate_IncreasesQualityByTwo(int initialSellIn, int initialQuality)
    {
        // Arrange
        var items = new List<Item>();
        var sut = new GildedRose(items);

        var item = new Item
        {
            Name = ItemName.AgedBrie,
            SellIn = initialSellIn,
            Quality = initialQuality
        };

        items.Add(item);

        var expectedSellIn = initialSellIn - 1;
        var expectedQuality = initialQuality + 2;

        // Act
        sut.UpdateQuality();

        // Assert
        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(1)]
    [InlineData(0)]
    [InlineData(-1)]
    public void UpdateQuality_WhenQualityIsFifty_DoesNotIncrease(int initialSellIn)
    {
        // Arrange
        var items = new List<Item>();
        var sut = new GildedRose(items);

        var item = new Item
        {
            Name = ItemName.AgedBrie,
            SellIn = initialSellIn,
            Quality = 50
        };

        items.Add(item);

        var expectedSellIn = initialSellIn - 1;
        const int expectedQuality = 50;

        // Act
        sut.UpdateQuality();

        // Assert
        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }

    [Fact]
    public void UpdateQuality_BeforeSellDateWithQualityFortyNine_IncreasesToFifty()
    {
        // Arrange
        var items = new List<Item>();
        var sut = new GildedRose(items);

        var item = new Item
        {
            Name = ItemName.AgedBrie,
            SellIn = 1,
            Quality = 49
        };

        items.Add(item);

        var expectedSellIn = item.SellIn - 1;
        const int expectedQuality = 50;

        // Act
        sut.UpdateQuality();

        // Assert
        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }

    [Fact]
    public void UpdateQuality_AfterSellDateWithQualityFortyEight_IncreasesToFifty()
    {
        // Arrange
        var items = new List<Item>();
        var sut = new GildedRose(items);

        var item = new Item
        {
            Name = ItemName.AgedBrie,
            SellIn = 0,
            Quality = 48
        };

        items.Add(item);

        var expectedSellIn = item.SellIn - 1;
        const int expectedQuality = 50;

        // Act
        sut.UpdateQuality();

        // Assert
        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }

    [Fact]
    public void UpdateQuality_AfterSellDateWithQualityFortyNine_StopsAtFifty()
    {
        // Arrange
        var items = new List<Item>();
        var sut = new GildedRose(items);

        var item = new Item
        {
            Name = ItemName.AgedBrie,
            SellIn = 0,
            Quality = 49
        };

        items.Add(item);

        var expectedSellIn = item.SellIn - 1;
        const int expectedQuality = 50;

        // Act
        sut.UpdateQuality();

        // Assert
        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }
}