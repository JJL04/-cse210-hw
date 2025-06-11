using System;

public class Running : Activity
{
    private double _distanceMiles;

    public Running(DateTime date, int lengthMinutes, double distanceMiles)
        : base(date, lengthMinutes)
    {
        _distanceMiles = distanceMiles;
    }

    public override double GetDistance()
    {
        return _distanceMiles;
    }

    public override double GetSpeed()
    {
        // speed = (distance / time) * 60
        return (GetDistance() / LengthMinutes) * 60;
    }

    public override double GetPace()
    {
        // pace = minutes per mile
        return LengthMinutes / GetDistance();
    }
}
