namespace Fire_Emblem;

public abstract class BonusEffect : Effect
{
    public abstract void ApplyEffect(Unit unit, Unit opponent);
}