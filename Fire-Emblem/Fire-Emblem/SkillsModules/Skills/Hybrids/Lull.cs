namespace Fire_Emblem;

public class Lull : Skill
{
    private StatTypeList _rivalDecreasedStatsList;
    private StatTypeList _rivalNeutralizedStatsList;
    private ChangeFactorList _changeDecreaseFactorsList;
    
    public Lull(StatTypeList rivalDecreasedStatsList, ChangeFactorList changeDecreaseFactorsList, 
        StatTypeList rivalNeutralizedStatsList)
    {
        this.Name = "Lull";
        this.Description = "Varias habilidades en que se penaliza stats del rival y se neutralizan bonus de otras stats";
        this._rivalNeutralizedStatsList = rivalDecreasedStatsList;
        this._rivalDecreasedStatsList = rivalNeutralizedStatsList;
        this._changeDecreaseFactorsList = changeDecreaseFactorsList;
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { 
            new ConditionEffectPair(new NoCondition(), 
                new NeutralizeOpponentBonusStats(_rivalNeutralizedStatsList)),
            new ConditionEffectPair(new NoCondition(), 
                new DecreaseOpponentStats(_rivalDecreasedStatsList, _changeDecreaseFactorsList))};
    }
}