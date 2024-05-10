namespace Fire_Emblem;

public class UnitStartsCombatCondition : Condition
{
    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        return unit.Role == "Attacker";
    }
}