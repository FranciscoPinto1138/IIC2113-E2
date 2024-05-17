namespace Fire_Emblem;

public class UnitIsInFirstCombatCondition : Condition
{
    public UnitIsInFirstCombatCondition()
    {
        SetPriority(1);
    }
    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        const string NO_RECENT_RIVAL = "";
        return unit.MostRecentRival == NO_RECENT_RIVAL;
    }
}