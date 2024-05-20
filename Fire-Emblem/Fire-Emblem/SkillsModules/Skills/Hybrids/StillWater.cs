namespace Fire_Emblem.SkillsModules.Skills.Hybrids;

public class StillWater : Hybrid
{
    public StillWater()
    {
        this.Name = "Still Water";
        this.Description = "Otorga Atk/Res+6. Inflige Def-5.";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { 
            new ConditionEffectPair(new NoCondition(), new IncreaseStats([StatType.Atk, StatType.Res], [6, 6])),
            new ConditionEffectPair(new NoCondition(), new DecreaseStats([StatType.Def], [5])) 
        };
    }
}