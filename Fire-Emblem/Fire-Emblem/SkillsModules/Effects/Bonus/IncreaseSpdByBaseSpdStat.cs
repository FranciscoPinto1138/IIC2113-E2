namespace Fire_Emblem;

public class IncreaseSpdByBaseSpdStat : BonusEffect
{
    private int _changeFactor;
    
    public IncreaseSpdByBaseSpdStat(int changeFactor)
    {
        _changeFactor = changeFactor;
        this.SetPriority(1);
    }
    
    public override void ApplyEffect(Unit unit, Unit opponent)
    {
        unit.BonusStatsDiff.Spd += (int)Math.Floor((double)(unit.Spd / _changeFactor));
    }
}   