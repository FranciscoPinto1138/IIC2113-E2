namespace Fire_Emblem;

public class UnitIsInFirstTimeNotStartingCombatCondition : Condition
{
    public UnitIsInFirstTimeNotStartingCombatCondition()
    {
        SetPriority(1);
    }
    
    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        const int firstTimeRivalStartingCombat = 1;
        return unit.NumberOfTimesRivalStartsCombat == firstTimeRivalStartingCombat;
    }
}