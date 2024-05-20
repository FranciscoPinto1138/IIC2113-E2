namespace Fire_Emblem;

public class Remote : Hybrid
{
    private List<StatType> _bufferedStatsList;
    private List<int> _changeFactorsList;
    
    public Remote(List<StatType> bufferedStatsList, List<int> changeFactorsList)
    {
        this.Name = "Remote";
        this.Description = "Si la unidad inicia el combate, otorga bonus a stats y reduce el daño del " +
                           "primer ataque del rival en un 30%.";
        this._bufferedStatsList = bufferedStatsList;
        this._changeFactorsList = changeFactorsList;
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { 
            new ConditionEffectPair(new UnitStartsCombatCondition(), 
                new IncreaseStats(_bufferedStatsList, _changeFactorsList)),
            new ConditionEffectPair(new UnitStartsCombatCondition(), 
                new ReduceReceivedPermanentDamageByPercentageOnOpponentFirstAttack(0.3))
        };
    }
}