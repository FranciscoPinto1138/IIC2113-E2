namespace Fire_Emblem.Hybrids;

public class CloseDef : Hybrid
{
    public CloseDef()
    {
        this.Name = "Close Def";
        this.Description = "Si el rival inicia el combate usando espada, lanza o hacha, " +
                           "otorga Def/Res+8 y neutraliza los bonus del rival durante el combate.";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        Condition condition = new AndPairCondition(
            new OpponentStartsCombatCondition(), 
            new OrPairCondition(
                new OrPairCondition(
                    new OpponentHasWeaponTypeCondition("Sword"), new OpponentHasWeaponTypeCondition("Lance")), 
                new OpponentHasWeaponTypeCondition("Axe")));
        return new ConditionEffectPair[]
        {
            new ConditionEffectPair( 
                condition, 
                new IncreaseStats([StatType.Def, StatType.Res], [8, 8])), 
            new ConditionEffectPair(
                condition, 
                new NeutralizeOpponentBonusStats([StatType.Atk, StatType.Spd, StatType.Def, 
                    StatType.Res, StatType.HP]))
        };
    }
}