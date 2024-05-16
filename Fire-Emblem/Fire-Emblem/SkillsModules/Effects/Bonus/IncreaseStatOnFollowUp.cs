namespace Fire_Emblem;

public class IncreaseStatOnFollowUp : BonusEffect
{
    private int _changeFactor;
    private StatType _statType;
    
    public IncreaseStatOnFollowUp(int changeFactor, StatType statType)
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
                unit.FollowUpAttackBonusStatsDiff.Atk += _changeFactor;
                break;
            case StatType.Def:
                unit.FollowUpAttackBonusStatsDiff.Def += _changeFactor;
                break;
            case StatType.Res:
                unit.FollowUpAttackBonusStatsDiff.Res += _changeFactor;
                break;
        }
    }
}