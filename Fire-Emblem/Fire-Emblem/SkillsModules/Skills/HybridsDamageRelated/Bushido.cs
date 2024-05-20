namespace Fire_Emblem;

public class Bushido : Skill
{
    public Bushido()
    {
        this.Name = "Bushido";
        this.Description = "Inflige +7 de daño por ataque. Si el Spd de la unidad > Spd del rival, " +
                           "reduce el daño de los ataques del rival durante el combate por un " +
                           "porcentaje = diferencia entre stats x 4 (máx. 40%).";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { 
            new ConditionEffectPair(new NoCondition(), 
                new IncreaseExtraDamage(7)),
            new ConditionEffectPair(new UnitHasHigherStatThanOpponentCondition(StatType.Spd), 
                new ReduceReceivedPermanentDamageByPercentageFourTimesStatDiff(StatType.Spd)) 
        };
    }
}