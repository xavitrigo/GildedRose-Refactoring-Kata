namespace GildedRoseKata.Report.Contract;

public interface IReportGenerator
{
    string Generate(int days);
}