namespace Fire_Emblem;

public class Resolve : Bonus
{
    public Resolve(Unit unit, Unit opponent) : base(unit, opponent)
    {
        this.Name = "Resolve";
        this.Description = "Si el HP de la unidad está al 75% o menos al inicio del combate, otorga Def/Res+7";
        this.unit = unit;
        this.opponent = opponent;
    }

    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var condition = new UnitHPCondition(75, ThresholdType.Percentage, ComparisonType.LowerThanOrEqual);
        var effectOnUnit = new StatBuffer(((Skill)this).unit, ((Skill)this).opponent, [StatType.Def, StatType.Res], [7,7]);
        if (condition.IsConditionFulfilled(unit, opponent))
        {
            effectOnUnit.ApplyEffectsIfConditionsAreSatisfied(unit, opponent);
        }
    }
}