namespace Fire_Emblem;

public class WillToWin : Bonus
{
    public WillToWin()
    {
        this.Name = "Will to Win";
        this.Description = "Si el HP de la unidad está al 50% o menos al inicio del combate, otorga Atk+8 a la unidad durante el combate.";
    }

    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var condition = new UnitHPCondition(50, ThresholdType.Percentage, ComparisonType.LowerThanOrEqual);
        var effectOnUnit = new IncreaseStat(8, StatType.Atk);
        if (condition.IsConditionFulfilled(unit, opponent))
        {
            effectOnUnit.ApplyEffect(unit, opponent);
        }
    }
}