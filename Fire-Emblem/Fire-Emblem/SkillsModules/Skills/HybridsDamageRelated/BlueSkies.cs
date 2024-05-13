namespace Fire_Emblem;

public class BlueSkies : Hybrid
{
    public BlueSkies()
    {
        this.Name = "Blue Skies";
        this.Description = "La unidad recibe -5 de daño en cada ataque del rival e inflige +5 de daño en cada ataque.";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        var condition = new NoCondition();
        var firstEffectOnUnit = new IncreaseExtraDamage(5);
        var secondEffectOnUnit = new ReduceReceivedDamageByAbsoluteValue(5);
        return new ConditionEffectPair[] { new ConditionEffectPair(condition, firstEffectOnUnit),
            new ConditionEffectPair(condition, secondEffectOnUnit) };
    }
}