namespace Fire_Emblem;

public class Sympathetic : AbsoluteDamageReduction
{
    public Sympathetic()
    {
        this.Name = "Sympathetic";
        this.Description = "Si el rival inicia el combate y el HP de la unidad está al 50% o menos al inicio del combate, la unidad recibe -5 daño en cada ataque del rival.";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        var firstCondition = new OpponentStartsCombatCondition();
        var secondCondition = new UnitHPCondition(50, ThresholdType.Percentage, ComparisonType.LowerThanOrEqual);
        var andCombinedCondition = new AndPairCondition(firstCondition, secondCondition);
        var effectOnUnit = new ReduceReceivedDamageByAbsoluteValue(5);
        return new ConditionEffectPair[] { new ConditionEffectPair(andCombinedCondition, effectOnUnit) };
    }
}