namespace Fire_Emblem;

public abstract class Skill
{
    protected string Name { get; set; }
    protected string Description { get; set; }
    public abstract ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent);
}