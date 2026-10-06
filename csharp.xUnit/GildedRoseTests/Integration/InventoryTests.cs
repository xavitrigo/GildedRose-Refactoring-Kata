using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using GildedRoseKata;
using VerifyXunit;
using Xunit;

namespace GildedRoseTests.Integration;

public sealed class InventoryTests
{
    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    public async Task RequestedNumberOfDays(int numberOfDays)
    {
        var sut = Program.Main;

        var originalOutput = Console.Out;
        await using var output = new StringWriter(CultureInfo.InvariantCulture);

        var arguments = new[]
        {
            numberOfDays.ToString(CultureInfo.InvariantCulture)
        };
        
        Console.SetOut(output);

        // Act
        sut(arguments);
            
        Console.SetOut(originalOutput);

        // Assert
        await Verifier
            .Verify(output.ToString())
            .UseParameters(numberOfDays);
    }
}