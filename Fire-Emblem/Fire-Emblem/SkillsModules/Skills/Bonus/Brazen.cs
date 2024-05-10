namespace Fire_Emblem;

public class Brazen : Bonus
{
    private List<StatType>_bufferedStatsList;
    private List<int> _changeFactorsList;
    
    public Brazen(List<StatType> bufferedStatsList, List<int> changeFactorsList)
    {
        this.Name = "Brazen";
        this.Description = "Varias habilidades donde si unidad tiene HP <= 80 %, mejora ciertas stats";
        this._bufferedStatsList = bufferedStatsList;
        this._changeFactorsList = changeFactorsList;
    }

    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var condition = new UnitHPCondition(80, ThresholdType.Percentage, ComparisonType.LowerThanOrEqual);
        var effectOnUnit = new StatBuffer(unit, opponent, _bufferedStatsList, _changeFactorsList);
        if (condition.IsConditionFulfilled(unit, opponent))
        {
            effectOnUnit.ApplyEffectsIfConditionsAreSatisfied(unit, opponent);
        }
    }
}