namespace Fire_Emblem;

public abstract class BonusEffect : Effect
{
    protected BonusEffect()
    {
        SetPriority(1);
    }
    public override void ApplyEffect(Unit unit, Unit opponent)
    {
    }
}