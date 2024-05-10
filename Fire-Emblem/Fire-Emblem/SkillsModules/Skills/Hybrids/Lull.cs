namespace Fire_Emblem;

public class Lull : Hybrid
{
    private List<StatType> _rivalDecreasedStatsList;
    private List<StatType> _rivalNeutralizedStatsList;
    private List<int> _changeDecreaseFactorsList;
    
    public Lull(List<StatType> rivalDecreasedStatsList, List<int> changeDecreaseFactorsList, List<StatType> rivalNeutralizedStatsList)
    {
        this.Name = "Lull";
        this.Description = "Varias habilidades en que se penaliza stats del rival y se neutralizan bonus de otras stats";
        this._rivalNeutralizedStatsList = rivalDecreasedStatsList;
        this._rivalDecreasedStatsList = rivalNeutralizedStatsList;
        this._changeDecreaseFactorsList = changeDecreaseFactorsList;
    }

    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var condition = new NoCondition();
        var neutralizeStatsOnRivalEffect = new NeutralizeBonusOnStats(_rivalNeutralizedStatsList);
        var decreaseStatOnRivalEffect = new DecreaseStat(_changeDecreaseFactorsList[0], _rivalDecreasedStatsList[0]);
        var decreaseStatOnRivalEffectAdditional =  new DecreaseStat(_changeDecreaseFactorsList[1], _rivalDecreasedStatsList[1]);
        if (condition.IsConditionFulfilled(unit, opponent))
        {
            neutralizeStatsOnRivalEffect.ApplyEffect(opponent, unit);
            decreaseStatOnRivalEffect.ApplyEffect(opponent, unit);
            decreaseStatOnRivalEffectAdditional.ApplyEffect(opponent, unit);
        }
    }
}