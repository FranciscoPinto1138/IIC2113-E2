namespace Fire_Emblem;

public class BeliefInLove : Penalty
{
    public BeliefInLove()
    {
        this.Name = "Belief in Love";
        this.Description = "Si el rival inicia el combate o tiene HP=100% al inicio del combate, " +
                           "inflige Atk/Def-5 en el rival durante el combate.";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { new ConditionEffectPair(
                new OrPairCondition(
                    new OpponentHPCondition(100, ThresholdType.Percentage, ComparisonType.Equal),
                    new OpponentStartsCombatCondition()), 
                new DecreaseOpponentStats([StatType.Atk, StatType.Def], [5, 5])) };
    }
}