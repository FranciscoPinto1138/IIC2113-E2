namespace Fire_Emblem;

// Luna
public class DecreaseStatByPercentageOnFirstAttack : PenaltyEffect
{
    private double _changeFactor;
    private StatType _statType;
    
    public DecreaseStatByPercentageOnFirstAttack(double changeFactor, StatType statType)
    {
        _changeFactor = changeFactor;
        _statType = statType;
    }
    
    public override void ApplyEffect(Unit unit, Unit opponent)
    {
        switch (_statType)
        {
            case StatType.Atk:
                unit.FirstAttackPenaltyStatsDiff.Atk -= (int)(Math.Floor(unit.Atk * (_changeFactor / 100)));
                break;
            case StatType.Def:
                unit.FirstAttackPenaltyStatsDiff.Def -= (int)((Math.Floor(unit.Def * (_changeFactor / 100))));
                break;
            case StatType.Res:
                unit.FirstAttackPenaltyStatsDiff.Res -= (int)((Math.Floor(unit.Res * (_changeFactor / 100))));
                break;
        }
    }
}