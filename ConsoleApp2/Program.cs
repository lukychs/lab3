class Currency
{
    public double value { get; set; }

    public Currency(double value)
    {
        this.value = value;
    }

    public override string ToString()
    {
        return $"{value}";
    }
}

class CurrencyRUB : Currency
{
    public static double exchangeUSD { get; set; }
    public static double exchangeEUR { get; set; }

    public CurrencyRUB(double value) : base(value) { }

    public static explicit operator CurrencyUSD(CurrencyRUB currencyRUB) {
        return new CurrencyUSD(currencyRUB.value * exchangeUSD);
    }

    public static implicit operator CurrencyEUR(CurrencyRUB currencyRUB)
    {
        return new CurrencyEUR(currencyRUB.value * exchangeEUR);
    }
}


class CurrencyEUR : Currency
{
    public static double exchangeRUB { get; set; }
    public static double exchangeUSD { get; set; }

    public CurrencyEUR(double value) : base(value){}

    public static explicit operator CurrencyRUB(CurrencyEUR currencyEUR)
    {
        return new CurrencyRUB(currencyEUR.value * exchangeRUB);
    }

    public static implicit operator CurrencyUSD(CurrencyEUR currencyEUR)
    {
        return new CurrencyUSD(currencyEUR.value * exchangeUSD);
    }
}

class CurrencyUSD : Currency
{
    public static double exchangeRUB { get; set; }
    public static double exchangeEUR { get; set; }

    public CurrencyUSD(double value) : base(value){}

    public static explicit operator CurrencyRUB(CurrencyUSD currencyUSD)
    {
        return new CurrencyRUB(currencyUSD.value * exchangeRUB);
    }

    public static implicit operator CurrencyEUR(CurrencyUSD currencyUSD)
    {
        return new CurrencyEUR(currencyUSD.value * exchangeEUR);
    }
}

class Program
{
    static void Main(string[] args)
    {
        double val = 100;

        Console.Write("Введите обменный курс долларов в евро: ");
        CurrencyUSD.exchangeEUR = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите обменный курс долларов в рубли: ");
        CurrencyUSD.exchangeRUB = Convert.ToDouble(Console.ReadLine());

        CurrencyUSD curUSD = new CurrencyUSD(val);
        CurrencyEUR curEUR = curUSD;
        Console.WriteLine($"Из долларов в евро: {curEUR}");

        CurrencyRUB curRUB = (CurrencyRUB)curUSD;
        Console.WriteLine($"Из долларов в рубли: {curRUB}");
    }
}