public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        _isComplete = true;
        return GetPoints();
    }

    public override bool IsComplete() => _isComplete;

    public override string GetDetails() =>
        $"[{(_isComplete ? "X" : " ")}] {GetName()} ({GetDescription()})";

    public override string GetStringRepresentation() =>
        $"SimpleGoal:{GetName()},{GetDescription()},{GetPoints()},{_isComplete}";
}
