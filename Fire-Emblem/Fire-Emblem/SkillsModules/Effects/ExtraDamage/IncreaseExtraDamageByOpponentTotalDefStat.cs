namespace Fire_Emblem;

public class IncreaseExtraDamageByOpponentTotalDefStat : ExtraDamageEffect
{
    public IncreaseExtraDamageByOpponentTotalDefStat()
    {
        this.SetPriority(2);
    }
    
    public override void ApplyEffect(Unit unit, Unit opponent)
    {
        var opponentStatManager = new UnitStatsManager();
        unit.DamageEffectsManager.ExtraDamagePermanent += (int) Math.Floor(0.3 * opponentStatManager.GetUnitNonSpecificTotalDef(opponent));
    }
}