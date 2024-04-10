using System;

// Address class
class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public override string ToString()
    {
        return $"{street}, {city}, {state}, {country}";
    }
}

// Base Event class
class Event
{
    protected string title;
    protected string description;
    protected DateTime dateTime;
    protected Address address;

    public Event(string title, string description, DateTime dateTime, Address address)
    {
        this.title = title;
        this.description = description;
        this.dateTime = dateTime;
        this.address = address;
    }

    public virtual string GenerateStandardDetails()
    {
        return $"Event: {title}\nDescription: {description}\nDate: {dateTime.ToShortDateString()}\nTime: {dateTime.ToShortTimeString()}\nAddress: {address}";
    }

    public virtual string GenerateFullDetails()
    {
        return GenerateStandardDetails();
    }

    public virtual string GenerateShortDescription()
    {
        return $"Type: Event\nTitle: {title}\nDate: {dateTime.ToShortDateString()}";
    }
}

// Derived Lecture class
class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, DateTime dateTime, Address address, string speaker, int capacity)
        : base(title, description, dateTime, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public override string GenerateFullDetails()
    {
        return base.GenerateStandardDetails() + $"\nType: Lecture\nSpeaker: {speaker}\nCapacity: {capacity}";
    }
}

// Derived Reception class
class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, DateTime dateTime, Address address, string rsvpEmail)
        : base(title, description, dateTime, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public override string GenerateFullDetails()
    {
        return base.GenerateStandardDetails() + $"\nType: Reception\nRSVP Email: {rsvpEmail}";
    }
}

// Derived OutdoorGathering class
class OutdoorGathering : Event
{
    private string weatherForecast;

    public OutdoorGathering(string title, string description, DateTime dateTime, Address address, string weatherForecast)
        : base(title, description, dateTime, address)
    {
        this.weatherForecast = weatherForecast;
    }

    public override string GenerateFullDetails()
    {
        return base.GenerateStandardDetails() + $"\nType: Outdoor Gathering\nWeather Forecast: {weatherForecast}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address lectureAddress = new Address("123 Main St", "Cityville", "Stateville", "Countryland");
        Address receptionAddress = new Address("456 Elm St", "Townsville", "Provinceville", "Countryland");
        Address outdoorAddress = new Address("789 Oak St", "Villageton", "Territoryville", "Countryland");

        // Create events
        Lecture lecture = new Lecture("Lecture Title", "Lecture Description", DateTime.Now, lectureAddress, "John Doe", 50);
        Reception reception = new Reception("Reception Title", "Reception Description", DateTime.Now, receptionAddress, "rsvp@example.com");
        OutdoorGathering outdoorGathering = new OutdoorGathering("Outdoor Gathering Title", "Outdoor Gathering Description", DateTime.Now, outdoorAddress, "Sunny");

        // Generate marketing messages
        Console.WriteLine(lecture.GenerateFullDetails());
        Console.WriteLine(reception.GenerateFullDetails());
        Console.WriteLine(outdoorGathering.GenerateFullDetails());
    }
}
