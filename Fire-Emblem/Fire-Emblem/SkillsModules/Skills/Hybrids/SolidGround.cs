namespace Fire_Emblem.SkillsModules.Skills.Hybrids;

public class SolidGround : Hybrid
{
    public SolidGround()
    {
        this.Name = "Solid Ground";
        this.Description = "Otorga Atk/Def+6. Inflige Res-5.";
    }
    
    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var firstCondition = new NoCondition();
        var effectOnUnit = new DecreaseStat(5, StatType.Res);
        var effectOnUnitAdditional = new IncreaseStat(6, StatType.Atk);
        var effectOnUnitAdditional2 = new IncreaseStat(6, StatType.Def);
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
        var effectOnUnit = new IncreaseStats([StatType.Atk, StatType.Def], [6, 6]);
        var effectOnUnitAdditional = new DecreaseStats([StatType.Res], [5]);
        return new ConditionEffectPair[] { new ConditionEffectPair(condition, effectOnUnit),
            new ConditionEffectPair(condition, effectOnUnitAdditional) };
    }
}