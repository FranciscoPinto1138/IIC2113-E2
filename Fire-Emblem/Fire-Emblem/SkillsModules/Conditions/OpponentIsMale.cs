namespace Fire_Emblem;

public class OpponentIsMale : Condition
{
    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        return opponent.Gender == "Male";
    }
}