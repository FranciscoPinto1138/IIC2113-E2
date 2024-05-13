namespace Fire_Emblem;

public class DragonWall : PercentageDamageReduction
{
    public DragonWall()
    {
        this.Name = "Dragon Wall";
        this.Description =
            "Si Res de la unidad > Res del rival, reduce el daño de cada ataque del rival por un porcentaje=diferencia entre los stats x 4 (máx. 40%)";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        var condition = new UnitHasHigherStatThanOpponentCondition(StatType.Res);
        var effectOnUnit = new ReduceReceivedPermanentDamageByPercentageFourTimesStatDiff(StatType.Res);
        return new ConditionEffectPair[] { new ConditionEffectPair(condition, effectOnUnit) };
    }
}