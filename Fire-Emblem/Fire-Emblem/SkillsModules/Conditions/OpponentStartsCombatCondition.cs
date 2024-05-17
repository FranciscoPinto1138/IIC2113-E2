namespace Fire_Emblem;

public class OpponentStartsCombatCondition : Condition
{
    public OpponentStartsCombatCondition()
    {
        SetPriority(1);
    }
    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        const string STARTING_COMBAT_ROLE = "Attacker";
        return opponent.Role == STARTING_COMBAT_ROLE;
    }
}