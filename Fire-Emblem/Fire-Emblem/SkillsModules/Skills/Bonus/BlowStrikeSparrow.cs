namespace Fire_Emblem;

public class BlowStrikeSparrow : Skill
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
    
    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { new ConditionEffectPair(
            new UnitStartsCombatCondition(), new IncreaseStats(_bufferedStatsList, _changeFactorsList)) 
        };
    }
}