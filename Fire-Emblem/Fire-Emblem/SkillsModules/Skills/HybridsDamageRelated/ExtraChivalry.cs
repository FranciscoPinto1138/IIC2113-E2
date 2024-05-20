namespace Fire_Emblem;

public class ExtraChivalry : Skill
{
    public ExtraChivalry()
    {
        this.Name = "Extra Chivalry";
        this.Description = "Al inicio del combate, si el HP del rival >= 50%, " +
                           "inflige Atk/Spd/Def-5 en el rival durante el combate. Reduce el daño " +
                           "de los ataques del rival durante el combate por un porcentaje = 50% del porcentaje " +
                           "de HP que le queda al rival al inicio del combate " +
                           "(Ejemplo: si el HP del rival = 75%, reduce el daño en un 37%) " +
                           "(Este porcentaje siempre será entero, para el ejemplo, se reducirá el daño en un 37%, " +
                           "nunca en un 37.5%) (Si el porcentaje del HP del rival no es entero, por ejemplo 37.5%, " +
                           "entonces se truncará al realizar los calculos de esta habilidad).";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { 
            new ConditionEffectPair(
                new OpponentHPCondition(50, ThresholdType.Percentage, ComparisonType.GreaterThanOrEqual), 
                new DecreaseOpponentStats([StatType.Atk, StatType.Spd, StatType.Def], [5, 5, 5])),
            new ConditionEffectPair(
                new NoCondition(),
                new ReduceReceivedPermanentDamageByPercentage(
                    (double) Math.Floor(100.0 * 0.5 * ((double)opponent.HPCurrent / opponent.HPMax)) / 100.0))
        };
    }
}