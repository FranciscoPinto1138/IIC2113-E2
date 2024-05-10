namespace Fire_Emblem;

public abstract class PenaltyEffect : Effect
{
    public abstract void ApplyEffect(Unit unit, Unit opponent);
}