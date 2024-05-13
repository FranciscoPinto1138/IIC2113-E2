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
        var firstCondition = new UnitHPCondition(25, ThresholdType.Percentage, ComparisonType.GreaterThanOrEqual);
        var secondCondition = new UnitHasHigherStatThanOpponentCondition(StatType.Spd);
        var firstEffectOnUnit = new DecreaseOpponentStats([StatType.Atk, StatType.Spd], [5, 5]);
        var secondEffectOnUnit = new ReduceReceivedPermanentDamageByPercentageFourTimesStatDiff(StatType.Spd);
        return new ConditionEffectPair[] { new ConditionEffectPair(firstCondition, firstEffectOnUnit),
            new ConditionEffectPair(secondCondition, secondEffectOnUnit) };
    }
}