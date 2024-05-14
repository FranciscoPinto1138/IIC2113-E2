namespace Fire_Emblem;

public class HPPlus15 : Bonus
{
    
    public HPPlus15()
    {
        this.Name = "HP +15";
        this.Description = "Otorga max HP+15";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        var condition = new UnitIsInFirstCombatCondition();
        var effect = new IncreaseHPBaseStat(15);
        return new ConditionEffectPair[] { new ConditionEffectPair(condition, effect) };
    }
}