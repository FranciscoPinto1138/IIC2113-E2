namespace Fire_Emblem.SkillsModules.Skills.Hybrids;

public class StillWater : Hybrid
{
    public StillWater()
    {
        this.Name = "Still Water";
        this.Description = "Otorga Atk/Res+6. Inflige Def-5.";
    }
    
    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var firstCondition = new NoCondition();
        var effectOnUnit = new DecreaseStat(5, StatType.Def);
        var effectOnUnitAdditional = new IncreaseStat(6, StatType.Atk);
        var effectOnUnitAdditional2 = new IncreaseStat(6, StatType.Res);
        if (firstCondition.IsConditionFulfilled(opponent, unit))
        {
            effectOnUnit.ApplyEffect(unit, opponent);
            effectOnUnitAdditional.ApplyEffect(unit, opponent);
            effectOnUnitAdditional2.ApplyEffect(unit, opponent);
        }
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