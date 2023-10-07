using System;

public class Converter
{
    private decimal usdRate;
    private decimal eurRate;

    public Converter(decimal usdRate, decimal eurRate)
    {
        this.usdRate = usdRate;
        this.eurRate = eurRate;
    }

    public decimal ConvertToUSD(decimal amount)
    {
        return amount / usdRate;
    }

    public decimal ConvertToEUR(decimal amount)
    {
        return amount / eurRate;
    }

    public decimal ConvertFromUSD(decimal amount)
    {
        return amount * usdRate;
    }

    public decimal ConvertFromEUR(decimal amount)
    {
        return amount * eurRate;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the USD rate (UAH for one USD):");
        decimal usdRate = ReadPositiveDecimal();
        Console.WriteLine("\nEnter the EURO rate (UAH for one EURO):");
        decimal eurRate = ReadPositiveDecimal();

        Converter converter = new Converter(usdRate, eurRate);

        while (true)
        {
            Console.WriteLine("\nChoose an operation:");
            Console.WriteLine("1. Convert from UAH to USD");
            Console.WriteLine("2. Convert from UAH to EURO");
            Console.WriteLine("3. Convert from USD to UAH");
            Console.WriteLine("4. Convert from EUROS to UAH");
            Console.WriteLine("5. Exit\n");

            int choice = ReadIntInRange(1, 5);

            decimal amount;
            decimal result;

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nEnter the amount in UAH:");
                    amount = ReadPositiveDecimal();
                    result = converter.ConvertToUSD(amount);
                    Console.WriteLine($"{amount} UAH = {result} USD");
                    break;
                case 2:
                    Console.WriteLine("\nEnter the amount in UAH:");
                    amount = ReadPositiveDecimal();
                    result = converter.ConvertToEUR(amount);
                    Console.WriteLine($"{amount} UAH = {result} EUR");
                    break;
                case 3:
                    Console.WriteLine("\nEnter the amount in USD:");
                    amount = ReadPositiveDecimal();
                    result = converter.ConvertFromUSD(amount);
                    Console.WriteLine($"{amount} USD = {result} UAH");
                    break;
                case 4:
                    Console.WriteLine("\nEnter the amount in EURO:");
                    amount = ReadPositiveDecimal();
                    result = converter.ConvertFromEUR(amount);
                    Console.WriteLine($"{amount} EUR = {result} UAH");
                    break;
                case 5:
                    return;
            }
        }
    }

    static decimal ReadPositiveDecimal()
    {
        decimal result;
        while (true)
        {
            if (decimal.TryParse(Console.ReadLine(), out result) && result > 0)
            {
                return result;
            }
            Console.WriteLine("\nInvalid value entered. Please enter a positive number.\n");
        }
    }

    static int ReadIntInRange(int min, int max)
    {
        int result;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out result) && result >= min && result <= max)
            {
                return result;
            }
            Console.WriteLine($"Invalid value entered. Please enter a number between {min} and {max}.");
        }
    }
}
