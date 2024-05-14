namespace Fire_Emblem;

public class LaguzFriend : Hybrid
{
    public LaguzFriend()
    {
        this.Name = "Laguz Friend";
        this.Description = "La unidad recibe 50% menos daño, pero neutraliza todo Bonus a Def y Res y reduce estos stats en un 50% de su base. (Considere esta reducción como un Penalty).";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        var condition = new NoCondition();
        var firstEffectOnUnit = new ReduceReceivedPermanentDamageByPercentage(0.5);
        var secondEffectOnUnit = new NeutralizeBonusOnStats([StatType.Def, StatType.Res]);
        var thirdEffectOnUnit = new DecreaseStats([StatType.Def, StatType.Res], [Convert.ToInt32(Math.Floor(0.5 * unit.Def)), Convert.ToInt32(Math.Floor(0.5 * unit.Res))]);
        return new ConditionEffectPair[] { new ConditionEffectPair(condition, firstEffectOnUnit),
            new ConditionEffectPair(condition, secondEffectOnUnit),
            new ConditionEffectPair(condition, thirdEffectOnUnit) };
    }
}