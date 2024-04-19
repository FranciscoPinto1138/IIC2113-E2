namespace Fire_Emblem;

public class BeorcsBlessing : BonusNeutralizer
{
    public BeorcsBlessing(Unit unit, Unit opponent) : base(unit, opponent)
    {
        this.Name = "Beorc's Blessing";
        this.Description = "Neutraliza los bonus del rival durante el combate.";
        this.unit = unit;
        this.opponent = opponent;
    }

    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var condition = new NoCondition();
        var effectOnOpponent = new NeutralizeBonusOnStats([StatType.Atk, StatType.Spd, StatType.Def, StatType.Res, StatType.HP]);
        if (condition.IsConditionFulfilled(unit, opponent))
        {
            effectOnOpponent.ApplyEffect(opponent, unit);
        }
    }
}