namespace Fire_Emblem;

public class Stance : Hybrid
{
    private List<StatType> _bufferedStatsList;
    private List<int> _changeFactorsList;
    
    public Stance(List<StatType> bufferedStatsList, List<int> changeFactorsList)
    {
        this.Name = "Stance";
        this.Description = "Si el rival inicia el combate, otorga bonus a ciertos stats durante el combate y reduce el daño del Follow-Up del rival en un 10%.";
        this._bufferedStatsList = bufferedStatsList;
        this._changeFactorsList = changeFactorsList;
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        var condition = new OpponentStartsCombatCondition();
        var firstEffectOnUnit = new IncreaseStats(_bufferedStatsList, _changeFactorsList);
        var secondEffectOnUnit = new ReduceReceivedPermanentDamageByPercentageOnOpponentFollowUp(0.1);
        return new ConditionEffectPair[] { new ConditionEffectPair(condition, firstEffectOnUnit),
            new ConditionEffectPair(condition, secondEffectOnUnit) };
    }
}