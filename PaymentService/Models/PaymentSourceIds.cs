namespace PaymentService.Models;

// OT_PAYMENT.SOURCE_ID - MOLPORT.ADM_CODIF_ENTRY of codificator 66 OT_PAYMENT_SOURCE (as BackOffice's
// ConstantBundle.PaymentSources). Stripe: the account the charge was made on; Swedbank: SIA's bank.
public static class PaymentSourceIds
{
    public const long BankSia = 12136;
    public const long StripeInc = 12137;
    public const long StripeSia = 12138;

    public static long For(NormalizedTransaction tx) =>
        tx.Source == PaymentSource.Swedbank ? BankSia
        : string.Equals(tx.AccountName, "INC", StringComparison.OrdinalIgnoreCase) ? StripeInc
        : StripeSia;
}
