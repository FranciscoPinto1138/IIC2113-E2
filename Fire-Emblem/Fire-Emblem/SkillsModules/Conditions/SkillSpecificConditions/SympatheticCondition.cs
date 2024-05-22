namespace Fire_Emblem;

public class SympatheticCondition : Condition
{
    public SympatheticCondition()
    {
        SetPriority(1);
    }
    
    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        var opponentStartsCombatCondition = new OpponentStartsCombatCondition();
        var opponentHPCondition = new OpponentHPCondition(50, ThresholdType.Percentage, ComparisonType.LowerThanOrEqual);
        return opponentStartsCombatCondition.IsConditionFulfilled(unit, opponent) || opponentHPCondition.IsConditionFulfilled(unit, opponent);
    }
}
