namespace Fire_Emblem.SkillsModules.Skills.Hybrids;

public class Sandstorm : Hybrid
{
    public Sandstorm(Unit unit, Unit opponent) : base(unit, opponent)
    {
        this.Name = "Sandstorm";
        this.Description = "Calcula el daño del Follow-Up utilizando el 150% de la Def base de la unidad en vez del Atk. (Considere esto un Bonus o un Penalty de Atk).";
        this.unit = unit;
        this.opponent = opponent;
    }
    
    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        if (unit.Def * 1.5 > unit.Atk)
        {
            var effectOnUnit = new IncreaseStatOnFollowUp(Convert.ToInt32(Math.Floor(unit.Def * 1.5) - unit.Atk), StatType.Atk);
            effectOnUnit.ApplyEffect(unit, opponent);
        }
        else
        {
            var effectOnUnit = new DecreaseStatOnFollowUp(Convert.ToInt32(unit.Atk - Math.Floor(unit.Def * 1.5)), StatType.Atk);
            effectOnUnit.ApplyEffect(unit, opponent);
        }
    }
}