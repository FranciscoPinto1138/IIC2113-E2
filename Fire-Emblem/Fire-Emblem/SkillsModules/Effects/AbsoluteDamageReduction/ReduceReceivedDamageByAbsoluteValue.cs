namespace Fire_Emblem;

public class ReduceReceivedDamageByAbsoluteValue : Effect
{
    private int _changeFactor;

    public ReduceReceivedDamageByAbsoluteValue(int changeFactor)
    {
        this._changeFactor = changeFactor;
        this.SetPriority(4);
    }

    public override void ApplyEffect(Unit unit, Unit opponent)
    {
        unit.DamageEffectsManager.DamageAbsoluteReductionPermanent += _changeFactor;
    }
}