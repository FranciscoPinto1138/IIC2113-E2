namespace Fire_Emblem;

public class WillToWin : Skill
{
    public WillToWin()
    {
        this.Name = "Will to Win";
        this.Description = "Si el HP de la unidad está al 50% o menos al inicio del combate, " +
                           "otorga Atk+8 a la unidad durante el combate.";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { new ConditionEffectPair(
            new UnitHPCondition(50, ThresholdType.Percentage, ComparisonType.LowerThanOrEqual), 
            new IncreaseStat(8, StatType.Atk)) 
        };
    }
}