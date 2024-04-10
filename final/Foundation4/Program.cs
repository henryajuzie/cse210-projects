using System;
using System.Collections.Generic;

public abstract class Activity
{
    protected DateTime date;
    protected int durationMinutes;

    public Activity(DateTime date, int durationMinutes)
    {
        this.date = date;
        this.durationMinutes = durationMinutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();
    public abstract string GetSummary();
}

public class Running : Activity
{
    private double distance;

    public Running(DateTime date, int durationMinutes, double distance) : base(date, durationMinutes)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return distance / durationMinutes * 60;
    }

    public override double GetPace()
    {
        return durationMinutes / distance;
    }

    public override string GetSummary()
    {
        return $"{date:dd MMM yyyy} Running ({durationMinutes} min): Distance {distance} miles, Speed {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}

public class Cycling : Activity
{
    private double speed;

    public Cycling(DateTime date, int durationMinutes, double speed) : base(date, durationMinutes)
    {
        this.speed = speed;
    }

    public override double GetDistance()
    {
        return speed * durationMinutes / 60;
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetPace()
    {
        return 60 / speed;
    }

    public override string GetSummary()
    {
        return $"{date:dd MMM yyyy} Cycling ({durationMinutes} min): Distance {GetDistance()} miles, Speed {speed} mph, Pace: {GetPace()} min per mile";
    }
}

public class Swimming : Activity
{
    private int laps;

    public Swimming(DateTime date, int durationMinutes, int laps) : base(date, durationMinutes)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 50 / 1000 * 0.62; // Convert meters to miles
    }

    public override double GetSpeed()
    {
        return GetDistance() / durationMinutes * 60;
    }

    public override double GetPace()
    {
        return durationMinutes / GetDistance();
    }

    public override string GetSummary()
    {
        return $"{date:dd MMM yyyy} Swimming ({durationMinutes} min): Distance {GetDistance()} miles, Speed {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running(new DateTime(2023, 11, 3), 30, 3.0));
        activities.Add(new Cycling(new DateTime(2023, 11, 3), 30, 6.0));
        activities.Add(new Swimming(new DateTime(2023, 11, 3), 30, 10));

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
