namespace Fire_Emblem;

public class Perceptive : Bonus
{
    public Perceptive()
    {
        this.Name = "Perceptive";
        this.Description = "Si la unidad inicia el combate, otorga Spd+12 a la unidad durante el combate, y por cada cuatro puntos de Spd (sin contar bonus), la unidad gana Spd+1 adicional.";
    }
    
    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var condition = new UnitStartsCombatCondition();
        var effectOnUnit = new IncreaseStat(12, StatType.Spd);
        var effectOnUnitAdditional = new IncreaseSpdByBaseSpdStat(4);
        if (condition.IsConditionFulfilled(unit, opponent))
        {
            effectOnUnit.ApplyEffect(unit, opponent);
            effectOnUnitAdditional.ApplyEffect(unit, opponent);
        }
    }
    
    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        var condition = new UnitStartsCombatCondition();
        var effectOnUnit = new IncreaseStat(12, StatType.Spd);
        var effectOnUnitAdditional = new IncreaseSpdByBaseSpdStat(4);
        return new ConditionEffectPair[] { new ConditionEffectPair(condition, effectOnUnit), 
            new ConditionEffectPair(condition, effectOnUnitAdditional)};
    }
}