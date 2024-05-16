namespace Fire_Emblem;

public class IncreaseExtraDamageOnFollowUpByPreviouslyReducedDamage : ExtraDamageEffect
{
    public IncreaseExtraDamageOnFollowUpByPreviouslyReducedDamage()
    {
        this.SetPriority(6);
    }
    
    public override void ApplyEffect(Unit unit, Unit opponent)
    {
        DamageManager damageManager = new DamageManager(opponent, unit);
        unit.DamageEffectsManager.ExtraDamageFollowUp += damageManager.GetReducedDamageOnFirstAttack();
    }
}