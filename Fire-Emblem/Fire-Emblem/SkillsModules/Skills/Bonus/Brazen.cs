namespace Fire_Emblem;

public class Brazen : Skill
{
    private StatTypeList _bufferedStatsList;
    private ChangeFactorList _changeFactorsList;
    
    public Brazen(StatTypeList bufferedStatsList, ChangeFactorList changeFactorsList)
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