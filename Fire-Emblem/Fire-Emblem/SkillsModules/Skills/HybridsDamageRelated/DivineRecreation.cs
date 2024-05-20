namespace Fire_Emblem;

public class DivineRecreation : Skill
{
    public DivineRecreation()
    {
        this.Name = "Divine Recreation";
        this.Description = "Al inicio del combate, si el HP del rival >= 50%, " +
                           "inflige Atk/Spd/Def/Res-4 en el rival durante el combate, reduce el daño " +
                           "del primer ataque del rival durante el combate en un 30% y hace daño extra " +
                           "en el siguiente ataque de la unidad por el total reducido en el primer ataque " +
                           "del rival (por cualquier medio, incluyendo otras habilidades). " +
                           "Reinicia al final del combate.";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        const string ROLE_TO_START_COMBAT = "Attacker";
        if (unit.Role == ROLE_TO_START_COMBAT)
        {
            return new ConditionEffectPair[] { 
                new ConditionEffectPair(
                    new OpponentHPCondition(50, ThresholdType.Percentage, ComparisonType.GreaterThanOrEqual), 
                    new DecreaseOpponentStats([StatType.Atk, StatType.Spd, StatType.Def, StatType.Res], [4, 4, 4, 4])),
                new ConditionEffectPair(
                    new OpponentHPCondition(50, ThresholdType.Percentage, ComparisonType.GreaterThanOrEqual), 
                    new ReduceReceivedPermanentDamageByPercentageOnOpponentFirstAttack(0.3)),
                new ConditionEffectPair(
                    new OpponentHPCondition(50, ThresholdType.Percentage, ComparisonType.GreaterThanOrEqual), 
                    new IncreaseExtraDamageOnFollowUpByPreviouslyReducedDamage())
            };
        }
        else
        {
            return new ConditionEffectPair[] { 
                new ConditionEffectPair(
                    new OpponentHPCondition(50, ThresholdType.Percentage, ComparisonType.GreaterThanOrEqual), 
                    new DecreaseOpponentStats([StatType.Atk, StatType.Spd, StatType.Def, StatType.Res], [4, 4, 4, 4])),
                new ConditionEffectPair(
                    new OpponentHPCondition(50, ThresholdType.Percentage, ComparisonType.GreaterThanOrEqual), 
                    new ReduceReceivedPermanentDamageByPercentageOnOpponentFirstAttack(0.3)),
                new ConditionEffectPair(
                    new OpponentHPCondition(50, ThresholdType.Percentage, ComparisonType.GreaterThanOrEqual), 
                    new IncreaseExtraDamageOnFirstAttackByPreviouslyReducedDamage())
            };;
        }
    }
}