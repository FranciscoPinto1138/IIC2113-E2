namespace Fire_Emblem.SkillsModules.Skills.Hybrids;

public class LightAndDark : Hybrid
{
    public LightAndDark()
    {
        this.Name = "Light and Dark";
        this.Description = "Inflige Atk/Spd/Def/Res-5 en el rival, neutraliza los penaltis de la unidad y los bonus del rival.";
    }
    
    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var firstCondition = new NoCondition();
        var effectOnOpponent = new DecreaseStat(5, StatType.Atk);
        var effectOnOpponentAdditional = new DecreaseStat(5, StatType.Spd);
        var effectOnOpponentAdditional2 = new DecreaseStat(5, StatType.Def);
        var effectOnOpponentAdditional3 = new DecreaseStat(5, StatType.Res);
        var neutralizePenaltyStatsOnUnitEffect = new NeutralizePenaltyOnStats([StatType.Atk, StatType.Spd, StatType.Def, StatType.Res, StatType.HP]);
        var neutralizeBonusStatsOnRivalEffect = new NeutralizeBonusOnStats([StatType.Atk, StatType.Spd, StatType.Def, StatType.Res, StatType.HP]);
        if (firstCondition.IsConditionFulfilled(unit, opponent))
        {
            effectOnOpponent.ApplyEffect(opponent, unit);
            effectOnOpponentAdditional.ApplyEffect(opponent, unit);
            effectOnOpponentAdditional2.ApplyEffect(opponent, unit);
            effectOnOpponentAdditional3.ApplyEffect(opponent, unit);
            neutralizePenaltyStatsOnUnitEffect.ApplyEffect(unit, opponent);
            neutralizeBonusStatsOnRivalEffect.ApplyEffect(opponent, unit);
        }
    }
    
    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        var condition = new NoCondition();
        var effectOnOpponent = new DecreaseOpponentStats([StatType.Atk, StatType.Spd, StatType.Def, StatType.Res], [5, 5, 5, 5]);
        var effectOnOpponentAdditional = new NeutralizePenaltyOnStats([StatType.Atk, StatType.Spd, StatType.Def, StatType.Res, StatType.HP]);
        var effectOnOpponentAdditional2 = new NeutralizeOpponentBonusStats([StatType.Atk, StatType.Spd, StatType.Def, StatType.Res, StatType.HP]);
        return new ConditionEffectPair[] { new ConditionEffectPair(condition, effectOnOpponent),
            new ConditionEffectPair(condition, effectOnOpponentAdditional),
            new ConditionEffectPair(condition, effectOnOpponentAdditional2)};
    }
}