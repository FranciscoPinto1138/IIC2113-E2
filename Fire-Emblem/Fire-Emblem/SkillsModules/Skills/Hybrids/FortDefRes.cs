namespace Fire_Emblem.SkillsModules.Skills.Hybrids;

public class FortDefRes : Hybrid
{
    public FortDefRes(Unit unit, Unit opponent) : base(unit, opponent)
    {
        this.Name = "Fort. Def/Res";
        this.Description = "Otorga Def/Res+6. Inflige Atk-2.";
        this.unit = unit;
        this.opponent = opponent;
    }
    
    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var firstCondition = new NoCondition();
        var effectOnUnit = new DecreaseStat(2, StatType.Atk);
        var effectOnUnitAdditional = new IncreaseStat(6, StatType.Def);
        var effectOnUnitAdditional2 = new IncreaseStat(6, StatType.Res);
        if (firstCondition.IsConditionFulfilled(opponent, unit))
        {
            effectOnUnit.ApplyEffect(unit, opponent);
            effectOnUnitAdditional.ApplyEffect(unit, opponent);
            effectOnUnitAdditional2.ApplyEffect(unit, opponent);
        }
    }
}