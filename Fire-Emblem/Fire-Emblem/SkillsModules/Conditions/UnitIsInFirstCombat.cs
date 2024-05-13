namespace Fire_Emblem;

public class UnitIsInFirstCombat : Condition
{
    public UnitIsInFirstCombat()
    {
        SetPriority(1);
    }
    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        return unit.MostRecentRival == "";
    }
}