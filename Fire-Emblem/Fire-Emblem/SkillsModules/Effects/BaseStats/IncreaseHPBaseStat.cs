namespace Fire_Emblem;

public class IncreaseHPBaseStat : Effect
{
    private int _changeFactor;
    
    public IncreaseHPBaseStat(int changeFactor)
    {
        _changeFactor = changeFactor;
    }
    
    public void ApplyEffect(Unit unit, Unit opponent)
    {
        unit.HPMax += _changeFactor;
        unit.HPCurrent += _changeFactor;
    }
}