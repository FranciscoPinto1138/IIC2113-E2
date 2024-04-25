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
        int difference = Convert.ToInt32(Math.Floor(unit.Def * 1.5) - unit.Atk);
        if (difference > 0)
        {
            var effectOnUnit = new IncreaseStatOnFollowUp(difference, StatType.Atk);
            effectOnUnit.ApplyEffect(unit, opponent);
        }
        else if (difference < 0)
        {
            var effectOnUnit = new DecreaseStatOnFollowUp(Math.Abs(difference), StatType.Atk);
            effectOnUnit.ApplyEffect(unit, opponent);
        }
    }
}