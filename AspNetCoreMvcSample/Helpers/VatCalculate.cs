namespace AspNetCoreMvcSample.Helpers
{
    public class VatCalculate : ICalculate
    {
        public decimal Calculate(decimal amount)
        {
            return amount + (amount * 18 / 100);
        }
    }
}
