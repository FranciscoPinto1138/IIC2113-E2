namespace Fire_Emblem;

public class Chivalry : Hybrid
{
    public Chivalry()
    {
        this.Name = "Chivalry";
        this.Description = "Si la unidad inicia el combate contra un rival con HP=100%, la unidad inflige +2 daño en cada ataque y recibe -2 daño por cada ataque del rival.";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { 
            new ConditionEffectPair(
                new AndPairCondition(
                    new UnitStartsCombatCondition(),
                    new OpponentHPCondition(100, ThresholdType.Percentage, ComparisonType.Equal)), 
                new IncreaseExtraDamage(2)),
            new ConditionEffectPair(new AndPairCondition(
                    new UnitStartsCombatCondition(),
                    new OpponentHPCondition(100, ThresholdType.Percentage, ComparisonType.Equal)),
                new ReduceReceivedDamageByAbsoluteValue(2))
        };
    }
}