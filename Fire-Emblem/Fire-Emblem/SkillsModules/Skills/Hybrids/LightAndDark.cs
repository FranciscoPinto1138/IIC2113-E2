namespace Fire_Emblem.SkillsModules.Skills.Hybrids;

public class LightAndDark : Hybrid
{
    public LightAndDark(Unit unit, Unit opponent) : base(unit, opponent)
    {
        this.Name = "Light and Dark";
        this.Description = "Inflige Atk/Spd/Def/Res-5 en el rival, neutraliza los penaltis de la unidad y los bonus del rival.";
        this.unit = unit;
        this.opponent = opponent;
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
}