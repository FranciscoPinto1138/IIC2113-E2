namespace Fire_Emblem;

public class AgneasArrow : PenaltyNeutralizer
{
    public AgneasArrow(Unit unit, Unit opponent) : base(unit, opponent)
    {
        this.Name = "Agnea's Arrow";
        this.Description = "Neutraliza los penaltis de la unidad.";
        this.unit = unit;
        this.opponent = opponent;
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
}