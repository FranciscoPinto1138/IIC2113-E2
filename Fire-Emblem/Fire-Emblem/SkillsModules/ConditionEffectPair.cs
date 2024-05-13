namespace Fire_Emblem;

public class ConditionEffectPair
{
    private Condition _condition;
    private Effect _effect;
    private int _priority;

    public ConditionEffectPair(Condition condition, Effect effect)
    {
        _condition = condition;
        _effect = effect;
        SetPriority();
    }
    
    public void ApplyEffectIfConditionIsSatisfied(Unit unit, Unit opponent)
    {
        if (_condition.IsConditionFulfilled(unit, opponent))
        {
            _effect.ApplyEffect(unit, opponent);
        }
    }
    
    public int GetPriority()
    {
        return _priority;
    }
    
    private void SetPriority()
    {
        _priority = Math.Max(_condition.GetPriority(), _effect.GetPriority());
    }
}