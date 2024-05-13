namespace Fire_Emblem;

public class DamageEffectsManager
{
    public int ExtraDamagePermanent = 0; // TO DO: Think of better name than "permanent"
    public int ExtraDamageFirstAttack = 0;
    public int ExtraDamageFollowUp = 0;
    public double DamagePercentageReductionPermanent = 0;
    public double DamagePercentageReductionFirstAttack = 0;
    public double DamagePercentageReductionFollowUp = 0;
    public int DamageAbsoluteReductionPermanent = 0;
}

// Damage formula:
// baseExtraDamage = ExtraDamagePermanent + ExtraDamageFirstAttack * unit.IsOnFirstAttack + ExtraDamageFollowUp * unit.IsOnFollowUpAttack
// percentageReducedExtraDamage = baseExtraDamage * (1 - DamagePercentageReductionPermanent) * (1 - DamagePercentageReductionFirstAttack * unit.RivalIsOnFirstAttack) * (1 - DamagePercentageReductionFollowUp * RivalIsOnFollowUpAttack)
// finalDamage = percentageReducedExtraDamage - DamageAbsoluteReductionPermanent