namespace Fire_Emblem;

public class BlowStrikeSparrow : Bonus
{
    private List<StatType>_bufferedStatsList;
    private List<int> _changeFactorsList;
    
    public BlowStrikeSparrow(List<StatType> bufferedStatsList, List<int> changeFactorsList)
    {
        this.Name = "Blow/Strike/Sparrow";
        this.Description = "Varias habilidades donde si unidad empieza el combate, mejora ciertas stats";
        this._bufferedStatsList = bufferedStatsList;
        this._changeFactorsList = changeFactorsList;
    }

    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var condition = new UnitStartsCombatCondition();
        var effectOnUnit = new StatBuffer(unit, opponent, _bufferedStatsList, _changeFactorsList);
        if (condition.IsConditionFulfilled(unit, opponent))
        {
            effectOnUnit.ApplyEffectsIfConditionsAreSatisfied(unit, opponent);
        }
    }
}