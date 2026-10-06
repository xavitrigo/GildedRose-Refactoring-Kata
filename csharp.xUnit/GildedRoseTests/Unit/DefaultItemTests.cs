using System.Collections.Generic;
using GildedRoseKata;
using Xunit;

namespace GildedRoseTests.Unit;

public sealed class DefaultItemTests
{
    [Theory]
    [InlineData(10, 20)]
    [InlineData(5, 7)]
    [InlineData(1, 1)]
    public void UpdateQuality_BeforeSellDate_DecreasesQualityByOne(
        int initialSellIn,
        int initialQuality)
    {
        // Arrange
        var items = new List<Item>();
        var sut = new GildedRose(items);

        var item = new Item
        {
            Name = ItemName.Default,
            SellIn = initialSellIn,
            Quality = initialQuality
        };

        items.Add(item);

        var expectedSellIn = initialSellIn - 1;
        var expectedQuality = initialQuality - 1;

        // Act
        sut.UpdateQuality();

        // Assert
        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }

    [Theory]
    [InlineData(0, 20)]
    [InlineData(-1, 10)]
    [InlineData(-10, 2)]
    public void UpdateQuality_OnOrAfterSellDate_DecreasesQualityByTwo(
        int initialSellIn,
        int initialQuality)
    {
        // Arrange
        var items = new List<Item>();
        var sut = new GildedRose(items);

        var item = new Item
        {
            Name = ItemName.Default,
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
    [InlineData(5)]
    [InlineData(1)]
    [InlineData(0)]
    [InlineData(-1)]
    public void UpdateQuality_WhenQualityIsZero_DoesNotBecomeNegative(
        int initialSellIn)
    {
        // Arrange
        var items = new List<Item>();
        var sut = new GildedRose(items);

        var item = new Item
        {
            Name = ItemName.Default,
            SellIn = initialSellIn,
            Quality = 0
        };

        items.Add(item);

        var expectedSellIn = initialSellIn - 1;
        const int expectedQuality = 0;

        // Act
        sut.UpdateQuality();

        // Assert
        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }

    [Fact]
    public void UpdateQuality_AfterSellDateWithQualityOne_StopsAtZero()
    {
        // Arrange
        var items = new List<Item>();
        var sut = new GildedRose(items);

        var item = new Item
        {
            Name = ItemName.Default,
            SellIn = 0,
            Quality = 1
        };

        items.Add(item);

        const int expectedSellIn = -1;
        const int expectedQuality = 0;

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
            Name = ItemName.Default,
            SellIn = 1,
            Quality = 10
        };

        items.Add(item);

        const int expectedSellIn = -1;
        const int expectedQuality = 7;

        // Act
        sut.UpdateQuality();
        sut.UpdateQuality();

        // Assert
        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }
}