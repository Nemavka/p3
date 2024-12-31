using System;
public class SunDayLengthCalculator
{
    public double Latitude { get; set; } 
    public string City { get; set; } 
    public double SunInclination { get; set; } 

    public SunDayLengthCalculator(string city, double sunInclination, double latitude)
    {
        City = city;
        SunInclination = sunInclination;
        Latitude = latitude;
    }

    public double CalculateDayLength()
    {
        double latitudeInRadians = Latitude * Math.PI / 180;
        double sunInclinationInRadians = SunInclination * Math.PI / 180;
        double dayLengthInHours = (24 / Math.PI) * Math.Acos(-Math.Tan(latitudeInRadians) * Math.Tan(sunInclinationInRadians));

        return dayLengthInHours * 3600; 
    }

    public string FormatTime(double totalSeconds)
    {
        int hours = (int)(totalSeconds / 3600);
        totalSeconds %= 3600;

        int minutes = (int)(totalSeconds / 60);
        int seconds = (int)(totalSeconds % 60);

        return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введіть назву міста:");
        string city = Console.ReadLine();

        Console.WriteLine("Введіть широту міста:");
        double latitude = double.Parse(Console.ReadLine());

        Console.WriteLine("Введіть нахил Сонця:");
        double sunInclination = double.Parse(Console.ReadLine());

        SunDayLengthCalculator dl = new SunDayLengthCalculator(city, latitude, sunInclination);
        double dayLengthInSeconds = dl.CalculateDayLength();
        Console.WriteLine($"Довжина дня для міста {dl.City} (широта: {dl.Latitude}, нахил Сонця: {dl.SunInclination}) : {dl.FormatTime(dayLengthInSeconds)}");
    }
}
