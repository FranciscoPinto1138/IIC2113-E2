namespace Fire_Emblem;

public class UnitStartsCombatCondition : Condition
{
    public UnitStartsCombatCondition()
    {
        SetPriority(1);
    }
    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        return unit.Role == "Attacker";
    }
}