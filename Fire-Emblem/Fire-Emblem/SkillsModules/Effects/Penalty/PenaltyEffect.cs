namespace Fire_Emblem;

public abstract class PenaltyEffect : Effect
{
    protected PenaltyEffect()
    {
        SetPriority(1);
    }
    public override void ApplyEffect(Unit unit, Unit opponent)
    {
    }
}