namespace Fire_Emblem;

public class HPPlus15 : Skill
{
    
    public HPPlus15()
    {
        this.Name = "HP +15";
        this.Description = "Otorga max HP+15";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { new ConditionEffectPair(
            new UnitIsInFirstCombatCondition(), new IncreaseHPBaseStat(15)) };
    }
}