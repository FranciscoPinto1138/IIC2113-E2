namespace Fire_Emblem;

public class UnitIsInFirstTimeStartingCombatCondition : Condition
{
    public UnitIsInFirstTimeStartingCombatCondition()
    {
        SetPriority(1);
    }
    
    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        const int FIRST_TIME_STARTING_COMBAT = 1;
        return unit.NumberOfTimesStartingCombat == FIRST_TIME_STARTING_COMBAT;
    }
}