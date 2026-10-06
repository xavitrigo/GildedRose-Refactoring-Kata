using System.Collections.Generic;
using GildedRoseKata;
using Xunit;

namespace GildedRoseTests.Unit;

public sealed class BackstagePassItemTests
{
    [Theory]
    [InlineData(15, 20)]
    [InlineData(12, 10)]
    [InlineData(11, 0)]
    public void UpdateQuality_WithMoreThanTenDaysRemaining_IncreasesQualityByOne(int initialSellIn, int initialQuality)
    {
        // Arrange
        var items = new List<Item>();
        var sut = new GildedRose(items);

        var item = new Item
        {
            Name = ItemName.BackstagePass,
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
    [InlineData(10, 20)]
    [InlineData(8, 10)]
    [InlineData(6, 0)]
    public void UpdateQuality_WithSixToTenDaysRemaining_IncreasesQualityByTwo(int initialSellIn, int initialQuality)
    {
        // Arrange
        var items = new List<Item>();
        var sut = new GildedRose(items);

        var item = new Item
        {
            Name = ItemName.BackstagePass,
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
    [InlineData(5, 20)]
    [InlineData(3, 10)]
    [InlineData(1, 0)]
    public void UpdateQuality_WithOneToFiveDaysRemaining_IncreasesQualityByThree(int initialSellIn, int initialQuality)
    {
        // Arrange
        var items = new List<Item>();
        var sut = new GildedRose(items);

        var item = new Item
        {
            Name = ItemName.BackstagePass,
            SellIn = initialSellIn,
            Quality = initialQuality
        };

        items.Add(item);

        var expectedSellIn = initialSellIn - 1;
        var expectedQuality = initialQuality + 3;

        // Act
        sut.UpdateQuality();

        // Assert
        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }

    [Theory]
    [InlineData(0, 20)]
    [InlineData(-1, 20)]
    [InlineData(-10, 50)]
    public void UpdateQuality_OnOrAfterConcert_SetsQualityToZero(int initialSellIn, int initialQuality)
    {
        // Arrange
        var items = new List<Item>();
        var sut = new GildedRose(items);

        var item = new Item
        {
            Name = ItemName.BackstagePass,
            SellIn = initialSellIn,
            Quality = initialQuality
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

    [Theory]
    [InlineData(15)]
    [InlineData(10)]
    [InlineData(5)]
    [InlineData(1)]
    public void UpdateQuality_WhenQualityIsFifty_DoesNotIncrease(int initialSellIn)
    {
        // Arrange
        var items = new List<Item>();
        var sut = new GildedRose(items);

        var item = new Item
        {
            Name = ItemName.BackstagePass,
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

    [Theory]
    [InlineData(15, 49)]
    [InlineData(10, 49)]
    [InlineData(10, 48)]
    [InlineData(5, 49)]
    [InlineData(5, 48)]
    [InlineData(5, 47)]
    public void UpdateQuality_WhenIncreaseWouldExceedFifty_StopsAtFifty(int initialSellIn, int initialQuality)
    {
        // Arrange
        var items = new List<Item>();
        var sut = new GildedRose(items);

        var item = new Item
        {
            Name = ItemName.BackstagePass,
            SellIn = initialSellIn,
            Quality = initialQuality
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
}