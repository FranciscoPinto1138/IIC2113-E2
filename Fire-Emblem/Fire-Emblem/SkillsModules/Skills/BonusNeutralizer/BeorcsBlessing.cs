namespace Fire_Emblem;

public class BeorcsBlessing : BonusNeutralizer
{
    public BeorcsBlessing()
    {
        this.Name = "Beorc's Blessing";
        this.Description = "Neutraliza los bonus del rival durante el combate.";
    }
    
    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        var condition = new NoCondition();
        var effectOnOpponent = new NeutralizeOpponentBonusStats([StatType.Atk, StatType.Spd, StatType.Def, StatType.Res, StatType.HP]);
        return new ConditionEffectPair[] { new ConditionEffectPair(condition, effectOnOpponent) };
    }
}