namespace Fire_Emblem;

public class AndCondition : Condition
{
    private ConditionList _conditions;

    public AndCondition(ConditionList conditions)
    {
        _conditions = conditions;
    }

    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        foreach (var condition in _conditions.GetConditions())
        {
            if (!condition.IsConditionFulfilled(unit, opponent))
            {
                return false;
            }
        }
        return true;
    }
}