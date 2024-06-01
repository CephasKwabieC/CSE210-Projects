using System;
using System.Collections.Generic;

public abstract class Activity
{
    public DateTime Date { get; set; }
    public int LengthInMinutes { get; set; }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();
    public abstract string GetSummary();
}

public class Running : Activity
{
    public double Distance { get; set; } // in miles

    public override double GetDistance()
    {
        return Distance;
    }

    public override double GetSpeed()
    {
        return Distance / (LengthInMinutes / 60.0); // in mph
    }

    public override double GetPace()
    {
        return LengthInMinutes / Distance; // in minutes per mile
    }

    public override string GetSummary()
    {
        return $"{Date.ToString("dd MMM yyyy")} Running ({LengthInMinutes} min) - Distance {Distance} miles, Speed {GetSpeed():F2} mph, Pace: {GetPace():F2} min per mile";
    }
}

public class Cycling : Activity
{
    public double Speed { get; set; } // in mph

    public override double GetDistance()
    {
        return Speed * (LengthInMinutes / 60.0); // in miles
    }

    public override double GetSpeed()
    {
        return Speed; // in mph
    }

    public override double GetPace()
    {
        return LengthInMinutes / GetDistance(); // in minutes per mile
    }

    public override string GetSummary()
    {
        return $"{Date.ToString("dd MMM yyyy")} Cycling ({LengthInMinutes} min) - Distance {GetDistance():F2} miles, Speed {Speed:F2} mph, Pace: {GetPace():F2} min per mile";
    }
}

public class Swimming : Activity
{
    public int NumberOfLaps { get; set; }

    public override double GetDistance()
    {
        return NumberOfLaps * 50 / 1000.0 * 0.62; // in miles
    }

    public override double GetSpeed()
    {
        return GetDistance() / (LengthInMinutes / 60.0); // in mph
    }

    public override double GetPace()
    {
        return LengthInMinutes / GetDistance(); // in minutes per mile
    }

    public override string GetSummary()
    {
        return $"{Date.ToString("dd MMM yyyy")} Swimming ({LengthInMinutes} min) - Distance {GetDistance():F2} miles, Speed {GetSpeed():F2} mph, Pace: {GetPace():F2} min per mile";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running { Date = DateTime.Parse("03 Nov 2022"), LengthInMinutes = 30, Distance = 3.0 },
            new Cycling { Date = DateTime.Parse("04 Nov 2022"), LengthInMinutes = 30, Speed = 10.0 },
            new Swimming { Date = DateTime.Parse("05 Nov 2022"), LengthInMinutes = 30, NumberOfLaps = 20 }
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
