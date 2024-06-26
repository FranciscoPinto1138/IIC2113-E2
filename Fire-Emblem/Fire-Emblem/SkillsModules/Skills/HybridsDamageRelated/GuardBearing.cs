namespace Fire_Emblem;

public class GuardBearing : Skill
{
    public GuardBearing()
    {
        this.Name = "Guard Bearing";
        this.Description = "Inflige Spd/Def-4 en el rival. Reduce el daño de los ataques del rival en X% " +
                           "(Durante el primer combate de la unidad en que inicia el combate y durante el " +
                           "primer ataque de la unidad en que el rival inicia el combate, X = 60; " +
                           "en otro caso, X = 30).";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        Condition orCondition = new OrPairCondition(
            new AndPairCondition(
                new UnitIsInFirstTimeStartingCombatCondition(),
                new UnitStartsCombatCondition()),
            new AndPairCondition(
                new UnitIsInFirstTimeNotStartingCombatCondition(),
                new OpponentStartsCombatCondition()));
        
        return new ConditionEffectPair[] { 
            new ConditionEffectPair(
                new NoCondition(),
                new DecreaseOpponentStats([StatType.Spd, StatType.Def], [4, 4])),
            new ConditionEffectPair(orCondition, 
                new ReduceReceivedPermanentDamageByPercentage(0.6)),
            new ConditionEffectPair(new NotCondition(orCondition), 
                new ReduceReceivedPermanentDamageByPercentage(0.3)),
        };
    }
}