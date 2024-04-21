namespace Fire_Emblem.SkillsModules.Skills.Hybrids;

public class SolidGround : Hybrid
{
    public SolidGround(Unit unit, Unit opponent) : base(unit, opponent)
    {
        this.Name = "Solid Ground";
        this.Description = "Otorga Atk/Def+6. Inflige Res-5.";
        this.unit = unit;
        this.opponent = opponent;
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
}