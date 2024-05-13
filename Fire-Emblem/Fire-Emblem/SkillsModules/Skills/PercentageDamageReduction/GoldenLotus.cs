namespace Fire_Emblem;

public class GoldenLotus : PercentageDamageReduction
{
    public GoldenLotus()
    {
        this.Name = "Golden Lotus";
        this.Description = "Reduce el daño del primer ataque del rival en un 50% si este hace daño físico.";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        var condition = new OpponentDamageTypeCondition(DamageType.Physical);
        var effectOnUnit = new ReduceReceivedPermanentDamageByPercentageOnOpponentFirstAttack(0.5);
        return new ConditionEffectPair[] { new ConditionEffectPair(condition, effectOnUnit) };
    }
}