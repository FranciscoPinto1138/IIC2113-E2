namespace Fire_Emblem;

public class UnitHasHigherAtkThanOpponentsResCondition : Condition
{
    public UnitHasHigherAtkThanOpponentsResCondition()
    {
        this.SetPriority(2);
    }
    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        UnitStatsManager unitStatsManager = new UnitStatsManager();
        return unitStatsManager.GetUnitNonSpecificTotalAtk(unit) >
               unitStatsManager.GetUnitNonSpecificTotalRes(opponent);
    }
}