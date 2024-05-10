namespace Fire_Emblem;

// Wrath
public class IncreaseAtkSpdByLostHP : BonusEffect
{
    private int _originalBonus;
    public override void ApplyEffect(Unit unit, Unit opponent)
    {
        _originalBonus = Math.Min(unit.HPMax - unit.HPCurrent, 30);
        unit.BonusStatsDiff.Atk += _originalBonus;
        unit.BonusStatsDiff.Spd += _originalBonus;
    }
}
