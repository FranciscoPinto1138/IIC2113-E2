namespace Fire_Emblem;

public class IncreaseExtraDamageByOpponentThirtyPercentTotalDefStat : ExtraDamageEffect
{
    public IncreaseExtraDamageByOpponentThirtyPercentTotalDefStat()
    {
        this.SetPriority(2);
    }
    
    public override void ApplyEffect(Unit unit, Unit opponent)
    {
        var opponentStatManager = new UnitStatsManager();
        unit.DamageEffectsManager.ExtraDamagePermanent += (int) Math.Floor(0.3 * opponentStatManager.GetUnitNonSpecificTotalDef(opponent));
    }
}