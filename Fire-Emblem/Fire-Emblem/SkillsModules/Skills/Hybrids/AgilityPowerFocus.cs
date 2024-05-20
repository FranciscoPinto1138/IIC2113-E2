namespace Fire_Emblem;

public class AgilityPowerFocus : Hybrid
{
    private String _weaponType;
    private List<StatType>_bufferedStatsList;
    private List<StatType>_decreasedStatsList;
    private List<int> _changeBuffFactorsList;
    private List<int> _changeDecreaseFactorsList;
    
    public AgilityPowerFocus(String weaponType, List<StatType> bufferedStatsList, List<int> changeBuffFactorsList, List<StatType>decreasedStatsList, List<int> changeDecreaseFactorsList)
    {
        this.Name = "Agility/Power/Focus";
        this.Description = "Varias habilidades en que si la unidad usa cierta arma, " +
                           "aumenta un stat a cambio de disminuir otro";
        this._bufferedStatsList = bufferedStatsList;
        this._changeBuffFactorsList = changeBuffFactorsList;
        this._decreasedStatsList = decreasedStatsList;
        this._changeDecreaseFactorsList = changeDecreaseFactorsList;
        this._weaponType = weaponType;
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[]
        {
            new ConditionEffectPair(
                new UnitHasWeaponTypeCondition(_weaponType), 
                new IncreaseStats(_bufferedStatsList, _changeBuffFactorsList)), 
            new ConditionEffectPair(
                new UnitHasWeaponTypeCondition(_weaponType), 
                new DecreaseStat(_changeDecreaseFactorsList[0], _decreasedStatsList[0]))
        };
    }
}