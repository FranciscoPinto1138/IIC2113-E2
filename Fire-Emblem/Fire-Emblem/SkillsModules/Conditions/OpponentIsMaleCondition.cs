namespace Fire_Emblem;

public class OpponentIsMaleCondition : Condition
{
    public OpponentIsMaleCondition()
    {
        SetPriority(1);
    }
    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        const string MALE_GENDER = "Male";
        return opponent.Gender == MALE_GENDER;
    }
}