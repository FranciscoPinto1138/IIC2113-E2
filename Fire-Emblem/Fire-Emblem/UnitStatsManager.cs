namespace Fire_Emblem;

public class UnitStatsManager
{
    public int GetUnitTotalAtk(Unit unit)
    {
        return Convert.ToInt32(Math.Floor((double) (unit.Atk +
                                                    (unit.BonusStatsDiff.Atk + unit.FirstAttackBonusStatsDiff.Atk * unit.IsOnFirstAttack + unit.FollowUpAttackBonusStatsDiff.Atk * unit.IsOnFollowUpAttack) * unit.BonusNeutralizationManager.Atk 
                                                    + (unit.PenaltyStatsDiff.Atk + unit.FirstAttackPenaltyStatsDiff.Atk * unit.RivalIsOnFirstAttack + unit.FollowUpAttackPenaltyStatsDiff.Atk * unit.IsOnFollowUpAttack) * unit.PenaltyNeutralizationManager.Atk)));
    }
    
    public int GetUnitTotalSpd(Unit unit)
    {
        return unit.Spd + unit.BonusStatsDiff.Spd * unit.BonusNeutralizationManager.Spd + unit.PenaltyStatsDiff.Spd * unit.PenaltyNeutralizationManager.Spd;
    }
    
    public int GetUnitTotalDef(Unit unit)
    {
        return Convert.ToInt32(Math.Floor((double) (unit.Def +
                                                    (unit.BonusStatsDiff.Def + unit.FirstAttackBonusStatsDiff.Def * unit.IsOnFirstAttack + unit.FollowUpAttackBonusStatsDiff.Def * unit.IsOnFollowUpAttack) * unit.BonusNeutralizationManager.Def 
                                                    + (unit.PenaltyStatsDiff.Def + unit.FirstAttackPenaltyStatsDiff.Def * unit.RivalIsOnFirstAttack + unit.FollowUpAttackPenaltyStatsDiff.Def * unit.IsOnFollowUpAttack) * unit.PenaltyNeutralizationManager.Def)));
    }
    
    public int GetUnitTotalRes(Unit unit)
    {
        return Convert.ToInt32(Math.Floor((double) (unit.Res +
                                                    (unit.BonusStatsDiff.Res + unit.FirstAttackBonusStatsDiff.Res * unit.IsOnFirstAttack + unit.FollowUpAttackBonusStatsDiff.Res * unit.IsOnFollowUpAttack) * unit.BonusNeutralizationManager.Res 
                                                    + (unit.PenaltyStatsDiff.Res + unit.FirstAttackPenaltyStatsDiff.Res * unit.RivalIsOnFirstAttack + unit.FollowUpAttackPenaltyStatsDiff.Res * unit.IsOnFollowUpAttack) * unit.PenaltyNeutralizationManager.Res)));
    }
    
    public void ResetAllBonusAndPenaltyStatsDiff(Unit unit)
    {
        ResetBonusAndPenaltyStatsDiff(unit);
        ResetBonusAndPenaltyNeutralizationManager(unit);
        ResetFirstAttackBonusAndPenaltyStatsDiff(unit);
        ResetFollowUpAttackBonusAndPenaltyStatsDiff(unit);
    }
    
    private void ResetBonusAndPenaltyStatsDiff(Unit unit)
    {
        unit.BonusStatsDiff = new StatsDiff();
        unit.PenaltyStatsDiff = new StatsDiff();
    }
    
    private void ResetBonusAndPenaltyNeutralizationManager(Unit unit)
    {
        unit.BonusNeutralizationManager = new BonusNeutralizationManager();
        unit.PenaltyNeutralizationManager = new PenaltyNeutralizationManager();
    }
    
    public void ResetFirstAttackBonusAndPenaltyStatsDiff(Unit unit)
    {
        unit.FirstAttackBonusStatsDiff = new StatsDiff();
        unit.FirstAttackPenaltyStatsDiff = new StatsDiff();
    }

    private void ResetFollowUpAttackBonusAndPenaltyStatsDiff(Unit unit)
    {
        unit.FollowUpAttackBonusStatsDiff = new StatsDiff();
        unit.FollowUpAttackPenaltyStatsDiff = new StatsDiff();
    }
}