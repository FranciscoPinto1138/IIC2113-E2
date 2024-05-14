namespace Fire_Emblem.SkillsModules.Skills.Hybrids;

public class Dragonskin : Hybrid
{
    public Dragonskin()
    {
        this.Name = "Dragonskin";
        this.Description = "Si el rival inicia el combate o si el HP del rival >= 75% al inicio del combate, otorga Atk/Spd/Def/Res+6 a la unidad durante el combate y neutraliza los bonus del rival.";
    }
    
    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var firstCondition = new UnitStartsCombatCondition();
        var secondCondition = new UnitHPCondition(75, ThresholdType.Percentage, ComparisonType.GreaterThanOrEqual);
        var effectOnUnit = new StatBuffer([StatType.Atk, StatType.Spd, StatType.Def, StatType.Res], [6, 6, 6, 6]);
        var neutralizeStatsOnRivalEffect = new NeutralizeBonusOnStats([StatType.Atk, StatType.Spd, StatType.Def, StatType.Res, StatType.HP]);
        if (firstCondition.IsConditionFulfilled(opponent, unit) || secondCondition.IsConditionFulfilled(opponent, unit))
        {
            effectOnUnit.ApplyEffectsIfConditionsAreSatisfied(unit, opponent);
            neutralizeStatsOnRivalEffect.ApplyEffect(opponent, unit);
        }
    }
    
    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[]
        {
            new ConditionEffectPair(
                new OrPairCondition(
                    new OpponentStartsCombatCondition(), 
                    new OpponentHPCondition(75, ThresholdType.Percentage, ComparisonType.GreaterThanOrEqual)),
                new IncreaseStats([StatType.Atk, StatType.Spd, StatType.Def, StatType.Res], [6, 6, 6, 6])), 
            new ConditionEffectPair(
                new OrPairCondition(
                    new OpponentStartsCombatCondition(), 
                    new OpponentHPCondition(75, ThresholdType.Percentage, ComparisonType.GreaterThanOrEqual)), 
                new NeutralizeOpponentBonusStats([StatType.Atk, StatType.Spd, StatType.Def, StatType.Res, StatType.HP]))
        };
    }
}