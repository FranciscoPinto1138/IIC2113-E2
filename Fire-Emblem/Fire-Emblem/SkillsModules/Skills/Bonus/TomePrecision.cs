namespace Fire_Emblem;

public class TomePrecision : Bonus
{
    public TomePrecision()
    {
        this.Name = "Tome Precision";
        this.Description = "Otorga Atk/Spd+6 al usar magia.";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        var condition = new UnitHasWeaponTypeCondition("Magic");
        var effectOnUnit = new IncreaseStats([StatType.Atk, StatType.Spd], [6, 6]);
        return new ConditionEffectPair[] { new ConditionEffectPair(condition, effectOnUnit) };
    }
}