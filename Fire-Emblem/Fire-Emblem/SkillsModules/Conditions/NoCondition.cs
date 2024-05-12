namespace Fire_Emblem;

public class NoCondition : Condition
{
    public NoCondition()
    {
        SetPriority(1);
    }
    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        return true;
    }
}