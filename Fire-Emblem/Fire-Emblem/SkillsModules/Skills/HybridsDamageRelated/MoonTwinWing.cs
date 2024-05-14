namespace Fire_Emblem;

public class MoonTwinWing : Hybrid
{
    public MoonTwinWing()
    {
        this.Name = "Moon-Twin Wing";
        this.Description = "Al inicio del combate, si el HP de la unidad >= 25%, inflige Atk/Spd-5 en el rival durante el combate, y también, si la Spd de la unidad > Spd del rival, reduce el daño de los ataques del rival durante el combate en un porcentaje = diferencia entre los stats x 4 (máx. 40%).";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { 
            new ConditionEffectPair(
                new UnitHPCondition(25, ThresholdType.Percentage, ComparisonType.GreaterThanOrEqual), 
                new DecreaseOpponentStats([StatType.Atk, StatType.Spd], [5, 5])),
            new ConditionEffectPair(
                new UnitHasHigherStatThanOpponentCondition(StatType.Spd), 
                new ReduceReceivedPermanentDamageByPercentageFourTimesStatDiff(StatType.Spd))
        };
    }
}