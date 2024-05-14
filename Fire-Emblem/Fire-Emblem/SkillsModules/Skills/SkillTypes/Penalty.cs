namespace Fire_Emblem;

public abstract class Penalty : Skill
{
    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        throw new NotImplementedException();
    }
}