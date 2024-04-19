namespace Fire_Emblem;

public abstract class Condition
{
    public abstract bool IsConditionFulfilled(Unit unit, Unit opponent, string firstPlayerOfRoundName, string secondPlayerOfRoundName, Stats unitCombatStats, Stats opponentCombatStats);
}

public class UnitStartsCombatCondition : Condition
{
    public override bool IsConditionFulfilled(Unit unit, Unit opponent, string firstPlayerOfRoundName, string secondPlayerOfRoundName, Stats unitCombatStats, Stats opponentCombatStats)
    {
        return unit.Name == firstPlayerOfRoundName;
    }
}

public class OpponentStartsCombatCondition : Condition
{
    public override bool IsConditionFulfilled(Unit unit, Unit opponent, string firstPlayerOfRoundName, string secondPlayerOfRoundName, Stats unitCombatStats, Stats opponentCombatStats)
    {
        return opponent.Name == firstPlayerOfRoundName;
    }
}

public class OpponentIsMostRecentRivalOfUnitCondition : Condition
{
    public override bool IsConditionFulfilled(Unit unit, Unit opponent, string firstPlayerOfRoundName, string secondPlayerOfRoundName, Stats unitCombatStats, Stats opponentCombatStats)
    {
        return unit.MostRecentRival == opponent.Name;
    }
}

public class UnitHasWeaponTypeCondition : Condition
{
    private string _weaponType;

    public UnitHasWeaponTypeCondition(string weaponType)
    {
        this._weaponType = weaponType;
    }

    public override bool IsConditionFulfilled(Unit unit, Unit opponent, string firstPlayerOfRoundName, string secondPlayerOfRoundName, Stats unitCombatStats, Stats opponentCombatStats)
    {
        return unit.Weapon == _weaponType;
    }
}

public class OpponentHasWeaponTypeCondition : Condition
{
    private string _weaponType;

    public OpponentHasWeaponTypeCondition(string weaponType)
    {
        this._weaponType = weaponType;
    }

    public override bool IsConditionFulfilled(Unit unit, Unit opponent, string firstPlayerOfRoundName, string secondPlayerOfRoundName, Stats unitCombatStats, Stats opponentCombatStats)
    {
        return opponent.Weapon == _weaponType;
    }
}

public class OpponentIsMale : Condition
{
    public override bool IsConditionFulfilled(Unit unit, Unit opponent, string firstPlayerOfRoundName,
        string secondPlayerOfRoundName, Stats unitCombatStats, Stats opponentCombatStats)
    {
        return opponent.Gender == "Male";
    }
}

public class UnitDamageTypeCondition : Condition
{
    private DamageType _damageType;

    public UnitDamageTypeCondition(DamageType damageType)
    {
        this._damageType = damageType;
    }

    public override bool IsConditionFulfilled(Unit unit, Unit opponent, string firstPlayerOfRoundName, string secondPlayerOfRoundName, Stats unitCombatStats, Stats opponentCombatStats)
    {
        return IsUnitDamageTypeCorrect(unit);
    }
    
    private bool IsUnitDamageTypeCorrect(Unit unit)
    {
        switch (_damageType)
        {
            case DamageType.Physical:
                return unit.Weapon == "Sword" || unit.Weapon == "Axe" || unit.Weapon == "Lance";
            case DamageType.Magical:
                return unit.Weapon == "Magic";
            default:
                return false;
        }
    }
}

public class OpponentDamageTypeCondition : Condition
{
    private DamageType _damageType;

    public OpponentDamageTypeCondition(DamageType damageType)
    {
        this._damageType = damageType;
    }

    public override bool IsConditionFulfilled(Unit unit, Unit opponent, string firstPlayerOfRoundName, string secondPlayerOfRoundName, Stats unitCombatStats, Stats opponentCombatStats)
    {
        return IsOpponentDamageTypeCorrect(opponent);
    }
    
    private bool IsOpponentDamageTypeCorrect(Unit opponent)
    {
        switch (_damageType)
        {
            case DamageType.Physical:
                return opponent.Weapon == "Sword" || opponent.Weapon == "Axe" || opponent.Weapon == "Lance";
            case DamageType.Magical:
                return opponent.Weapon == "Magic";
            default:
                return false;
        }
    }
}

public class UnitHPVsOpponentCondition : Condition
{
    private int _expectedHpDifference;
    public UnitHPVsOpponentCondition(int expectedHPDifference)
    {
        this._expectedHpDifference = expectedHPDifference;
    }
    public override bool IsConditionFulfilled(Unit unit, Unit opponent, string firstPlayerOfRoundName, string secondPlayerOfRoundName, Stats unitCombatStats, Stats opponentCombatStats)
    {
        return unitCombatStats.HPCurrent >= opponentCombatStats.HPCurrent + _expectedHpDifference;
    }
}

public class UnitHPCondition : Condition
{
    private int _threshold;
    private ThresholdType _thresholdType;
    private ComparisonType _comparisonType;

    public UnitHPCondition(int threshold, ThresholdType thresholdType = ThresholdType.Absolute, ComparisonType comparisonType = ComparisonType.GreaterThanOrEqual)
    {
        this._threshold = threshold;
        this._thresholdType = thresholdType;
        this._comparisonType = comparisonType;
    }

    public override bool IsConditionFulfilled(Unit unit, Unit opponent, string firstPlayerOfRoundName, string secondPlayerOfRoundName, Stats unitCombatStats, Stats opponentCombatStats)
    {
        SetThresholdValue(unitCombatStats);

        return IsHPCorrect(unitCombatStats);
    }

    private void SetThresholdValue(Stats stats)
    {
        if (_thresholdType == ThresholdType.Percentage)
        {
            _threshold = (int)(stats.HPMax * (_threshold / 100.0));
        }
    }

    private bool IsHPCorrect(Stats stats)
    {
        switch (_comparisonType)
        {
            case ComparisonType.GreaterThanOrEqual:
                return stats.HPCurrent >= _threshold;
            case ComparisonType.LowerThanOrEqual:
                return stats.HPCurrent <= _threshold;
            case ComparisonType.Equal:
                return stats.HPCurrent == _threshold;
            default:
                return false;
        }
    }
}