namespace Fire_Emblem.SkillsModules.Skills.Hybrids;

public class SolidGround : Skill
{
    public SolidGround()
    {
        this.Name = "Solid Ground";
        this.Description = "Otorga Atk/Def+6. Inflige Res-5.";
    }
    
    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { 
            new ConditionEffectPair(new NoCondition(), new IncreaseStats([StatType.Atk, StatType.Def], [6, 6])),
            new ConditionEffectPair(new NoCondition(), new DecreaseStats([StatType.Res], [5])) };
    }
}