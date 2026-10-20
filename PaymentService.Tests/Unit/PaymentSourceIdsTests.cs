using PaymentService.Models;

namespace PaymentService.Tests.Unit;

public class PaymentSourceIdsTests
{
    [Theory]
    [InlineData(PaymentSource.Stripe, "INC", PaymentSourceIds.StripeInc)]
    [InlineData(PaymentSource.Stripe, "inc", PaymentSourceIds.StripeInc)]
    [InlineData(PaymentSource.Stripe, "SIA", PaymentSourceIds.StripeSia)]
    [InlineData(PaymentSource.Swedbank, null, PaymentSourceIds.BankSia)]
    public void SourceFollowsTheAccount(PaymentSource source, string? account, long expected)
    {
        var tx = new NormalizedTransaction { Source = source, AccountName = account };

        Assert.Equal(expected, PaymentSourceIds.For(tx));
    }
}
