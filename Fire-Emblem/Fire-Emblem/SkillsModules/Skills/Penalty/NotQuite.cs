namespace Fire_Emblem;

public class NotQuite : Penalty
{
    public NotQuite()
    {
        this.Name = "Not *Quite*";
        this.Description = "Si el rival inicia el combate, inflige Atk-4 en ese rival durante el combate";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        var condition = new OpponentStartsCombatCondition();
        var effectOnOpponent = new DecreaseOpponentStats([StatType.Atk], [4]);
        return new ConditionEffectPair[] { new ConditionEffectPair(condition, effectOnOpponent) };
    }
}