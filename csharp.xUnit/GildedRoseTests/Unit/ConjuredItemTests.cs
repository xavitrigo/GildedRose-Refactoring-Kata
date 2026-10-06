using System.Collections.Generic;
using GildedRoseKata;
using Xunit;

namespace GildedRoseTests.Unit;

public sealed class ConjuredItemTests
{
    [Theory]
    [InlineData(10, 20)]
    [InlineData(5, 10)]
    [InlineData(1, 2)]
    public void UpdateQuality_BeforeSellDate_DecreasesQualityByTwo(
        int initialSellIn,
        int initialQuality)
    {
        // Arrange
        var items = new List<Item>();
        var sut = new GildedRose(items);

        var item = new Item
        {
            Name = ItemName.Conjured,
            SellIn = initialSellIn,
            Quality = initialQuality
        };

        items.Add(item);

        var expectedSellIn = initialSellIn - 1;
        var expectedQuality = initialQuality - 2;

        // Act
        sut.UpdateQuality();

        // Assert
        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }

    [Theory]
    [InlineData(0, 20)]
    [InlineData(-1, 10)]
    [InlineData(-10, 4)]
    public void UpdateQuality_OnOrAfterSellDate_DecreasesQualityByFour(
        int initialSellIn,
        int initialQuality)
    {
        // Arrange
        var items = new List<Item>();
        var sut = new GildedRose(items);

        var item = new Item
        {
            Name = ItemName.Conjured,
            SellIn = initialSellIn,
            Quality = initialQuality
        };

        items.Add(item);

        var expectedSellIn = initialSellIn - 1;
        var expectedQuality = initialQuality - 4;

        // Act
        sut.UpdateQuality();

        // Assert
        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void UpdateQuality_BeforeSellDate_WhenQualityIsBelowTwo_StopsAtZero(
        int initialQuality)
    {
        // Arrange
        var items = new List<Item>();
        var sut = new GildedRose(items);

        var item = new Item
        {
            Name = ItemName.Conjured,
            SellIn = 5,
            Quality = initialQuality
        };

        items.Add(item);

        var expectedSellIn = 4;
        var expectedQuality = 0;

        // Act
        sut.UpdateQuality();

        // Assert
        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void UpdateQuality_OnOrAfterSellDate_WhenQualityIsBelowFour_StopsAtZero(
        int initialQuality)
    {
        // Arrange
        var items = new List<Item>();
        var sut = new GildedRose(items);

        var item = new Item
        {
            Name = ItemName.Conjured,
            SellIn = 0,
            Quality = initialQuality
        };

        items.Add(item);

        var expectedSellIn = -1;
        var expectedQuality = 0;

        // Act
        sut.UpdateQuality();

        // Assert
        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }

    [Fact]
    public void UpdateQuality_WhenCalledAcrossSellDate_AppliesBothDegradationRates()
    {
        // Arrange
        var items = new List<Item>();
        var sut = new GildedRose(items);

        var item = new Item
        {
            Name = ItemName.Conjured,
            SellIn = 1,
            Quality = 10
        };

        items.Add(item);

        var expectedSellIn = -1;
        var expectedQuality = 4;

        // Act
        sut.UpdateQuality();
        sut.UpdateQuality();

        // Assert
        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }
}