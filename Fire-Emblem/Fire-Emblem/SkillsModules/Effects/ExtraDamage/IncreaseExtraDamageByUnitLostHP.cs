namespace Fire_Emblem;

public class IncreaseExtraDamageByUnitLostHP : ExtraDamageEffect
{
    public IncreaseExtraDamageByUnitLostHP()
    {
        this.SetPriority(2);
    }
    
    public override void ApplyEffect(Unit unit, Unit opponent)
    {
        unit.DamageEffectsManager.ExtraDamagePermanent += (int) Math.Floor(0.5 * (unit.HPMax - unit.HPCurrent));
    } 
}