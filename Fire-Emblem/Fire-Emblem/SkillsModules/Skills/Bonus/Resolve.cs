namespace Fire_Emblem;

public class Resolve : Skill
{
    public Resolve()
    {
        this.Name = "Resolve";
        this.Description = "Si el HP de la unidad está al 75% o menos al inicio del combate, otorga Def/Res+7";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { new ConditionEffectPair(
            new UnitHPCondition(75, ThresholdType.Percentage, ComparisonType.LowerThanOrEqual), 
            new IncreaseStats([StatType.Def, StatType.Res], [7,7])) 
        };
    }
}