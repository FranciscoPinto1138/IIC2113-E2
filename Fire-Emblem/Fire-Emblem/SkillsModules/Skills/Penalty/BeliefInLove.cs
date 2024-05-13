namespace Fire_Emblem;

public class BeliefInLove : Penalty
{
    public BeliefInLove()
    {
        this.Name = "Belief in Love";
        this.Description = "Si el rival inicia el combate o tiene HP=100% al inicio del combate, inflige Atk/Def-5 en el rival durante el combate.";
    }

    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var condition = new UnitStartsCombatCondition();
        var conditionAdditional = new UnitHPCondition(100, ThresholdType.Percentage, ComparisonType.Equal);
        var effectOnOpponent = new DecreaseStat(5, StatType.Atk);
        var effectOnOpponentAdditional = new DecreaseStat(5, StatType.Def);
        if (condition.IsConditionFulfilled(opponent, unit) || conditionAdditional.IsConditionFulfilled(opponent, unit))
        {
            effectOnOpponent.ApplyEffect(opponent, unit);
            effectOnOpponentAdditional.ApplyEffect(opponent, unit);
        }
    }
    
    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        var condition = new OpponentStartsCombatCondition();
        var conditionAdditional = new OpponentHPCondition(100, ThresholdType.Percentage, ComparisonType.Equal);
        var combinedOrCondition = new OrPairCondition(condition, conditionAdditional);
        var effectOnOpponent = new DecreaseOpponentStats([StatType.Atk, StatType.Def], [5, 5]);
        return new ConditionEffectPair[] { new ConditionEffectPair(combinedOrCondition, effectOnOpponent) };
    }
}