abstract class GeographicObject
{
    public double X { get; set; }
    public double Y { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public virtual string GetInformation()
    {
        return $"Name: {Name}\nCoordinates: ({X}, {Y})\nDescription: {Description}";
    }
}

class River : GeographicObject
{
    public double FlowSpeed { get; set; }
    public double TotalLength { get; set; }

    public override string GetInformation()
    {
        return base.GetInformation() + $"\nFlow speed: {FlowSpeed} cm/s\nTotal length: {TotalLength}";
    }
}

class Mountain : GeographicObject
{
    public double HighestPoint { get; set; }

    public override string GetInformation()
    {
        return base.GetInformation() + $"\nHighest point: {HighestPoint}";
    }
}

class Program
{
    static void Main()
    {
        River river = new River
        {
            X = 30.5,
            Y = 40.2,
            Name = "Дніпро",
            Description = "Друга за довжиною річка в Європі",
            FlowSpeed = 50.3,
            TotalLength = 2200
        };

        Mountain mountain = new Mountain
        {
            X = 50.7,
            Y = 60.9,
            Name = "Еверест",
            Description = "Найвища гора світу",
            HighestPoint = 8848
        };

        Console.WriteLine("River info:");
        Console.WriteLine(river.GetInformation());

        Console.WriteLine("\nMountain info:");
        Console.WriteLine(mountain.GetInformation());
    }
}