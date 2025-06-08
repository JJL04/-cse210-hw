public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordEvent() => GetPoints();
    public override bool IsComplete() => false;

    public override string GetDetails() =>
        $"[∞] {GetName()} ({GetDescription()})";

    public override string GetStringRepresentation() =>
        $"EternalGoal:{GetName()},{GetDescription()},{GetPoints()}";
}
