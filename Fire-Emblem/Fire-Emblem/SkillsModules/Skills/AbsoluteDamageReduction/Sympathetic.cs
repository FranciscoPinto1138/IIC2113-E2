namespace Fire_Emblem;

public class Sympathetic : AbsoluteDamageReduction
{
    public Sympathetic()
    {
        this.Name = "Sympathetic";
        this.Description = "Si el rival inicia el combate y el HP de la unidad está al 50% o menos al inicio " +
                           "del combate, la unidad recibe -5 daño en cada ataque del rival.";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { new ConditionEffectPair(
            new AndPairCondition(
                new OpponentStartsCombatCondition(), 
                new UnitHPCondition(50, ThresholdType.Percentage, ComparisonType.LowerThanOrEqual)),  
            new ReduceReceivedDamageByAbsoluteValue(5))
        };
    }
}