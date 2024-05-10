using System.Runtime.InteropServices.ComTypes;

namespace Fire_Emblem.SkillsModules.Skills.Hybrids;

public class LifeAndDeath : Hybrid
{
    public LifeAndDeath()
    {
        this.Name = "Life and Death";
        this.Description = "Otorga Atk/Spd+6. Inflige Def/Res-5.";
    }
    
    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var firstCondition = new NoCondition();
        var effectOnUnit = new DecreaseStat(5, StatType.Def);
        var effectOnUnitAdditional = new IncreaseStat(6, StatType.Atk);
        var effectOnUnitAdditional2 = new IncreaseStat(6, StatType.Spd);
        var effectOnUnitAdditional3 = new DecreaseStat(5, StatType.Res);
        if (firstCondition.IsConditionFulfilled(unit, opponent))
        {
            effectOnUnit.ApplyEffect(unit, opponent);
            effectOnUnitAdditional.ApplyEffect(unit, opponent);
            effectOnUnitAdditional2.ApplyEffect(unit, opponent);
            effectOnUnitAdditional3.ApplyEffect(unit, opponent);
        }
    }
}