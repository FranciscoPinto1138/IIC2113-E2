namespace Fire_Emblem.SkillsModules.Skills.Hybrids;

public class Sandstorm : Hybrid
{
    public Sandstorm()
    {
        this.Name = "Sandstorm";
        this.Description = "Calcula el daño del Follow-Up utilizando el 150% de la Def base de la unidad en vez del Atk. (Considere esto un Bonus o un Penalty de Atk).";
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
    
    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        var condition = new NoCondition();
        int difference = Convert.ToInt32(Math.Floor(unit.Def * 1.5) - unit.Atk);
        if (difference > 0)
        {
            var effectOnUnit = new IncreaseStatOnFollowUp(difference, StatType.Atk);
            return new ConditionEffectPair[] { new ConditionEffectPair(condition, effectOnUnit)};
        }
        else
        {
            var effectOnUnit = new DecreaseStatOnFollowUp(Math.Abs(difference), StatType.Atk);
            return new ConditionEffectPair[] { new ConditionEffectPair(condition, effectOnUnit)};
        }
    }
}