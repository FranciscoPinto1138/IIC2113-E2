namespace Fire_Emblem;

public class PoeticJustice : Hybrid
{
    public PoeticJustice()
    {
        this.Name = "Poetic Justice";
        this.Description = "Inflige Spd-4 en el rival durante el combate y la unidad inflige daño extra = 15% del ataque del rival.";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        var condition = new NoCondition();
        var firstEffectOnUnit = new DecreaseOpponentStats([StatType.Spd], [4]);
        var secondEffectOnUnit = new IncreaseExtraDamageByOpponentFifteenPercentTotalAtkStat();
        return new ConditionEffectPair[] { new ConditionEffectPair(condition, firstEffectOnUnit),
            new ConditionEffectPair(condition, secondEffectOnUnit) };
    }
}