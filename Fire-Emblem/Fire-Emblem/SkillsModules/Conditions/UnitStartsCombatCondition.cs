namespace Fire_Emblem;

public class UnitStartsCombatCondition : Condition
{
    public UnitStartsCombatCondition()
    {
        SetPriority(1);
    }
    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        const string STARTING_COMBAT_ROLE = "Attacker";
        return unit.Role == STARTING_COMBAT_ROLE;
    }
}