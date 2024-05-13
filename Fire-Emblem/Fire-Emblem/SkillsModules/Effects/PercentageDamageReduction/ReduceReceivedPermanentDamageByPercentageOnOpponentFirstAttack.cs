namespace Fire_Emblem;

public class ReduceReceivedPermanentDamageByPercentageOnOpponentFirstAttack : PercentageDamageReductionEffect
{
    private double _changeFactor;
    public ReduceReceivedPermanentDamageByPercentageOnOpponentFirstAttack(double changeFactor)
    {
        this._changeFactor = changeFactor;
        this.SetPriority(3);
    }

    public override void ApplyEffect(Unit unit, Unit opponent)
    {
        unit.DamageEffectsManager.DamagePercentageReductionFirstAttack =
            1 - ((1 - unit.DamageEffectsManager.DamagePercentageReductionFirstAttack) * (1 - _changeFactor));
    }
}