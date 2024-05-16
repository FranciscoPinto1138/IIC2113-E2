namespace Fire_Emblem;

public class IncreaseStatByPercentageOnFirstAttack : BonusEffect
{
    private double _changeFactor;
    private StatType _statType;
    
    public IncreaseStatByPercentageOnFirstAttack(double changeFactor, StatType statType)
    {
        _changeFactor = changeFactor;
        _statType = statType;
        this.SetPriority(1);
    }
    
    public override void ApplyEffect(Unit unit, Unit opponent)
    {
        switch (_statType)
        {
            case StatType.Atk:
                unit.FirstAttackBonusStatsDiff.Atk += (int)(unit.Atk * (_changeFactor / 100));
                break;
            case StatType.Def:
                unit.FirstAttackBonusStatsDiff.Def += (int)(unit.Def * (_changeFactor / 100));
                break;
            case StatType.Res:
                unit.FirstAttackBonusStatsDiff.Res += (int)(unit.Res * (_changeFactor / 100));
                break;
        }
    }
}