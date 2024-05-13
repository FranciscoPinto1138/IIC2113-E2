namespace Fire_Emblem;

public class Bushido : Hybrid
{
    public Bushido()
    {
        this.Name = "Bushido";
        this.Description = "Inflige +7 de daño por ataque. Si el Spd de la unidad > Spd del rival, reduce el daño de los ataques del rival durante el combate por un porcentaje = diferencia entre stats x 4 (máx. 40%).";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        var firstCondition = new NoCondition();
        var secondCondition = new UnitHasHigherStatThanOpponentCondition(StatType.Spd);
        var firstEffectOnUnit = new IncreaseExtraDamage(7);
        var secondEffectOnUnit = new ReduceReceivedPermanentDamageByPercentageFourTimesStatDiff(StatType.Spd);
        return new ConditionEffectPair[] { new ConditionEffectPair(firstCondition, firstEffectOnUnit),
            new ConditionEffectPair(secondCondition, secondEffectOnUnit) };
    }
}