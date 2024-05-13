namespace Fire_Emblem;

public class UnitsHaveOppositeDamageTypes : Condition
{
    public UnitsHaveOppositeDamageTypes()
    {
        SetPriority(1);
    }
    
    public override bool IsConditionFulfilled(Unit unit, Unit opponent)
    {
        var physicalWeaponTypeCondition = new UnitDamageTypeCondition(DamageType.Physical);
        var magicalWeaponTypeCondition = new UnitDamageTypeCondition(DamageType.Magical);
        return ((physicalWeaponTypeCondition.IsConditionFulfilled(unit, opponent) && magicalWeaponTypeCondition.IsConditionFulfilled(opponent, unit)) ||
                (magicalWeaponTypeCondition.IsConditionFulfilled(unit, opponent) && physicalWeaponTypeCondition.IsConditionFulfilled(opponent, unit)));
    }
}