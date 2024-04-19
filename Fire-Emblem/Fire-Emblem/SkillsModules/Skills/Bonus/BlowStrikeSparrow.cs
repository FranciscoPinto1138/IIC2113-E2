namespace Fire_Emblem;

public class BlowStrikeSparrow : Bonus
{
    private List<StatType>_bufferedStatsList;
    private List<int> _changeFactorsList;
    
    public BlowStrikeSparrow(Unit unit, Unit opponent, List<StatType> bufferedStatsList, List<int> changeFactorsList) : base(unit, opponent)
    {
        this.Name = "Blow/Strike/Sparrow";
        this.Description = "Varias habilidades donde si unidad empieza el combate, mejora ciertas stats";
        this.unit = unit;
        this.opponent = opponent;
        this._bufferedStatsList = bufferedStatsList;
        this._changeFactorsList = changeFactorsList;
    }

    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var condition = new UnitStartsCombatCondition();
        var effectOnUnit = new StatBuffer(((Skill)this).unit, ((Skill)this).opponent, _bufferedStatsList, _changeFactorsList);
        if (condition.IsConditionFulfilled(unit, opponent))
        {
            effectOnUnit.ApplyEffectsIfConditionsAreSatisfied(unit, opponent);
        }
    }
}