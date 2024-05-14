namespace Fire_Emblem;

public class OpponentIsMaleCondition : Condition
{
    public OpponentIsMaleCondition()
    {
        SetPriority(1);
    }
    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        return opponent.Gender == "Male";
    }
}