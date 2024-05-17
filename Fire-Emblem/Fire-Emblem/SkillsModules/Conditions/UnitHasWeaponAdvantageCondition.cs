namespace Fire_Emblem;

public class UnitHasWeaponAdvantageCondition : Condition
{
    public UnitHasWeaponAdvantageCondition()
    {
        SetPriority(1);
    }

    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        const string SWORD_WEAPON = "Sword";
        const string AXE_WEAPON = "Axe"; 
        const string LANCE_WEAPON = "Lance";
        return (unit.Weapon == SWORD_WEAPON && opponent.Weapon == AXE_WEAPON) ||
               (unit.Weapon == AXE_WEAPON && opponent.Weapon == LANCE_WEAPON) ||
               (unit.Weapon == LANCE_WEAPON && opponent.Weapon == SWORD_WEAPON);
    }
}