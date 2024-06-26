namespace Fire_Emblem;

public class Ignis : Skill
{
    public Ignis()
    {
        this.Name = "Ignis";
        this.Description = "Otorga Atk+50% al primer ataque de la unidad. " +
                           "(Considere esto como un Bonus de Atk y el Atk como la base).";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { new ConditionEffectPair(
            new NoCondition(), new IncreaseStatByPercentageOnFirstAttack(50, StatType.Atk)) };
    }
}