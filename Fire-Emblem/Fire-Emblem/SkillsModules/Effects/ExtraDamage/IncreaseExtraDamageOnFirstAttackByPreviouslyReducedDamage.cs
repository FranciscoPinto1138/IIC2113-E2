namespace Fire_Emblem;

public class IncreaseExtraDamageOnFirstAttackByPreviouslyReducedDamage : ExtraDamageEffect
{
    public IncreaseExtraDamageOnFirstAttackByPreviouslyReducedDamage()
    {
        this.SetPriority(5);
    }
    
    public override void ApplyEffect(Unit unit, Unit opponent)
    {
        DamageManager damageManager = new DamageManager(opponent, unit);
        unit.DamageEffectsManager.ExtraDamageFirstAttack += damageManager.GetReducedDamageOnFirstAttack();
    }
}