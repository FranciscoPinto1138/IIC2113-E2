namespace Fire_Emblem;

public class Ignis : Bonus
{
    public Ignis(Unit unit, Unit opponent) : base(unit, opponent)
    {
        this.Name = "Ignis";
        this.Description = "Otorga Atk+50% al primer ataque de la unidad. (Considere esto como un Bonus de Atk y el Atk como la base).";
        this.unit = unit;
        this.opponent = opponent;
    }

    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var condition = new NoCondition();
        var effectOnUnit = new IncreaseStatByPercentageOnFirstAttack(50, StatType.Atk);
        if (condition.IsConditionFulfilled(unit, opponent))
        {
            effectOnUnit.ApplyEffect(unit, opponent);
        }
    }
}