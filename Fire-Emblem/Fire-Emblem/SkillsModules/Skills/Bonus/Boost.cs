namespace Fire_Emblem;

public class Boost : Skill
{
    private StatTypeList _bufferedStatsList;
    private ChangeFactorList _changeFactorsList;
    
    public Boost(StatTypeList bufferedStatsList, ChangeFactorList changeFactorsList)
    {
        this.Name = "Boost";
        this.Description = "Varias habilidades donde si unidad tiene HP >= HP del rival+3, mejora ciertas stats";
        this._bufferedStatsList = bufferedStatsList;
        this._changeFactorsList = changeFactorsList;
    }
    
    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { new ConditionEffectPair(
            new UnitHPVsOpponentCondition(3), new IncreaseStats(_bufferedStatsList, _changeFactorsList)) 
        };
    }
}