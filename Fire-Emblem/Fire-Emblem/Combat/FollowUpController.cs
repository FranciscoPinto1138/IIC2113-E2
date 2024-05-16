using Fire_Emblem_View;

namespace Fire_Emblem;

public class FollowUpController
{
    private Unit _attackUnit;
    private Unit _defenseUnit;
    private UnitStatsManager _unitStatsManager = new UnitStatsManager();
    private View _view;

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
        const int minimumSpdDifferenceForFollowUp = 5;
        return _unitStatsManager.GetUnitTotalSpd(_attackUnit) - _unitStatsManager.GetUnitTotalSpd(_defenseUnit) >= minimumSpdDifferenceForFollowUp;
    }
    
    private bool DefenseUnitCanFollowUp()
    {
        const int minimumSpdDifferenceForFollowUp = 5;
        return _unitStatsManager.GetUnitTotalSpd(_defenseUnit) - _unitStatsManager.GetUnitTotalSpd(_attackUnit) >= minimumSpdDifferenceForFollowUp;
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
        _view.WriteLine($"{attacker.Name} ataca a {defender.Name} con {damageManager.GetTotalDamage()} de daño");
        UnSetUnitsFollowUpStatus(attacker, defender);
    }
    
    private void SetUnitsFollowUpStatus(Unit unit, Unit opponent)
    {
        unit.IsOnFollowUpAttack = 1;
        opponent.RivalIsOnFollowUpAttack = 1;
    }
    
    private void UnSetUnitsFollowUpStatus(Unit unit, Unit opponent)
    {
        unit.IsOnFollowUpAttack = 0;
        opponent.RivalIsOnFollowUpAttack = 0;
    }
}