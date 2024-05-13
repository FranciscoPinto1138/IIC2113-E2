namespace Fire_Emblem;

public class ReduceReceivedPermanentDamageByPercentage : PercentageDamageReductionEffect
{
    private double _changeFactor;
    public ReduceReceivedPermanentDamageByPercentage(double changeFactor)
    {
        this._changeFactor = changeFactor;
        this.SetPriority(3);
    }

    public override void ApplyEffect(Unit unit, Unit opponent)
    {
        unit.DamageEffectsManager.DamagePercentageReductionPermanent =
            1 - ((1 - unit.DamageEffectsManager.DamagePercentageReductionPermanent) * (1 - _changeFactor));
    }
}