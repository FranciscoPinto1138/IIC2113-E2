namespace Fire_Emblem.Hybrids;

public class CloseDef : Hybrid
{
    public CloseDef()
    {
        this.Name = "Close Def";
        this.Description = "Si el rival inicia el combate usando espada, lanza o hacha, otorga Def/Res+8 y neutraliza los bonus del rival durante el combate.";
    }
    
    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var firstCondition = new UnitHasWeaponTypeCondition("Sword");
        var secondCondition = new UnitHasWeaponTypeCondition("Lance");
        var thirdCondition = new UnitHasWeaponTypeCondition("Axe");
        var fourthCondition = new UnitStartsCombatCondition();
        var effectOnUnit = new IncreaseStat(8, StatType.Def);
        var effectOnUnitAdditional = new IncreaseStat(8, StatType.Res);
        var neutralizeStatsOnRivalEffect = new NeutralizeBonusOnStats([StatType.Atk, StatType.Spd, StatType.Def, StatType.Res, StatType.HP]);
        if (!fourthCondition.IsConditionFulfilled(opponent, unit) ||
            (!firstCondition.IsConditionFulfilled(opponent, unit) &&
             !secondCondition.IsConditionFulfilled(opponent, unit) &&
             !thirdCondition.IsConditionFulfilled(opponent, unit))) return;
        effectOnUnit.ApplyEffect(unit, opponent);
        effectOnUnitAdditional.ApplyEffect(unit, opponent);
        neutralizeStatsOnRivalEffect.ApplyEffect(opponent, unit);
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        var unitStartsCombatCondition = new OpponentStartsCombatCondition();
        var swordOpponentCondition = new OpponentHasWeaponTypeCondition("Sword");
        var lanceOpponentCondition = new OpponentHasWeaponTypeCondition("Lance");
        var axeOpponentCondition = new OpponentHasWeaponTypeCondition("Axe");
        var firstCombinedOrCondition = new OrPairCondition(swordOpponentCondition, lanceOpponentCondition);
        var secondCombinedOrCondition = new OrPairCondition(firstCombinedOrCondition, axeOpponentCondition);
        var combinedAndCondition = new AndPairCondition(unitStartsCombatCondition, secondCombinedOrCondition);
        var effectOnUnit = new IncreaseStats([StatType.Def, StatType.Res], [8, 8]);
        var effectOnOpponent = new NeutralizeOpponentBonusStats([StatType.Atk, StatType.Spd, StatType.Def, StatType.Res, StatType.HP]);
        return new ConditionEffectPair[] { new ConditionEffectPair(combinedAndCondition, effectOnUnit), new ConditionEffectPair(combinedAndCondition, effectOnOpponent) };
    }
}