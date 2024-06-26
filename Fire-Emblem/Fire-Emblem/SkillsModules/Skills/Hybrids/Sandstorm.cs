namespace Fire_Emblem.SkillsModules.Skills.Hybrids;

public class Sandstorm : Skill
{
    public Sandstorm()
    {
        this.Name = "Sandstorm";
        this.Description = "Calcula el daño del Follow-Up utilizando el 150% de la Def base de la " +
                           "unidad en vez del Atk. (Considere esto un Bonus o un Penalty de Atk).";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        int difference = Convert.ToInt32(Math.Floor(unit.Def * 1.5) - unit.Atk);
        if (difference > 0)
        {
            return new ConditionEffectPair[]
            {
                new ConditionEffectPair(new NoCondition(), new IncreaseStatOnFollowUp(difference, StatType.Atk))
            };
        }
        else
        {
            return new ConditionEffectPair[]
            {
                new ConditionEffectPair(new NoCondition(), 
                    new DecreaseStatOnFollowUp(Math.Abs(difference), StatType.Atk))
            };
        }
    }
}