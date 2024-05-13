namespace Fire_Emblem;

public class UnitHPCondition : Condition
{
    private int _threshold;
    private ThresholdType _thresholdType;
    private ComparisonType _comparisonType;

    public UnitHPCondition(int threshold, ThresholdType thresholdType, ComparisonType comparisonType)
    {
        this._threshold = threshold;
        this._thresholdType = thresholdType;
        this._comparisonType = comparisonType;
        this.SetPriority(1);
    }

    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        SetThresholdValue(unit);

        return IsHPCorrect(unit);
    }

    private void SetThresholdValue(Unit unit)
    {
        if (_thresholdType == ThresholdType.Percentage)
        {
            _threshold = (int)(unit.HPMax * (_threshold / 100.0));
        }
    }

    private bool IsHPCorrect(Unit unit)
    {
        switch (_comparisonType)
        {
            case ComparisonType.GreaterThanOrEqual:
                return unit.HPCurrent >= _threshold;
            case ComparisonType.LowerThanOrEqual:
                return unit.HPCurrent <= _threshold;
            case ComparisonType.Equal:
                return unit.HPCurrent == _threshold;
            default:
                return false;
        }
    }
}