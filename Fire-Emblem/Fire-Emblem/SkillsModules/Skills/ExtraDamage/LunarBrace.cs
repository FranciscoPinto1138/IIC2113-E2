namespace Fire_Emblem;

public class LunarBrace : ExtraDamage
{
    public LunarBrace()
    {
        this.Name = "Lunar Brace";
        this.Description = "Si la unidad inicia el combate con un ataque físico, inflige daño extra=30% de la Def del rival en cada ataque.";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        var firstCondition = new UnitDamageTypeCondition(DamageType.Physical);
        var secondCondition = new UnitStartsCombatCondition();
        var andCombinedCondition = new AndPairCondition(firstCondition, secondCondition);
        var effectOnUnit = new IncreaseExtraDamageByOpponentThirtyPercentTotalDefStat();
        return new ConditionEffectPair[] { new ConditionEffectPair(andCombinedCondition, effectOnUnit) };
    }
}