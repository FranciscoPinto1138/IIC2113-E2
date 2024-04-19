namespace Fire_Emblem;

public class TomePrecision : Bonus
{
    public TomePrecision(Unit unit, Unit opponent) : base(unit, opponent)
    {
        this.Name = "Tome Precision";
        this.Description = "Otorga Atk/Spd+6 al usar magia.";
        this.unit = unit;
        this.opponent = opponent;
    }
    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var condition = new UnitHasWeaponTypeCondition("Magic");
        var effectOnUnit = new IncreaseStat(6, StatType.Atk);
        var effectOnUnitAdditional = new IncreaseStat(6, StatType.Spd);
        if (condition.IsConditionFulfilled(unit, opponent))
        {
            effectOnUnit.ApplyEffect(unit, opponent);
            effectOnUnitAdditional.ApplyEffect(unit, opponent);
        }
    }
}