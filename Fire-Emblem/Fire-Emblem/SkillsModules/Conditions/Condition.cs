namespace Fire_Emblem;

public abstract class Condition
{
    public abstract bool IsConditionFulfilled(Unit unit, Unit opponent);
}