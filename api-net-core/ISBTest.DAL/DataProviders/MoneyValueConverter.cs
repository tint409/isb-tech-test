using ISBTest.Common.Units;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ISBTest.DAL.DataProviders;

public class MoneyValueConverter : ValueConverter<Money, string>
{
    public MoneyValueConverter()
        : base(
            money => money.Currency + " " + money.Amount.ToString("0.00"),
            strValue => new Money(strValue))
    {
    }
}
