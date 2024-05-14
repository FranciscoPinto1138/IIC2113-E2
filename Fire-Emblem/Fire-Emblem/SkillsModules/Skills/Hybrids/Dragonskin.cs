namespace Fire_Emblem.SkillsModules.Skills.Hybrids;

public class Dragonskin : Hybrid
{
    public Dragonskin()
    {
        this.Name = "Dragonskin";
        this.Description = "Si el rival inicia el combate o si el HP del rival >= 75% al inicio del combate, otorga Atk/Spd/Def/Res+6 a la unidad durante el combate y neutraliza los bonus del rival.";
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