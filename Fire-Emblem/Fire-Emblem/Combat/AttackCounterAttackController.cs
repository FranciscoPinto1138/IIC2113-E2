using Fire_Emblem_View;
namespace Fire_Emblem;

public class AttackCounterAttackController
{
    private Unit _attackUnit;
    private Unit _defenseUnit;
    private View _view;
    
    public AttackCounterAttackController(Unit attackUnit, Unit defenseUnit, View view)
    {
        this._attackUnit = attackUnit;
        this._defenseUnit = defenseUnit;
        this._view = view;
    }
    
    public void AttackOrCounterAttack()
    {
        SetUnitsFirstAttackStatus();
        DamageManager damageManager = new DamageManager(_attackUnit, _defenseUnit);
        damageManager.ApplyDamage();
        ShowAppliedDamage(damageManager);
        UnSetUnitsFirstAttackStatus();
    }
    
    private void SetUnitsFirstAttackStatus()
    {
        _attackUnit.IsOnFirstAttack = 1;
        _defenseUnit.RivalIsOnFirstAttack = 1;
    }
    
    private void ShowAppliedDamage(DamageManager damageManager)
    {
        _view.WriteLine($"{_attackUnit.Name} ataca a {_defenseUnit.Name} con {damageManager.DetermineTotalDamageAfterEffects()} de daño");
    }
    
    private void UnSetUnitsFirstAttackStatus()
    {
        _attackUnit.IsOnFirstAttack = 0;
        _defenseUnit.RivalIsOnFirstAttack = 0;
    }
}