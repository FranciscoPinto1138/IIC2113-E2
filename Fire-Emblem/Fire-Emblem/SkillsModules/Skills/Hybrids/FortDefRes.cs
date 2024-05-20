namespace Fire_Emblem.SkillsModules.Skills.Hybrids;

public class FortDefRes : Skill
{
    public FortDefRes()
    {
        this.Name = "Fort. Def/Res";
        this.Description = "Otorga Def/Res+6. Inflige Atk-2.";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { 
            new ConditionEffectPair(new NoCondition(), 
                new DecreaseStat(2, StatType.Atk)),
            new ConditionEffectPair(new NoCondition(), 
                new IncreaseStats([StatType.Def, StatType.Res], [6, 6])) };
    }
}