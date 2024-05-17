namespace Fire_Emblem;

public class OpponentDamageTypeCondition : Condition
{
    private DamageType _damageType;

    public OpponentDamageTypeCondition(DamageType damageType)
    {
        this._damageType = damageType;
        SetPriority(1);
    }

    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        return IsUnitDamageTypeCorrect(opponent);
    }
    
    private bool IsUnitDamageTypeCorrect(Unit opponent)
    {
        const string SWORD_WEAPON = "Sword";
        const string AXE_WEAPON = "Axe"; 
        const string LANCE_WEAPON = "Lance";
        const string BOW_WEAPON = "Bow";
        const string MAGIC_WEAPON = "Magic";
        switch (_damageType)
        {
            case DamageType.Physical:
                return opponent.Weapon == SWORD_WEAPON || opponent.Weapon == AXE_WEAPON || opponent.Weapon == LANCE_WEAPON || opponent.Weapon == BOW_WEAPON;
            case DamageType.Magical:
                return opponent.Weapon == MAGIC_WEAPON;
            default:
                return false;
        }
    }
}