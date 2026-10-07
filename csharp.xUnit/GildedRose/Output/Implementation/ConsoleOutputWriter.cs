using System;
using GildedRoseKata.Output.Contract;

namespace GildedRoseKata.Output.Implementation;

public sealed class ConsoleOutputWriter : IOutputWriter
{
    public void Write(string report) => Console.Write(report);
}