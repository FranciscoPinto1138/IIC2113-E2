namespace Fire_Emblem;

public class ChaosStyle : Bonus
{
    public ChaosStyle(Unit unit, Unit opponent) : base(unit, opponent)
    {
        this.Name = "Chaos Style";
        this.Description = "Si la unidad inicia el combate con un ataque físico contra un rival armado con magia, o viceversa, otorga Spd+3 durante el combate.";
        this.unit = unit;
        this.opponent = opponent;
    }

    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var baseCondition = new UnitStartsCombatCondition();
        var physicalWeaponTypeCondition = new UnitDamageTypeCondition(DamageType.Physical);
        var magicalWeaponTypeCondition = new UnitDamageTypeCondition(DamageType.Magical);
        var effectOnUnit = new IncreaseStat(3, StatType.Spd);
        if (baseCondition.IsConditionFulfilled(unit, opponent) && (DoUnitsHaveOppositeWeaponTypes(physicalWeaponTypeCondition, magicalWeaponTypeCondition)))
        {
            effectOnUnit.ApplyEffect(unit, opponent);
        }
    }

    private bool DoUnitsHaveOppositeWeaponTypes(Condition physicalWeaponTypeCondition, Condition magicalWeaponTypeCondition)
    {
        return ((physicalWeaponTypeCondition.IsConditionFulfilled(unit, opponent) && magicalWeaponTypeCondition.IsConditionFulfilled(opponent, unit)) ||
                (magicalWeaponTypeCondition.IsConditionFulfilled(unit, opponent) && physicalWeaponTypeCondition.IsConditionFulfilled(opponent, unit)));
    }
}