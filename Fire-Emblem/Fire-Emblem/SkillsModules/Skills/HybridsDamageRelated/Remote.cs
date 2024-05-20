namespace Fire_Emblem;

public class Remote : Skill
{
    private StatTypeList _bufferedStatsList;
    private ChangeFactorList _changeFactorsList;
    
    public Remote(StatTypeList bufferedStatsList, ChangeFactorList changeFactorsList)
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