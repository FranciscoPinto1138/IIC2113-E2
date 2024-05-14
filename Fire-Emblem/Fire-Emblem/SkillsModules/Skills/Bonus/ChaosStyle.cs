namespace Fire_Emblem;

public class ChaosStyle : Bonus
{
    public ChaosStyle()
    {
        this.Name = "Chaos Style";
        this.Description = "Si la unidad inicia el combate con un ataque físico contra un rival armado con magia, o viceversa, otorga Spd+3 durante el combate.";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        var baseCondition = new UnitStartsCombatCondition();
        var oppositeWeaponTypesCondition = new UnitsHaveOppositeDamageTypes();
        var combinedAndCondition = new AndPairCondition(baseCondition, oppositeWeaponTypesCondition);
        var effect = new IncreaseStat(3, StatType.Spd);
        return new ConditionEffectPair[] { new ConditionEffectPair(combinedAndCondition, effect) };
    }
}