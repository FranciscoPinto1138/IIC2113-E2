namespace Fire_Emblem;

public class WillToWin : Bonus
{
    public WillToWin(Unit unit, Unit opponent, string firstPlayerOfRoundName, string secondPlayerOfRoundName, Stats unitCombatStats, Stats opponentCombatStats) : base(unit, opponent, firstPlayerOfRoundName, secondPlayerOfRoundName, unitCombatStats, opponentCombatStats)
    {
        this.Name = "Will to Win";
        this.Description = "Si la unidad inicia el combate, otorga Atk+6 a la unidad y al rival durante el combate.";
        this.unit = unit;
        this.opponent = opponent;
        this.firstPlayerOfRoundName = firstPlayerOfRoundName;
        this.secondPlayerOfRoundName = secondPlayerOfRoundName;
    }

    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent, Stats unitCombatStats, Stats opponentCombatStats)
    {
        var condition = new UnitHPCondition(50, ThresholdType.Absolute, ComparisonType.LowerThanOrEqual);
        var effectOnUnit = new IncreaseAtk(8);
        if (condition.IsConditionFulfilled(unit, opponent, firstPlayerOfRoundName, secondPlayerOfRoundName, unitCombatStats, opponentCombatStats))
        {
            effectOnUnit.ApplyEffect(unit, opponent, unitCombatStats, opponentCombatStats);
        }
    }
}