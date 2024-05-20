namespace Fire_Emblem;

public class StatBuffer : Bonus
{
    private List<StatType> _bufferedStatsList;
    private List<int> _changeFactorsList;
    public StatBuffer(List<StatType> bufferedStatsList, List<int> changeFactorsList)
    {
        this.Name = "StatBuffer";
        this.Description = "Para habilidades que sólo aumentan stats";
        this._bufferedStatsList = bufferedStatsList;
        this._changeFactorsList = changeFactorsList;
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { new ConditionEffectPair(
            new NoCondition(), new IncreaseStats(_bufferedStatsList, _changeFactorsList)) 
        };
    }
}