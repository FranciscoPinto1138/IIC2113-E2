namespace Fire_Emblem;

public class IncreaseAtkSpdByLostHP : BonusEffect
{
    private int _originalBonus;

    public IncreaseAtkSpdByLostHP()
    {
        this.SetPriority(1);
    }
    
    public override void ApplyEffect(Unit unit, Unit opponent)
    {
        const int MAX_BONUS_BY_LOST_HP = 30;
        _originalBonus = Math.Min(unit.HPMax - unit.HPCurrent, MAX_BONUS_BY_LOST_HP);
        unit.BonusStatsDiff.Atk += _originalBonus;
        unit.BonusStatsDiff.Spd += _originalBonus;
    }
}
