namespace Fire_Emblem;

public class OpponentIsMostRecentRivalOfUnitCondition : Condition
{
    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        return unit.MostRecentRival == opponent.Name;
    }
}