namespace Fire_Emblem;

public class HPBaseStatPlus15 : Effect
{
    private int _changeFactor;
    
    public HPBaseStatPlus15(int changeFactor)
    {
        _changeFactor = changeFactor;
    }
    
    public void ApplyEffect(Unit unit, Unit opponent, Stats unitCombatStats, Stats opponentCombatStats)
    {
        unitCombatStats.HPMax += _changeFactor;
        unitCombatStats.HPCurrent += _changeFactor;
    }
}