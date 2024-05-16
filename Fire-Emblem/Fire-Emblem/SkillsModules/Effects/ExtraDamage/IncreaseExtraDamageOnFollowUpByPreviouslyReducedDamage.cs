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
        Console.WriteLine($"Daño extra de {unit.Name} (reducido): {damageManager.GetReducedDamageOnFirstAttack()}");
        Console.WriteLine($"{unit.Name} en Follow-Up");
        unit.DamageEffectsManager.ExtraDamageFollowUp += damageManager.GetReducedDamageOnFirstAttack();
    }
}