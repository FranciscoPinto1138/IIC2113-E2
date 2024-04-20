namespace Fire_Emblem;

public class Boost : Bonus
{
    private List<StatType>_bufferedStatsList;
    private List<int> _changeFactorsList;
    
    public Boost(Unit unit, Unit opponent, List<StatType> bufferedStatsList, List<int> changeFactorsList) : base(unit, opponent)
    {
        this.Name = "Boost";
        this.Description = "Varias habilidades donde si unidad tiene HP >= HP del rival+3, mejora ciertas stats";
        this.unit = unit;
        this.opponent = opponent;
        this._bufferedStatsList = bufferedStatsList;
        this._changeFactorsList = changeFactorsList;
    }

    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var condition = new UnitHPVsOpponentCondition(3);
        var effectOnUnit = new StatBuffer(((Skill)this).unit, ((Skill)this).opponent, _bufferedStatsList, _changeFactorsList);
        if (condition.IsConditionFulfilled(unit, opponent))
        {
            effectOnUnit.ApplyEffectsIfConditionsAreSatisfied(unit, opponent);
        }
    }
}