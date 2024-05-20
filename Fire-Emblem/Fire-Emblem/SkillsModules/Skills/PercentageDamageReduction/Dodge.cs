namespace Fire_Emblem;

public class Dodge : Skill
{
    public Dodge()
    {
        this.Name = "Dodge";
        this.Description =
            "Si Spd de la unidad > Spd del rival, reduce el daño de cada ataque del rival por " +
            "un porcentaje=diferencia entre los stats x 4 (máx. 40%)";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[]
        {
            new ConditionEffectPair(new UnitHasHigherStatThanOpponentCondition(StatType.Spd), 
                new ReduceReceivedPermanentDamageByPercentageFourTimesStatDiff(StatType.Spd))
        };
    }
}