namespace Fire_Emblem;

public class EmptySkill : Skill
{
    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return Array.Empty<ConditionEffectPair>();
    }
}