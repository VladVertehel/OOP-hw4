interface IGeographicObject
{
    string GetInformation();
}

class River : IGeographicObject
{
    public double X { get; set; }
    public double Y { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double FlowSpeed { get; set; }
    public double TotalLength { get; set; }

    public string GetInformation()
    {
        return $"Name: {Name}\nCoordinates: ({X}, {Y})\nDescription: {Description}\nFlow speed: {FlowSpeed} cm/s\nTotal length: {TotalLength}";
    }
}

class Mountain : IGeographicObject
{
    public double X { get; set; }
    public double Y { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double HighestPoint { get; set; }

    public string GetInformation()
    {
        return $"Name: {Name}\nCoordinates: ({X}, {Y})\nDescription: {Description}\nHighest point: {HighestPoint}";
    }
}

class Program
{
    static void Main()
    {
        // Створюємо об'єкти річка і гора
        IGeographicObject river = new River
        {
            X = 30.5,
            Y = 40.2,
            Name = "Дніпро",
            Description = "Друга за довжиною річка в Європі",
            FlowSpeed = 50.3,
            TotalLength = 2200
        };

        IGeographicObject mountain = new Mountain
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
