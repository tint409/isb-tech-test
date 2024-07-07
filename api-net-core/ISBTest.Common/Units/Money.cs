namespace ISBTest.Common.Units
{
    public class Money
    {
        public Money() : this(0)
        { }

        public Money(decimal amount) : this(amount, "USD")
        { }

        public Money(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }
        public Money(string concatenatedStr)
        {
            var splitted = concatenatedStr.Split(' ');
            Amount = decimal.Parse(splitted[1]);
            Currency = splitted[0];
        }

        public decimal Amount { get; set; }

        private string? _currency;
        public string? Currency 
        {
            get => _currency;
            set => _currency = value?.ToUpper();
        }
    }

}
