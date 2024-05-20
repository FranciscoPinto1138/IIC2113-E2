namespace Fire_Emblem;

public class Brazen : Skill
{
    private List<StatType> _bufferedStatsList;
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
        return new ConditionEffectPair[] { new ConditionEffectPair(
            new UnitHPCondition(80, ThresholdType.Percentage, ComparisonType.LowerThanOrEqual), 
            new IncreaseStats(_bufferedStatsList, _changeFactorsList)) 
        };
    }
}