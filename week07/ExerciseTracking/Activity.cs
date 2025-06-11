using System;

public abstract class Activity
{
    private DateTime _date;
    private int _lengthMinutes;

    public Activity(DateTime date, int lengthMinutes)
    {
        _date = date;
        _lengthMinutes = lengthMinutes;
    }

    public DateTime Date => _date;
    public int LengthMinutes => _lengthMinutes;

    // Abstract methods for derived classes to implement
    public abstract double GetDistance(); // miles or km depending on implementation
    public abstract double GetSpeed();    // mph or kph
    public abstract double GetPace();     // min per mile or min per km

    public virtual string GetSummary()
    {
        // Format example: "03 Nov 2022 Running (30 min): Distance 3.0 miles, Speed 6.0 mph, Pace: 10.0 min per mile"
        string dateStr = _date.ToString("dd MMM yyyy");
        string activityName = this.GetType().Name;
        return $"{dateStr} {activityName} ({_lengthMinutes} min): Distance {GetDistance():0.0} miles, Speed {GetSpeed():0.0} mph, Pace: {GetPace():0.00} min per mile";
    }
}
