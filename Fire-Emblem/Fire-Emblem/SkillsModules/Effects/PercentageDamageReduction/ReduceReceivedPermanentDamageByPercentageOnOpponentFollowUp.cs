namespace Fire_Emblem;

public class ReduceReceivedPermanentDamageByPercentageOnOpponentFollowUp : PercentageDamageReductionEffect
{
    private double _changeFactor;
    public ReduceReceivedPermanentDamageByPercentageOnOpponentFollowUp(double changeFactor)
    {
        this._changeFactor = changeFactor;
        this.SetPriority(3);
    }

    public override void ApplyEffect(Unit unit, Unit opponent)
    {
        unit.DamageEffectsManager.DamagePercentageReductionFollowUp =
            1 - ((1 - unit.DamageEffectsManager.DamagePercentageReductionFollowUp) * (1 - _changeFactor));
    }
}