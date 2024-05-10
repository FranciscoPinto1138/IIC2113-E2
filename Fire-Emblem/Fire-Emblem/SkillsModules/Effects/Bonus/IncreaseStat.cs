namespace Fire_Emblem;

public class IncreaseStat : BonusEffect
{
    private int _changeFactor;
    private StatType _statType;
    
    public IncreaseStat(int changeFactor, StatType statType)
    {
        _changeFactor = changeFactor;
        _statType = statType;
    }
    
    public override void ApplyEffect(Unit unit, Unit opponent)
    {
        switch (_statType)
        {
            case StatType.Atk:
                unit.BonusStatsDiff.Atk += _changeFactor;
                break;
            case StatType.Spd:
                unit.BonusStatsDiff.Spd += _changeFactor;
                break;
            case StatType.Def:
                unit.BonusStatsDiff.Def += _changeFactor;
                break;
            case StatType.Res:
                unit.BonusStatsDiff.Res += _changeFactor;
                break;
        }
    }
}