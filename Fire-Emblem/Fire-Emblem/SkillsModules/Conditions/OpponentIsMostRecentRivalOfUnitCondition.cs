namespace Fire_Emblem;

public class OpponentIsMostRecentRivalOfUnitCondition : Condition
{
    public OpponentIsMostRecentRivalOfUnitCondition()
    {
        SetPriority(1);
    }
    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        return unit.MostRecentRival == opponent.Name;
    }
}