namespace Fire_Emblem;

public class Stance : Skill
{
    private StatTypeList _bufferedStatsList;
    private List<int> _changeFactorsList;
    
    public Stance(StatTypeList bufferedStatsList, List<int> changeFactorsList)
    {
        this.Name = "Stance";
        this.Description = "Si el rival inicia el combate, otorga bonus a ciertos stats durante el combate " +
                           "y reduce el daño del Follow-Up del rival en un 10%.";
        this._bufferedStatsList = bufferedStatsList;
        this._changeFactorsList = changeFactorsList;
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { 
            new ConditionEffectPair(new OpponentStartsCombatCondition(), 
                new IncreaseStats(_bufferedStatsList, _changeFactorsList)),
            new ConditionEffectPair(new OpponentStartsCombatCondition(), 
                new ReduceReceivedPermanentDamageByPercentageOnOpponentFollowUp(0.1)) 
        };
    }
}