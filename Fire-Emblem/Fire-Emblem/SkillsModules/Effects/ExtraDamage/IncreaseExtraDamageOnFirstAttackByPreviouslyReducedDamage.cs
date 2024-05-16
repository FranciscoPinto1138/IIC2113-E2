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
        Console.WriteLine($"Daño extra de {unit.Name} (reducido): {damageManager.GetReducedDamageOnFirstAttack()}");
        Console.WriteLine($"{unit.Name} En primer ataque");
        unit.DamageEffectsManager.ExtraDamageFirstAttack += damageManager.GetReducedDamageOnFirstAttack();
    }
}