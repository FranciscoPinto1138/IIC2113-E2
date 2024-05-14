namespace Fire_Emblem;

public class UnitIsInFirstTimeStartingCombatCondition : Condition
{
    public UnitIsInFirstTimeStartingCombatCondition()
    {
        SetPriority(1);
    }
    
    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        return unit.NumberOfTimesStartingCombat == 1;
    }
}