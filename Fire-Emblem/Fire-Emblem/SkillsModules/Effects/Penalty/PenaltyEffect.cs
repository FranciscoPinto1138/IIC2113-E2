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

public class IgnoreHalfDefandRes : PenaltyEffect
{
    public override void ApplyEffect(Unit unit, Unit opponent)
    {
        opponent.PenaltyStatsDiff.Def -= (int)(opponent.Def * 0.5);
        opponent.PenaltyStatsDiff.Res -= (int)(opponent.Res * 0.5);
    }
}