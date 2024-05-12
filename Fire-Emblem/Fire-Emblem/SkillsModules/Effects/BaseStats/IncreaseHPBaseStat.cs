using System.Net.Mail;

namespace Fire_Emblem;

public class IncreaseHPBaseStat : Effect
{
    private int _changeFactor;
    
    public IncreaseHPBaseStat(int changeFactor)
    {
        _changeFactor = changeFactor;
        this.SetPriority(1);
    }
    
    public override void ApplyEffect(Unit unit, Unit opponent)
    {
        unit.HPMax += _changeFactor;
        unit.HPCurrent += _changeFactor;
    }
}