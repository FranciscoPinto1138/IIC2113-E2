namespace Fire_Emblem;

public class Gentility : AbsoluteDamageReduction
{
    public Gentility()
    {
        this.Name = "Gentility";
        this.Description = "La unidad recibe -5 de daño en cada ataque del rival";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        var condition = new NoCondition();
        var effectOnUnit = new ReduceReceivedDamageByAbsoluteValue(5);
        return new ConditionEffectPair[] { new ConditionEffectPair(condition, effectOnUnit) };
    }
}