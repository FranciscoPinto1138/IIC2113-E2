namespace Fire_Emblem;

public class StatBuffer : Skill
{
    private StatTypeList _bufferedStatsList;
    private ChangeFactorList _changeFactorsList;
    public StatBuffer(StatTypeList bufferedStatsList, ChangeFactorList changeFactorsList)
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