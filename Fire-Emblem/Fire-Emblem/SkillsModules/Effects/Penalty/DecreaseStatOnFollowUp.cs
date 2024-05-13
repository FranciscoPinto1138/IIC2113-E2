namespace Fire_Emblem;

// Sandstorm
public class DecreaseStatOnFollowUp : PenaltyEffect
{
    private int _changeFactor;
    private StatType _statType;
    
    public DecreaseStatOnFollowUp(int changeFactor, StatType statType)
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
                unit.FollowUpAttackPenaltyStatsDiff.Atk -= _changeFactor;
                break;
            case StatType.Def:
                unit.FollowUpAttackPenaltyStatsDiff.Def -= _changeFactor;
                break;
            case StatType.Res:
                unit.FollowUpAttackPenaltyStatsDiff.Res -= _changeFactor;
                break;
        }
    }
}