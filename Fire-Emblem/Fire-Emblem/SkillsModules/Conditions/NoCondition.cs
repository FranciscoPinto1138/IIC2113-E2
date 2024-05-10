namespace Fire_Emblem;

public class NoCondition : Condition
{
    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        return true;
    }
}