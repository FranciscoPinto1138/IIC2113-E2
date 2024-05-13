namespace Fire_Emblem;

public class FairFight : Bonus
{
    public FairFight()
    {
        this.Name = "Fair Fight";
        this.Description = "Si la unidad inicia el combate, otorga Atk+6 a la unidad y al rival durante el combate.";
        //var conditions = new List<Condition> { new UnitStartsCombatCondition() };
        //var effects = new List<Effect> { new IncreaseAtk(6) };
    }

    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var condition = new UnitStartsCombatCondition();
        var effectOnUnit = new IncreaseStat(6, StatType.Atk);
        var effectOnOpponent = new IncreaseStat(6, StatType.Atk);
        if (condition.IsConditionFulfilled(unit, opponent))
        {
            effectOnUnit.ApplyEffect(unit, opponent);
            effectOnOpponent.ApplyEffect(opponent, unit);
        }
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        var condition = new UnitStartsCombatCondition();
        var effectOnUnit = new IncreaseStats([StatType.Atk], [6]);
        var effectOnOpponent = new IncreaseOpponentStats([StatType.Atk], [6]);
        return new ConditionEffectPair[] { new ConditionEffectPair(condition, effectOnUnit), 
            new ConditionEffectPair(condition, effectOnOpponent)};
    }
}