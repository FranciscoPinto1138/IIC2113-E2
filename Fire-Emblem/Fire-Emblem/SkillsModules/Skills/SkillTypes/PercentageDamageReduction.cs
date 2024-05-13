namespace Fire_Emblem;

public abstract class PercentageDamageReduction : Skill
{
    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        throw new NotImplementedException();
    }
    
    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        throw new NotImplementedException();
    }
}