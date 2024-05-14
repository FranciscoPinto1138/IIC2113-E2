namespace Fire_Emblem;

public class DistantDef : Hybrid
{
    public DistantDef()
    {
        this.Name = "Distant Def";
        this.Description = "Si el rival inicia el combate usando magia o arco, otorga Def/Res+8 y neutraliza los bonus del rival durante el combate.";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        var unitStartsCombatCondition = new OpponentStartsCombatCondition();
        var magicOpponentCondition = new OpponentHasWeaponTypeCondition("Magic");
        var bowOpponentCondition = new OpponentHasWeaponTypeCondition("Bow");
        var combinedOrCondition = new OrPairCondition(magicOpponentCondition, bowOpponentCondition);
        var combinedAndCondition = new AndPairCondition(unitStartsCombatCondition, combinedOrCondition);
        var effectOnUnit = new IncreaseStats([StatType.Def, StatType.Res], [8, 8]);
        var effectOnOpponent = new NeutralizeOpponentBonusStats([StatType.Atk, StatType.Spd, StatType.Def, StatType.Res, StatType.HP]);
        return new ConditionEffectPair[] { new ConditionEffectPair(combinedAndCondition, effectOnUnit), new ConditionEffectPair(combinedAndCondition, effectOnOpponent) };
    }
}