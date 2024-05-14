namespace Fire_Emblem;

public class Charmer : Penalty
{
    public Charmer()
    {
        this.Name = "Charmer";
        this.Description = "En un combate contra un rival que también es el oponente más reciente de la unidad, inflige Atk/Spd-3 en ese rival durante el combate.";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        var condition = new OpponentIsMostRecentRivalOfUnitCondition();
        var effectOnOpponent = new DecreaseOpponentStats([StatType.Spd, StatType.Atk], [3, 3]);
        return new ConditionEffectPair[] { new ConditionEffectPair(condition, effectOnOpponent) };
    }
}