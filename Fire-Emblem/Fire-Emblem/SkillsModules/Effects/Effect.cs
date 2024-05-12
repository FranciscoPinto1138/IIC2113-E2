namespace Fire_Emblem;

public abstract class Effect
{
    private int _priority;
    public abstract void ApplyEffect(Unit unit, Unit opponent);
    public int GetPriority()
    {
        return _priority;
    }

    protected void SetPriority(int priority)
    {
        _priority = priority;
    }
}