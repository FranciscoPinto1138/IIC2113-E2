namespace Fire_Emblem;

public class LunarBrace : ExtraDamage
{
    public LunarBrace()
    {
        this.Name = "Lunar Brace";
        this.Description = "Si la unidad inicia el combate con un ataque físico, " +
                           "inflige daño extra=30% de la Def del rival en cada ataque.";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { new ConditionEffectPair(
            new AndPairCondition(
                new UnitDamageTypeCondition(DamageType.Physical), new UnitStartsCombatCondition()), 
            new IncreaseExtraDamageByOpponentThirtyPercentTotalDefStat()) 
        };
    }
}