namespace Fire_Emblem;

public class DragonskinCondition : Condition
{
    public DragonskinCondition()
    {
        SetPriority(1);
    }
    
    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        var opponentStartsCombatCondition = new OpponentStartsCombatCondition();
        var opponentHPCondition = new OpponentHPCondition(75, ThresholdType.Percentage, ComparisonType.GreaterThanOrEqual);
        return opponentStartsCombatCondition.IsConditionFulfilled(unit, opponent) || opponentHPCondition.IsConditionFulfilled(unit, opponent);
    }
}