using System;

public class Swimming : Activity
{
    private int _laps;
    private const double LapLengthMeters = 50.0;

    public Swimming(DateTime date, int lengthMinutes, int laps)
        : base(date, lengthMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        // Distance in miles = laps * 50m / 1000 * 0.62
        return (_laps * LapLengthMeters / 1000.0) * 0.62;
    }

    public override double GetSpeed()
    {
        // speed = distance / time * 60 (mph)
        return (GetDistance() / LengthMinutes) * 60;
    }

    public override double GetPace()
    {
        // pace = minutes per mile
        return LengthMinutes / GetDistance();
    }
}
