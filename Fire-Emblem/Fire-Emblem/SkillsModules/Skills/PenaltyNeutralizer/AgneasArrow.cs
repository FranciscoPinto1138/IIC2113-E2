namespace Fire_Emblem;

public class AgneasArrow : PenaltyNeutralizer
{
    public AgneasArrow()
    {
        this.Name = "Agnea's Arrow";
        this.Description = "Neutraliza los penaltis de la unidad.";
    }

    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var condition = new NoCondition();
        var effectOnOpponent = new NeutralizePenaltyOnStats([StatType.Atk, StatType.Spd, StatType.Def, StatType.Res, StatType.HP]);
        if (condition.IsConditionFulfilled(unit, opponent))
        {
            effectOnOpponent.ApplyEffect(unit, opponent);
        }
    }
    
    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        var condition = new NoCondition();
        var effectOnUnit = new NeutralizePenaltyOnStats([StatType.Atk, StatType.Spd, StatType.Def, StatType.Res, StatType.HP]);
        return new ConditionEffectPair[] { new ConditionEffectPair(condition, effectOnUnit) };
    }
}