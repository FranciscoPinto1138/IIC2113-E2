namespace Fire_Emblem;

public class StatBuffer : Bonus
{
    private List<StatType> _bufferedStatsList;
    private List<int> _changeFactorsList;
    public StatBuffer(Unit unit, Unit opponent, List<StatType> bufferedStatsList, List<int> changeFactorsList) : base(unit, opponent)
    {
        this.Name = "StatBuffer";
        this.Description = "Para habilidades que sólo aumentan stats";
        this.unit = unit;
        this.opponent = opponent;
        this._bufferedStatsList = bufferedStatsList;
        this._changeFactorsList = changeFactorsList;
    }
    
    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var condition = new NoCondition();
        for (int i = 0; i < _bufferedStatsList.Count; i++)
        {
            var effectOnUnit = new IncreaseStat(_changeFactorsList[i], _bufferedStatsList[i]);
            if (condition.IsConditionFulfilled(unit, opponent))
            {
                effectOnUnit.ApplyEffect(unit, opponent);
            }
        }
    }
}