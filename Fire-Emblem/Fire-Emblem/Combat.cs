using Fire_Emblem_View;
namespace Fire_Emblem;

public class Combat
{
    private Unit _attackUnit;
    private Team _attackerTeam;
    private Unit _defenseUnit;
    private Team _defenderTeam;
    private View _view;
    private UnitStatsManager _unitStatsManager = new UnitStatsManager();
    
    public Combat(Unit attacker, Unit defender, Team attackerTeam, Team defenderTeam ,View view)
    {
        _attackUnit = attacker;
        _defenseUnit = defender;
        _attackerTeam = attackerTeam;
        _defenderTeam = defenderTeam;
        _view = view;
    }
    
    private int DetermineResOrDef(Unit unit, Unit opponentUnit)
    {
        return opponentUnit.Weapon == "Magic" ? _unitStatsManager.GetUnitTotalRes(unit) : _unitStatsManager.GetUnitTotalDef(unit);
    }
    
    private int DetermineDamage(Unit damageMaker, double damageMakerWTB, int defOrRes)
    {
        int initialDamage = Convert.ToInt32(Math.Max(0, Math.Floor((_unitStatsManager.GetUnitTotalAtk(damageMaker) * damageMakerWTB) - defOrRes)));
        return initialDamage + damageMaker.DamageEffectsManager.ExtraDamagePermanent;
    }
    
    private void ResetUnitsBonusAndPenaltyStatsDiff()
    {
        _unitStatsManager.ResetAllBonusAndPenaltyStatsDiff(_attackUnit);
        _unitStatsManager.ResetAllBonusAndPenaltyStatsDiff(_defenseUnit);
    }

    private void ResetUnitsExtraDamage()
    {
        _attackUnit.DamageEffectsManager = new DamageEffectsManager();
        _defenseUnit.DamageEffectsManager = new DamageEffectsManager();
    }
    
    private void ApplyDamage(Unit damageMaker, Unit damageReceiver, double damageMakerWTB)
    {
        int defOrRes = DetermineResOrDef(damageReceiver, damageMaker);
        int damage = DetermineDamage(damageMaker, damageMakerWTB, defOrRes);
        damageReceiver.HPCurrent -= damage;
        _view.WriteLine($"{damageMaker.Name} ataca a {damageReceiver.Name} con {damage} de daño");
    }
    
    private bool CheckIfUnitDied()
    {
        return _attackUnit.HPCurrent <= 0 || _defenseUnit.HPCurrent <= 0;
    }
    
    private void SetUnitsHPToMinimumIfNegative()
    {
        const int minimumHPofUnit = 0;
        _attackUnit.HPCurrent = Math.Max(minimumHPofUnit, _attackUnit.HPCurrent);
        _defenseUnit.HPCurrent = Math.Max(minimumHPofUnit, _defenseUnit.HPCurrent);
    }

    private void WrapUpCombat()
    {
        SetUnitsHPToMinimumIfNegative();
        ResetUnitsBonusAndPenaltyStatsDiff();
        ResetUnitsExtraDamage();
        ShowCombatResults();
    }
    
    private void SetUnitsFirstAttackStatus(Unit unit, Unit opponent)
    {
        unit.IsOnFirstAttack = 1;
        opponent.RivalIsOnFirstAttack = 1;
    }
    
    private void UnSetUnitsFirstAttackStatus(Unit unit, Unit opponent)
    {
        unit.IsOnFirstAttack = 0;
        opponent.RivalIsOnFirstAttack = 0;
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
    
    private void UpdateUnitsFollowUpData(Unit unit, Unit opponent)
    {
        _unitStatsManager.ResetFirstAttackBonusAndPenaltyStatsDiff(unit);
        UnSetUnitsFollowUpStatus(unit, opponent);
    }

    private void FollowUp(double WTBAttacker, double WTBDefender)
    {
        ResetFirstAttackBonusAndPenaltyStatsDiffOfUnits();
        if (AttackUnitCanFollowUp())
        {
            ResolveUnitFollowUp(_attackUnit, _defenseUnit, WTBAttacker);
        }
        if (DefenseUnitCanFollowUp())
        {
            ResolveUnitFollowUp(_defenseUnit, _attackUnit, WTBDefender);
        }
        else if (!UnitsCanFollowUp())
        {
            _view.WriteLine("Ninguna unidad puede hacer un follow up");
        }
    }
    
    private void ResolveUnitFollowUp(Unit attacker, Unit defender, double WTBAttacker)
    {
        SetUnitsFollowUpStatus(attacker, defender);
        AttackOrCounterAttack(attacker, defender, WTBAttacker);
        UpdateUnitsFollowUpData(attacker, defender);
    }

    private void ResetFirstAttackBonusAndPenaltyStatsDiffOfUnits()
    {
        _unitStatsManager.ResetFirstAttackBonusAndPenaltyStatsDiff(_attackUnit);
        _unitStatsManager.ResetFirstAttackBonusAndPenaltyStatsDiff(_defenseUnit);
    }

    private void ShowCombatResults()
    {
        _view.WriteLine($"{_attackUnit.Name} ({_attackUnit.HPCurrent}) : {_defenseUnit.Name} ({_defenseUnit.HPCurrent})");
    }
    
    private void ResolveSkills()
    {
        SkillsController skillsController = new SkillsController(_attackUnit, _defenseUnit, _view);
        skillsController.CreateSkills();
        skillsController.ApplyUnitsSkillsEffectsIfConditionsAreSatisfiedByPriority(1);
        skillsController.ApplyUnitsSkillsEffectsIfConditionsAreSatisfiedByPriority(2);
        skillsController.ShowAllSkillsNetStatsOfUnitsAfterEffects();
    }
    
    private void SetUnitRoles()
    {
        _attackUnit.Role = "Attacker";
        _defenseUnit.Role = "Defender";
    }
    
    private void AttackOrCounterAttack(Unit attacker, Unit defender, double WTBAttacker)
    {
        SetUnitsFirstAttackStatus(attacker, defender);
        ApplyDamage(attacker, defender, WTBAttacker);
        UnSetUnitsFirstAttackStatus(attacker, defender);
    }

    public Unit[] ResolveCombat()
    {
        var WTBs = SetWTBs();
        SetUnitRoles();
        ResolveSkills();
        AttackOrCounterAttack(_attackUnit, _defenseUnit, WTBs[0]);
        if (CheckIfCombatIsOver()) return [_attackUnit, _defenseUnit];
        AttackOrCounterAttack(_defenseUnit, _attackUnit, WTBs[1]);
        if (CheckIfCombatIsOver()) return [_attackUnit, _defenseUnit];
        FollowUp(WTBs[0], WTBs[1]);
        if (CheckIfCombatIsOver()) return [_attackUnit, _defenseUnit];
        WrapUpCombat();
        return [_attackUnit, _defenseUnit];
    }

    private double[] SetWTBs()
    {
        WeaponTriangle weaponTriangle = new WeaponTriangle(_attackUnit, _defenseUnit, _view);
        double[] WTBs = weaponTriangle.ResolveWeaponTriangle();
        return WTBs;
    }

    private bool CheckIfCombatIsOver()
    {
        if (!CheckIfUnitDied()) return false;
        WrapUpCombat();
        return true;
    }
}