namespace Fire_Emblem;

public class OpponentHPCondition : Condition
{
    private int _threshold;
    private ThresholdType _thresholdType;
    private ComparisonType _comparisonType;

    public OpponentHPCondition(int threshold, ThresholdType thresholdType, ComparisonType comparisonType)
    {
        this._threshold = threshold;
        this._thresholdType = thresholdType;
        this._comparisonType = comparisonType;
        this.SetPriority(1);
    }

    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        SetThresholdValue(opponent);

        return IsHPCorrect(opponent);
    }

    private void SetThresholdValue(Unit opponent)
    {
        if (_thresholdType == ThresholdType.Percentage)
        {
            _threshold = (int)(opponent.HPMax * (_threshold / 100.0));
        }
    }

    private bool IsHPCorrect(Unit opponent)
    {
        switch (_comparisonType)
        {
            case ComparisonType.GreaterThanOrEqual:
                return opponent.HPCurrent >= _threshold;
            case ComparisonType.LowerThanOrEqual:
                return opponent.HPCurrent <= _threshold;
            case ComparisonType.Equal:
                return opponent.HPCurrent == _threshold;
            default:
                return false;
        }
    }
}