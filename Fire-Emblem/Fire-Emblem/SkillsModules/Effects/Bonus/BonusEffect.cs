namespace Fire_Emblem;

public abstract class BonusEffect : Effect
{
    public abstract void ApplyEffect(Unit unit, Unit opponent);
}

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

// Pendiente de implementar Ignis y "Atk+50 % al primer ataque de la unidad"

// Ignis
public class IncreaseStatByPercentageOnFirstAttack : BonusEffect
{
    private double _changeFactor;
    private StatType _statType;
    
    public IncreaseStatByPercentageOnFirstAttack(double changeFactor, StatType statType)
    {
        _changeFactor = changeFactor;
        _statType = statType;
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

// Sandstorm
public class IncreaseStatOnFollowUp : BonusEffect
{
    private int _changeFactor;
    private StatType _statType;
    
    public IncreaseStatOnFollowUp(int changeFactor, StatType statType)
    {
        _changeFactor = changeFactor;
        _statType = statType;
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

public class IncreaseSpdByBaseSpdStat : BonusEffect
{
    private int _changeFactor;
    
    public IncreaseSpdByBaseSpdStat(int changeFactor)
    {
        _changeFactor = changeFactor;
    }
    
    public override void ApplyEffect(Unit unit, Unit opponent)
    {
        unit.BonusStatsDiff.Spd += (int)Math.Floor((double)(unit.Spd / _changeFactor));
    }
}   