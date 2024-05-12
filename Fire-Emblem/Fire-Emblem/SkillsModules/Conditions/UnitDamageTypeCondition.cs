namespace Fire_Emblem;

public class UnitDamageTypeCondition : Condition
{
    private DamageType _damageType;

    public UnitDamageTypeCondition(DamageType damageType)
    {
        this._damageType = damageType;
        SetPriority(1);
    }

    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        return IsUnitDamageTypeCorrect(unit);
    }
    
    private bool IsUnitDamageTypeCorrect(Unit unit)
    {
        switch (_damageType)
        {
            case DamageType.Physical:
                return unit.Weapon == "Sword" || unit.Weapon == "Axe" || unit.Weapon == "Lance" || unit.Weapon == "Bow";
            case DamageType.Magical:
                return unit.Weapon == "Magic";
            default:
                return false;
        }
    }
}