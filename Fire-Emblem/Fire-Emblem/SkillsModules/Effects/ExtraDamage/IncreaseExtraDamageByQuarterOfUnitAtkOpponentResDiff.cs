namespace Fire_Emblem;

public class IncreaseExtraDamageByQuarterOfUnitAtkOpponentResDiff : ExtraDamageEffect
{
    public IncreaseExtraDamageByQuarterOfUnitAtkOpponentResDiff()
    {
        this.SetPriority(2);
    }
    
    public override void ApplyEffect(Unit unit, Unit opponent)
    {
        var statManager = new UnitStatsManager();
        unit.DamageEffectsManager.ExtraDamageFirstAttack += (int) Math.Floor(
            0.25 * (statManager.GetUnitNonSpecificTotalAtk(unit) - statManager.GetUnitNonSpecificTotalRes(opponent)));
    }
}