namespace Fire_Emblem;

public class UnitHasWeaponTypeCondition : Condition
{
    private string _weaponType;

    public UnitHasWeaponTypeCondition(string weaponType)
    {
        this._weaponType = weaponType;
        SetPriority(1);
    }

    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        return unit.Weapon == _weaponType;
    }
}