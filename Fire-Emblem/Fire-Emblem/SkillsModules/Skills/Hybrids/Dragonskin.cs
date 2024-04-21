namespace Fire_Emblem.SkillsModules.Skills.Hybrids;

public class Dragonskin : Hybrid
{
    public Dragonskin(Unit unit, Unit opponent) : base(unit, opponent)
    {
        this.Name = "Dragonskin";
        this.Description = "Si el rival inicia el combate o si el HP del rival >= 75% al inicio del combate, otorga Atk/Spd/Def/Res+6 a la unidad durante el combate y neutraliza los bonus del rival.";
        this.unit = unit;
        this.opponent = opponent;
    }
    
    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var firstCondition = new UnitStartsCombatCondition();
        var secondCondition = new UnitHPCondition(75, ThresholdType.Percentage, ComparisonType.GreaterThanOrEqual);
        var effectOnUnit = new StatBuffer(unit, opponent, [StatType.Atk, StatType.Spd, StatType.Def, StatType.Res], [6, 6, 6, 6]);
        var neutralizeStatsOnRivalEffect = new NeutralizeBonusOnStats([StatType.Atk, StatType.Spd, StatType.Def, StatType.Res, StatType.HP]);
        if (firstCondition.IsConditionFulfilled(opponent, unit) || secondCondition.IsConditionFulfilled(opponent, unit))
        {
            effectOnUnit.ApplyEffectsIfConditionsAreSatisfied(unit, opponent);
            neutralizeStatsOnRivalEffect.ApplyEffect(opponent, unit);
        }
    }
}