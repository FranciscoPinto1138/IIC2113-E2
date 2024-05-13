namespace Fire_Emblem;

public class NotCondition : Condition
{
    private Condition _condition;

    public NotCondition(Condition condition)
    {
        _condition = condition;
        SetPriority(_condition.GetPriority());
    }

    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        return !_condition.IsConditionFulfilled(unit, opponent);
    }
}