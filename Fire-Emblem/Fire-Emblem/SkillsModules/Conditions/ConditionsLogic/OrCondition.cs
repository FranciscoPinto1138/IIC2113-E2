namespace Fire_Emblem;

public class OrCondition : Condition
{
    private ConditionList _conditions;

    public OrCondition(ConditionList conditions)
    {
        _conditions = conditions;
    }

    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        foreach (var condition in _conditions.GetConditions())
        {
            if (condition.IsConditionFulfilled(unit, opponent))
            {
                return true;
            }
        }
        return false;
    }
}