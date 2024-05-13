namespace Fire_Emblem;

public class AndPairCondition : Condition
{
    private Condition _firstCondition;
    private Condition _secondCondition;
    
    public AndPairCondition(Condition firstCondition, Condition secondCondition)
    {
        _firstCondition = firstCondition;
        _secondCondition = secondCondition;
        SetTotalPriority();
    }

    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        return _firstCondition.IsConditionFulfilled(unit, opponent) && _secondCondition.IsConditionFulfilled(unit, opponent);
    }
    
    private void SetTotalPriority()
    {
        SetPriority(Math.Max(_firstCondition.GetPriority(), _secondCondition.GetPriority()));
    }
}