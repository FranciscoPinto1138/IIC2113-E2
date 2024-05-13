namespace Fire_Emblem;

public class UnitHasHigherStatThanOpponentCondition : Condition
{
    private StatType _statType;

    public UnitHasHigherStatThanOpponentCondition(StatType statType)
    {
        this._statType = statType;
        this.SetPriority(2);
    }

    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        UnitStatsManager unitStatsManager = new UnitStatsManager();
        switch (_statType)
        {
            case StatType.Atk:
                return unitStatsManager.GetUnitNonSpecificTotalAtk(unit) >
                       unitStatsManager.GetUnitNonSpecificTotalAtk(opponent);
            case StatType.Def:
                return unitStatsManager.GetUnitNonSpecificTotalDef(unit) >
                       unitStatsManager.GetUnitNonSpecificTotalDef(opponent);
            case StatType.Res:
                return unitStatsManager.GetUnitNonSpecificTotalRes(unit) >
                       unitStatsManager.GetUnitNonSpecificTotalRes(opponent);
            case StatType.Spd:
                return unitStatsManager.GetUnitNonSpecificTotalSpd(unit) >
                       unitStatsManager.GetUnitNonSpecificTotalSpd(opponent);
            default:
                return false;
        }
    }
}