namespace Fire_Emblem;

public class OpponentStartsCombatCondition : Condition
{
    public OpponentStartsCombatCondition()
    {
        SetPriority(1);
    }
    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        return opponent.Role == "Attacker";
    }
}