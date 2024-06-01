using System;
using System.Collections.Generic;

public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
}

public abstract class Event
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
    public Address Address { get; set; }

    public abstract string GetFullDetails();
    public abstract string GetShortDescription();

    public string GetStandardDetails()
    {
        return $"{Title}\n{Description}\n{Date}\n{Time}\n{Address.Street}, {Address.City}, {Address.State}, {Address.Country}";
    }
}

public class Lecture : Event
{
    public string Speaker { get; set; }
    public int Capacity { get; set; }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nSpeaker: {Speaker}\nCapacity: {Capacity}";
    }

    public override string GetShortDescription()
    {
        return $"Lecture: {Title} on {Date.ToShortDateString()}";
    }
}

public class Reception : Event
{
    public string RsvpEmail { get; set; }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nRSVP Email: {RsvpEmail}";
    }

    public override string GetShortDescription()
    {
        return $"Reception: {Title} on {Date.ToShortDateString()}";
    }
}

public class OutdoorGathering : Event
{
    public string WeatherForecast { get; set; }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nWeather Forecast: {WeatherForecast}";
    }

    public override string GetShortDescription()
    {
        return $"Outdoor Gathering: {Title} on {Date.ToShortDateString()}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Event> events = new List<Event>
        {
            new Lecture { Title = "Lecture 1", Description = "Description 1", Date = DateTime.Now, Time = TimeSpan.FromHours(2), Address = new Address { Street = "123 Main St", City = "Anytown", State = "NY", Country = "USA" }, Speaker = "John Doe", Capacity = 100 },
            new Reception { Title = "Reception 1", Description = "Description 2", Date = DateTime.Now, Time = TimeSpan.FromHours(3), Address = new Address { Street = "456 Maple St", City = "Othertown", State = "CA", Country = "USA" }, RsvpEmail = "rsvp@example.com" },
            new OutdoorGathering { Title = "Outdoor Gathering 1", Description = "Description 3", Date = DateTime.Now, Time = TimeSpan.FromHours(4), Address = new Address { Street = "789 Oak St", City = "Sometown", State = "TX", Country = "USA" }, WeatherForecast = "Sunny" },

        };

        foreach (var event in events)
        {
            Console.WriteLine(event.GetFullDetails());
            Console.WriteLine();
        }
    }
}
