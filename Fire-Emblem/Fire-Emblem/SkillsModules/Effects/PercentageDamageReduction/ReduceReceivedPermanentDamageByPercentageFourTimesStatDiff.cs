namespace Fire_Emblem;

public class ReduceReceivedPermanentDamageByPercentageFourTimesStatDiff : PercentageDamageReductionEffect
{
    private StatType _statType;
    public ReduceReceivedPermanentDamageByPercentageFourTimesStatDiff(StatType statType)
    {
        this._statType = statType;
        this.SetPriority(3);
    }

    public override void ApplyEffect(Unit unit, Unit opponent)
    {
        UnitStatsManager unitStatsManager = new UnitStatsManager();
        double changeFactor = 0;
        const double MAX_PERCENTAGE_DAMAGE_REDUCTION_BY_STAT_DIFF = 0.4;
        switch (_statType)
        {
            case StatType.Atk:
                changeFactor =
                    Math.Min(
                        ((unitStatsManager.GetUnitNonSpecificTotalAtk(unit) -
                          unitStatsManager.GetUnitNonSpecificTotalAtk(opponent)) * 4) /
                        100.0, MAX_PERCENTAGE_DAMAGE_REDUCTION_BY_STAT_DIFF);
                break;
            case StatType.Def:
                changeFactor = 
                    Math.Min(
                        ((unitStatsManager.GetUnitNonSpecificTotalDef(unit) -
                          unitStatsManager.GetUnitNonSpecificTotalDef(opponent)) * 4) /
                        100.0, MAX_PERCENTAGE_DAMAGE_REDUCTION_BY_STAT_DIFF);
                break;
            case StatType.Res:
                changeFactor = 
                    Math.Min(
                        ((unitStatsManager.GetUnitNonSpecificTotalRes(unit) -
                          unitStatsManager.GetUnitNonSpecificTotalRes(opponent)) * 4) /
                        100.0, MAX_PERCENTAGE_DAMAGE_REDUCTION_BY_STAT_DIFF);
                break;
            case StatType.Spd:
                changeFactor = 
                    Math.Min(
                        ((unitStatsManager.GetUnitNonSpecificTotalSpd(unit) -
                          unitStatsManager.GetUnitNonSpecificTotalSpd(opponent)) * 4) /
                        100.0, MAX_PERCENTAGE_DAMAGE_REDUCTION_BY_STAT_DIFF);
                break;
        }
        unit.DamageEffectsManager.DamagePercentageReductionPermanent =
            1 - ((1 - unit.DamageEffectsManager.DamagePercentageReductionPermanent) * (1 - changeFactor));
    }
}