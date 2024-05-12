using System.Net.Mail;

namespace Fire_Emblem;

public class IncreaseExtraDamage : ExtraDamageEffect
{
    private int _changeFactor;
    
    public IncreaseExtraDamage(int changeFactor)
    {
        _changeFactor = changeFactor;
    }
    
    public void ApplyEffect(Unit unit, Unit opponent)
    {
        unit.DamageEffectsManager.ExtraDamagePermanent += _changeFactor;
    }
}