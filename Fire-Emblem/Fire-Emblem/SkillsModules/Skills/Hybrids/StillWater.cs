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
        var condition = new NoCondition();
        var effectOnUnit = new IncreaseStats([StatType.Atk, StatType.Res], [6, 6]);
        var effectOnUnitAdditional = new DecreaseStats([StatType.Def], [5]);
        return new ConditionEffectPair[] { new ConditionEffectPair(condition, effectOnUnit),
            new ConditionEffectPair(condition, effectOnUnitAdditional) };
    }
}