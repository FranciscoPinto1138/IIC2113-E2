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
        return new ConditionEffectPair[]
        {
            new ConditionEffectPair(new OpponentDamageTypeCondition(DamageType.Physical), 
                new ReduceReceivedPermanentDamageByPercentageOnOpponentFirstAttack(0.5))
        };
    }
}