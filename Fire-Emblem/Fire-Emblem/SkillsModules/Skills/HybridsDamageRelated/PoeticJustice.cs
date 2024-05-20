namespace Fire_Emblem;

public class PoeticJustice : Skill
{
    public PoeticJustice()
    {
        this.Name = "Poetic Justice";
        this.Description = "Inflige Spd-4 en el rival durante el combate y la unidad inflige " +
                           "daño extra = 15% del ataque del rival.";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { 
            new ConditionEffectPair(new NoCondition(), 
                new DecreaseOpponentStats([StatType.Spd], [4])),
            new ConditionEffectPair(new NoCondition(), 
                new IncreaseExtraDamageByOpponentFifteenPercentTotalAtkStat()) 
        };
    }
}