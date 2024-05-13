namespace Fire_Emblem;

public class OpponentHasWeaponTypeCondition : Condition
{
    private string _weaponType;

    public OpponentHasWeaponTypeCondition(string weaponType)
    {
        this._weaponType = weaponType;
        SetPriority(1);
    }

    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        return opponent.Weapon == _weaponType;
    }
}