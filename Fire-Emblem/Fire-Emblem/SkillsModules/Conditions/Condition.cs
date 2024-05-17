namespace Fire_Emblem;

public abstract class Condition
{
    private int _priority;
    public abstract bool IsConditionFulfilled(Unit unit, Unit opponent);
    public int GetPriority()
    {
        return _priority;
    }

    protected void SetPriority(int priority)
    {
        _priority = priority;
    }
}