namespace Fire_Emblem;

public class DecreaseOpponentStatByPercentageOnFirstAttack : PenaltyEffect
{
    private double _changeFactor;
    private StatType _statType;
    
    public DecreaseOpponentStatByPercentageOnFirstAttack(double changeFactor, StatType statType)
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
                opponent.FirstAttackPenaltyStatsDiff.Atk -= (int)(Math.Floor(opponent.Atk * (_changeFactor / 100)));
                break;
            case StatType.Def:
                opponent.FirstAttackPenaltyStatsDiff.Def -= (int)((Math.Floor(opponent.Def * (_changeFactor / 100))));
                break;
            case StatType.Res:
                opponent.FirstAttackPenaltyStatsDiff.Res -= (int)((Math.Floor(opponent.Res * (_changeFactor / 100))));
                break;
        }
    }
}