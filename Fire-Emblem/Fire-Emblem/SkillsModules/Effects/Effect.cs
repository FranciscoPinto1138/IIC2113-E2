namespace Fire_Emblem;

public interface Effect
{
    void ApplyEffect(Unit unit, Unit opponent, Stats unitCombatStats, Stats opponentCombatStats);
}