using System;

public class Cycling : Activity
{
    private double _speedMph;

    public Cycling(DateTime date, int lengthMinutes, double speedMph)
        : base(date, lengthMinutes)
    {
        _speedMph = speedMph;
    }

    public override double GetDistance()
    {
        // distance = speed * time (hours)
        return _speedMph * (LengthMinutes / 60.0);
    }

    public override double GetSpeed()
    {
        return _speedMph;
    }

    public override double GetPace()
    {
        // pace = minutes per mile = 60 / speed
        return 60 / _speedMph;
    }
}
