namespace Fire_Emblem;

public class DistantDef : Hybrid
{
    public DistantDef()
    {
        this.Name = "Distant Def";
        this.Description = "Si el rival inicia el combate usando magia o arco, otorga Def/Res+8 " +
                           "y neutraliza los bonus del rival durante el combate.";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        Condition combinedAndCondition = new AndPairCondition(
            new OpponentStartsCombatCondition(), 
            new OrPairCondition(
                new OpponentHasWeaponTypeCondition("Magic"), 
                new OpponentHasWeaponTypeCondition("Bow")));
        return new ConditionEffectPair[]
        {
            new ConditionEffectPair(combinedAndCondition, 
                new IncreaseStats([StatType.Def, StatType.Res], [8, 8])), 
            new ConditionEffectPair(combinedAndCondition, 
                new NeutralizeOpponentBonusStats([StatType.Atk, StatType.Spd, StatType.Def,
                    StatType.Res, StatType.HP]))
        };
    }
}