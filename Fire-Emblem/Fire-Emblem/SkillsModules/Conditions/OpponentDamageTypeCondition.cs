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
        switch (_damageType)
        {
            case DamageType.Physical:
                return opponent.Weapon == "Sword" || opponent.Weapon == "Axe" || opponent.Weapon == "Lance" || opponent.Weapon == "Bow";
            case DamageType.Magical:
                return opponent.Weapon == "Magic";
            default:
                return false;
        }
    }
}