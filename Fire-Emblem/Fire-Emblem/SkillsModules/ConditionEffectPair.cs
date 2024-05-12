namespace Fire_Emblem;

public class ConditionEffectPair
{
    public Condition Condition;
    public Effect Effect;
    public int Priority;

    public ConditionEffectPair(Condition condition, Effect effect)
    {
        Condition = condition;
        Effect = effect;
        SetPriority();
    }
    
    private void SetPriority()
    {
        Priority = Math.Max(Condition.GetPriority(), Effect.GetPriority());
    }
}