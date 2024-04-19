namespace Fire_Emblem;

public class FairFight : Bonus
{
    public FairFight(Unit unit, Unit opponent, string firstPlayerOfRoundName, string secondPlayerOfRoundName, Stats unitCombatStats, Stats opponentCombatStats) : base(unit, opponent, firstPlayerOfRoundName, secondPlayerOfRoundName, unitCombatStats, opponentCombatStats)
    {
        this.Name = "Fair Fight";
        this.Description = "Si la unidad inicia el combate, otorga Atk+6 a la unidad y al rival durante el combate.";
        this.unit = unit;
        this.opponent = opponent;
        this.firstPlayerOfRoundName = firstPlayerOfRoundName;
        this.secondPlayerOfRoundName = secondPlayerOfRoundName;
        //var conditions = new List<Condition> { new UnitStartsCombatCondition() };
        //var effects = new List<Effect> { new IncreaseAtk(6) };
    }

    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent, Stats unitCombatStats, Stats opponentCombatStats)
    {
        var condition = new UnitStartsCombatCondition();
        var effectOnUnit = new IncreaseAtk(6);
        var effectOnOpponent = new IncreaseAtk(6);
        if (condition.IsConditionFulfilled(unit, opponent, firstPlayerOfRoundName, secondPlayerOfRoundName, unitCombatStats, opponentCombatStats))
        {
            effectOnUnit.ApplyEffect(unit, opponent, unitCombatStats, opponentCombatStats);
            effectOnOpponent.ApplyEffect(opponent, unit, opponentCombatStats, unitCombatStats);
        }
    }
}