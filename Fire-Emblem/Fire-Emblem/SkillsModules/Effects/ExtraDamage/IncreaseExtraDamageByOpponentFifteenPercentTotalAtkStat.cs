namespace Fire_Emblem;

public class IncreaseExtraDamageByOpponentFifteenPercentTotalAtkStat : ExtraDamageEffect
{
    public IncreaseExtraDamageByOpponentFifteenPercentTotalAtkStat()
    {
        this.SetPriority(2);
    }
    
    public override void ApplyEffect(Unit unit, Unit opponent)
    {
        var opponentStatManager = new UnitStatsManager();
        unit.DamageEffectsManager.ExtraDamagePermanent += (int) Math.Floor(0.15 * opponentStatManager.GetUnitNonSpecificTotalAtk(opponent));
    }
}