namespace Fire_Emblem;

public class DragonWall : Skill
{
    public DragonWall()
    {
        this.Name = "Dragon Wall";
        this.Description =
            "Si Res de la unidad > Res del rival, reduce el daño de cada ataque del rival por " +
            "un porcentaje=diferencia entre los stats x 4 (máx. 40%)";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[]
        {
            new ConditionEffectPair(new UnitHasHigherStatThanOpponentCondition(StatType.Res),
                new ReduceReceivedPermanentDamageByPercentageFourTimesStatDiff(StatType.Res))
        };
    }
}