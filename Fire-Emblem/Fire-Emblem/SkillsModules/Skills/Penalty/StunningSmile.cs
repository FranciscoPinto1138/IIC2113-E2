namespace Fire_Emblem;

public class StunningSmile : Penalty
{
    public StunningSmile()
    {
        this.Name = "Stunning Smile";
        this.Description = "Si el rival es hombre, inflige Spd-8 en ese rival durante el combate.";
    }

    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var condition = new OpponentIsMaleCondition();
        var effectOnUnit = new DecreaseStat(8, StatType.Spd);
        if (condition.IsConditionFulfilled(unit, opponent))
        {
            effectOnUnit.ApplyEffect(opponent, unit);
        }
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        var condition = new OpponentIsMaleCondition();
        var effectOnOpponent = new DecreaseOpponentStats([StatType.Spd], [8]);
        return new ConditionEffectPair[] { new ConditionEffectPair(condition, effectOnOpponent) };
    }
}