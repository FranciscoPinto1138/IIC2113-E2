namespace Fire_Emblem.Hybrids;

public class CloseDef : Hybrid
{
    public CloseDef()
    {
        this.Name = "Close Def";
        this.Description = "Si el rival inicia el combate usando espada, lanza o hacha, otorga Def/Res+8 y neutraliza los bonus del rival durante el combate.";
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