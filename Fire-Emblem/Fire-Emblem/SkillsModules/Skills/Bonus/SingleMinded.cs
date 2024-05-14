namespace Fire_Emblem;

public class SingleMinded : Bonus
{
    public SingleMinded()
    {
        this.Name = "Single-Minded";
        this.Description = "En un combate contra un rival que también es el oponente más reciente de la unidad, otorga Atk+8 a la unidad durante el combate.";
    }
    
    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        var condition = new OpponentIsMostRecentRivalOfUnitCondition();
        var effectOnUnit = new IncreaseStat(8, StatType.Atk);
        return new ConditionEffectPair[] { new ConditionEffectPair(condition, effectOnUnit) };
    }
}