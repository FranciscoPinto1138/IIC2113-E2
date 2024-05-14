namespace Fire_Emblem;

public class Brazen : Bonus
{
    private List<StatType>_bufferedStatsList;
    private List<int> _changeFactorsList;
    
    public Brazen(List<StatType> bufferedStatsList, List<int> changeFactorsList)
    {
        this.Name = "Brazen";
        this.Description = "Varias habilidades donde si unidad tiene HP <= 80 %, mejora ciertas stats";
        this._bufferedStatsList = bufferedStatsList;
        this._changeFactorsList = changeFactorsList;
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        var condition = new UnitHPCondition(80, ThresholdType.Percentage, ComparisonType.LowerThanOrEqual);
        var effect = new IncreaseStats(_bufferedStatsList, _changeFactorsList);
        return new ConditionEffectPair[] { new ConditionEffectPair(condition, effect) };
    }
}