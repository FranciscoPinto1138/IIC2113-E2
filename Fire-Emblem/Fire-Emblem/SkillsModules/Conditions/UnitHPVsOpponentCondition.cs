namespace Fire_Emblem;

public class UnitHPVsOpponentCondition : Condition
{
    private int _expectedHpDifference;
    public UnitHPVsOpponentCondition(int expectedHPDifference)
    {
        this._expectedHpDifference = expectedHPDifference;
        this.SetPriority(1);
    }
    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        return unit.HPCurrent >= opponent.HPCurrent + _expectedHpDifference;
    }
}