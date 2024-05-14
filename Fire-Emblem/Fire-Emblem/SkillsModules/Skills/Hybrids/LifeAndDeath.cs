using System.Runtime.InteropServices.ComTypes;

namespace Fire_Emblem.SkillsModules.Skills.Hybrids;

public class LifeAndDeath : Hybrid
{
    public LifeAndDeath()
    {
        this.Name = "Life and Death";
        this.Description = "Otorga Atk/Spd+6. Inflige Def/Res-5.";
    }
    
    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        var condition = new NoCondition();
        var effectOnUnit = new DecreaseStats([StatType.Def, StatType.Res], [5, 5]);
        var effectOnUnitAdditional = new IncreaseStats([StatType.Atk, StatType.Spd], [6, 6]);
        return new ConditionEffectPair[] { new ConditionEffectPair(condition, effectOnUnit),
            new ConditionEffectPair(condition, effectOnUnitAdditional)};
    }
}