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
        const string SWORD_WEAPON = "Sword";
        const string AXE_WEAPON = "Axe"; 
        const string LANCE_WEAPON = "Lance";
        const string BOW_WEAPON = "Bow";
        const string MAGIC_WEAPON = "Magic";
        switch (_damageType)
        {
            case DamageType.Physical:
                return unit.Weapon == SWORD_WEAPON || unit.Weapon == AXE_WEAPON || unit.Weapon == LANCE_WEAPON || unit.Weapon == BOW_WEAPON;
            case DamageType.Magical:
                return unit.Weapon == MAGIC_WEAPON;
            default:
                return false;
        }
    }
}