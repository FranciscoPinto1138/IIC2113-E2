namespace Fire_Emblem;

public abstract class PenaltyEffect : Effect
{
    public abstract void ApplyEffect(Unit unit, Unit opponent);
}

public class DecreaseStat : PenaltyEffect
{
    private int _changeFactor;
    private StatType _statType;
    
    public DecreaseStat(int changeFactor, StatType statType)
    {
        _changeFactor = changeFactor;
        _statType = statType;
    }
    
    public override void ApplyEffect(Unit unit, Unit opponent)
    {
        switch (_statType)
        {
            case StatType.Atk:
                unit.PenaltyStatsDiff.Atk -= _changeFactor;
                break;
            case StatType.Spd:
                unit.PenaltyStatsDiff.Spd -= _changeFactor;
                break;
            case StatType.Def:
                unit.PenaltyStatsDiff.Def -= _changeFactor;
                break;
            case StatType.Res:
                unit.PenaltyStatsDiff.Res -= _changeFactor;
                break;
        }
    }
}

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

// Sandstorm
public class DecreaseStatOnFollowUp : PenaltyEffect
{
    private int _changeFactor;
    private StatType _statType;
    
    public DecreaseStatOnFollowUp(int changeFactor, StatType statType)
    {
        _changeFactor = changeFactor;
        _statType = statType;
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