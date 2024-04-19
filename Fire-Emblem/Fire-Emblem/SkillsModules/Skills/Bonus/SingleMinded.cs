namespace Fire_Emblem;

public class SingleMinded : Bonus
{
    public SingleMinded(Unit unit, Unit opponent) : base(unit, opponent)
    {
        this.Name = "Single-Minded";
        this.Description = "En un combate contra un rival que también es el oponente más reciente de la unidad, otorga Atk+8 a la unidad durante el combate.";
        this.unit = unit;
        this.opponent = opponent;
    }

    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var condition = new OpponentIsMostRecentRivalOfUnitCondition();
        var effectOnUnit = new IncreaseStat(8, StatType.Atk);
        if (condition.IsConditionFulfilled(unit, opponent))
        {
            effectOnUnit.ApplyEffect(unit, opponent);
        }
    }
}