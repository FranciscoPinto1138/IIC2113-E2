namespace Fire_Emblem;

public class Boost : Skill
{
    private List<StatType>_bufferedStatsList;
    private List<int> _changeFactorsList;
    
    public Boost(List<StatType> bufferedStatsList, List<int> changeFactorsList)
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