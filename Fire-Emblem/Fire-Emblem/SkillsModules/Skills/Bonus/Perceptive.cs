namespace Fire_Emblem;

public class Perceptive : Bonus
{
    public Perceptive()
    {
        this.Name = "Perceptive";
        this.Description = "Si la unidad inicia el combate, otorga Spd+12 a la unidad durante el combate, " +
                           "y por cada cuatro puntos de Spd (sin contar bonus), la unidad gana Spd+1 adicional.";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { 
            new ConditionEffectPair(
                new UnitStartsCombatCondition(), new IncreaseStat(12, StatType.Spd)), 
            new ConditionEffectPair(
                new UnitStartsCombatCondition(), new IncreaseSpdByBaseSpdStat(4))
        };
    }
}