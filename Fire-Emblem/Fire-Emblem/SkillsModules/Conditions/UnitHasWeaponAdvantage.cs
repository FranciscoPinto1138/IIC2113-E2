namespace Fire_Emblem;

public class UnitHasWeaponAdvantage : Condition
{
    public UnitHasWeaponAdvantage()
    {
        SetPriority(1);
    }

    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        return (unit.Weapon == "Sword" && opponent.Weapon == "Axe") ||
               (unit.Weapon == "Axe" && opponent.Weapon == "Lance") ||
               (unit.Weapon == "Lance" && opponent.Weapon == "Sword");
    }
}