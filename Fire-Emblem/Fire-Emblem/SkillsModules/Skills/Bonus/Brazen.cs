namespace Fire_Emblem;

public class Brazen : Bonus
{
    private List<StatType>_bufferedStatsList;
    private List<int> _changeFactorsList;
    
    public Brazen(Unit unit, Unit opponent, List<StatType> bufferedStatsList, List<int> changeFactorsList) : base(unit, opponent)
    {
        this.Name = "Brazen";
        this.Description = "Varias habilidades donde si unidad tiene HP <= 80 %, mejora ciertas stats";
        this.unit = unit;
        this.opponent = opponent;
        this._bufferedStatsList = bufferedStatsList;
        this._changeFactorsList = changeFactorsList;
    }

    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var condition = new UnitHPCondition(80, ThresholdType.Percentage, ComparisonType.LowerThanOrEqual);
        var effectOnUnit = new StatBuffer(((Skill)this).unit, ((Skill)this).opponent, _bufferedStatsList, _changeFactorsList);
        if (condition.IsConditionFulfilled(unit, opponent))
        {
            effectOnUnit.ApplyEffectsIfConditionsAreSatisfied(unit, opponent);
        }
    }
}