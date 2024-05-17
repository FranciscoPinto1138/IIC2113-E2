using Fire_Emblem_View;

namespace Fire_Emblem;

public class FollowUpController
{
    private Unit _attackUnit;
    private Unit _defenseUnit;
    private UnitStatsManager _unitStatsManager = new UnitStatsManager();
    private View _view;
    private const int MIN_SPD_DIFFERENCE_FOR_FOLLOWUP = 5;

    public FollowUpController(Unit attackUnit, Unit defenseUnit, View view)
    {
        this._attackUnit = attackUnit;
        this._defenseUnit = defenseUnit;
        this._view = view;
    }
    
    public void ResolveFollowUp()
    {
        ResetFirstAttackBonusAndPenaltyStatsDiffOfUnits();
        if (AttackUnitCanFollowUp())
        {
            ResolveUnitFollowUp(_attackUnit, _defenseUnit);
        }
        if (DefenseUnitCanFollowUp())
        {
            ResolveUnitFollowUp(_defenseUnit, _attackUnit);
        }
        else if (!UnitsCanFollowUp())
        {
            _view.WriteLine("Ninguna unidad puede hacer un follow up");
        }
    }
    
    private void ResetFirstAttackBonusAndPenaltyStatsDiffOfUnits()
    {
        _unitStatsManager.ResetFirstAttackBonusAndPenaltyStatsDiff(_attackUnit);
        _unitStatsManager.ResetFirstAttackBonusAndPenaltyStatsDiff(_defenseUnit);
    }
    
    private bool AttackUnitCanFollowUp()
    {
        return _unitStatsManager.GetUnitTotalSpd(_attackUnit) - _unitStatsManager.GetUnitTotalSpd(_defenseUnit) >= MIN_SPD_DIFFERENCE_FOR_FOLLOWUP;
    }
    
    private bool DefenseUnitCanFollowUp()
    {
        return _unitStatsManager.GetUnitTotalSpd(_defenseUnit) - _unitStatsManager.GetUnitTotalSpd(_attackUnit) >= MIN_SPD_DIFFERENCE_FOR_FOLLOWUP;
    }
    
    private bool UnitsCanFollowUp()
    {
        return AttackUnitCanFollowUp() || DefenseUnitCanFollowUp();
    }
    
    private void ResolveUnitFollowUp(Unit attacker, Unit defender)
    {
        SetUnitsFollowUpStatus(attacker, defender);
        DamageManager damageManager = new DamageManager(attacker, defender);
        damageManager.ApplyDamage();
        ShowAppliedDamage(attacker, defender, damageManager);
        UnSetUnitsFollowUpStatus(attacker, defender);
    }
    
    private void SetUnitsFollowUpStatus(Unit unit, Unit opponent)
    {
        unit.IsOnFollowUpAttack = 1;
        opponent.RivalIsOnFollowUpAttack = 1;
    }
    
    private void ShowAppliedDamage(Unit attacker, Unit defender, DamageManager damageManager)
    {
        _view.WriteLine($"{attacker.Name} ataca a {defender.Name} con {damageManager.DetermineTotalDamageAfterEffects()} de daño");
    }
    
    private void UnSetUnitsFollowUpStatus(Unit unit, Unit opponent)
    {
        unit.IsOnFollowUpAttack = 0;
        opponent.RivalIsOnFollowUpAttack = 0;
    }
}