namespace AspNetCoreMvcSample.Helpers
{
    public class SalaryCalculate : ICalculate
    {
        public decimal Calculate(decimal amount)
        {
            amount = 8500;
            return amount;
        }
    }
}
