namespace Fire_Emblem;

public class UnitIsInFirstTimeNotStartingCombatCondition : Condition
{
    public UnitIsInFirstTimeNotStartingCombatCondition()
    {
        SetPriority(1);
    }
    
    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        const int FIRST_TIME_RIVAL_STARTING_COMBAT = 1;
        return unit.NumberOfTimesRivalStartsCombat == FIRST_TIME_RIVAL_STARTING_COMBAT;
    }
}