namespace Fire_Emblem;

public class Boost : Bonus
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

    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var condition = new UnitHPVsOpponentCondition(3);
        var effectOnUnit = new StatBuffer(_bufferedStatsList, _changeFactorsList);
        if (condition.IsConditionFulfilled(unit, opponent))
        {
            effectOnUnit.ApplyEffectsIfConditionsAreSatisfied(unit, opponent);
        }
    }
    
    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        var condition = new UnitHPVsOpponentCondition(3);
        var effect = new IncreaseStats(_bufferedStatsList, _changeFactorsList);
        return new ConditionEffectPair[] { new ConditionEffectPair(condition, effect) };
    }
}