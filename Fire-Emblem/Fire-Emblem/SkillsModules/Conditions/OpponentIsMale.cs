namespace Fire_Emblem;

public class OpponentIsMale : Condition
{
    public OpponentIsMale()
    {
        SetPriority(1);
    }
    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        return opponent.Gender == "Male";
    }
}