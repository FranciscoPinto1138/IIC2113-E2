using Fire_Emblem_View;
namespace Fire_Emblem;

public class Combat
{
    private Unit _attackUnit;
    private Unit _defenseUnit;
    private View _view;
    
    public Combat(Unit attacker, Unit defender,View view)
    {
        _attackUnit = attacker;
        _defenseUnit = defender;
        _view = view;
    }
    
    public Unit[] ResolveCombat()
    {
        SetWTBs();
        SetUnitRoles();
        IncreaseStartingCombatUnitsStats();
        ResolveSkills();
        AttackOrCounterAttack(_attackUnit, _defenseUnit);
        if (IsCombatOver())
        {
            WrapUpCombat();
            return [_attackUnit, _defenseUnit];
        }
        AttackOrCounterAttack(_defenseUnit, _attackUnit);
        if (IsCombatOver())
        {
            WrapUpCombat();
            return [_attackUnit, _defenseUnit];
        }
        FollowUp();
        if (IsCombatOver())
        {
            WrapUpCombat();
            return [_attackUnit, _defenseUnit];
        }
        WrapUpCombat();
        return [_attackUnit, _defenseUnit];
    }
    
    private void SetWTBs()
    {
        WeaponTriangle weaponTriangle = new WeaponTriangle(_attackUnit, _defenseUnit, _view);
        double[] WTBs = weaponTriangle.GetWTBsFromWeaponTriangle();
        _attackUnit.CurrentWTB = WTBs[0];
        _defenseUnit.CurrentWTB = WTBs[1];
    }

    private void SetUnitRoles()
    {
        const string ATTACKER_ROLE = "Attacker";
        const string DEFENDER_ROLE = "Defender";
        _attackUnit.Role = ATTACKER_ROLE;
        _defenseUnit.Role = DEFENDER_ROLE;
    }
    
    private void IncreaseStartingCombatUnitsStats()
    {
        _attackUnit.NumberOfTimesStartingCombat++;
        _defenseUnit.NumberOfTimesRivalStartsCombat++;
    }
    
    private void ResolveSkills()
    {
        SkillsController skillsController = new SkillsController(_attackUnit, _defenseUnit, _view);
        skillsController.CreateSkills();
        skillsController.ApplyUnitsSkillsEffectsIfConditionsAreSatisfiedByPriority();
        skillsController.ShowAllSkillsNetStatsOfUnitsAfterEffects();
    }
    
    private void AttackOrCounterAttack(Unit attacker, Unit defender)
    {
        new AttackCounterAttackController(attacker, defender, _view).AttackOrCounterAttack();
    }
    
    private bool IsCombatOver()
    {
        return HasUnitDied();
    }
    
    private void WrapUpCombat()
    {
        new CombatWrapper(_attackUnit, _defenseUnit, _view).WrapUpCombat();
    }
    
    private void FollowUp()
    {
        new FollowUpController(_attackUnit, _defenseUnit, _view).ResolveFollowUp();
    }
    
    private bool HasUnitDied()
    {
        return _attackUnit.HPCurrent <= 0 || _defenseUnit.HPCurrent <= 0;
    }
}