using Fire_Emblem_View;
namespace Fire_Emblem;

public class Combat
{
    private Unit AttackUnit { get; }
    private Team AttackerTeam { get; }
    private Unit DefenseUnit { get; }
    private Team DefenderTeam { get; }
    private View _view;
    private UnitStatsManager _unitStatsManager = new UnitStatsManager();
    
    public Combat(Unit attacker, Unit defender, Team attackerTeam, Team defenderTeam ,View view)
    {
        AttackUnit = attacker;
        DefenseUnit = defender;
        AttackerTeam = attackerTeam;
        DefenderTeam = defenderTeam;
        _view = view;
    }
    
    private int DetermineResOrDef(Unit unit, Unit opponentUnit)
    {
        return opponentUnit.Weapon == "Magic" ? _unitStatsManager.GetUnitTotalRes(unit) : _unitStatsManager.GetUnitTotalDef(unit);
    }
    
    private int DetermineDamage(Unit damageMaker, double damageMakerWTB, int defOrRes)
    {
        return Convert.ToInt32(Math.Max(0, Math.Floor((_unitStatsManager.GetUnitTotalAtk(damageMaker) * damageMakerWTB) - defOrRes)));
    }
    
    private void ResetUnitsBonusAndPenaltyStatsDiff()
    {
        _unitStatsManager.ResetAllBonusAndPenaltyStatsDiff(AttackUnit);
        _unitStatsManager.ResetAllBonusAndPenaltyStatsDiff(DefenseUnit);
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
        return AttackUnit.HPCurrent <= 0 || DefenseUnit.HPCurrent <= 0;
    }
    
    private void SetUnitsHPToMinimumIfNegative()
    {
        const int minimumHPofUnit = 0;
        AttackUnit.HPCurrent = Math.Max(minimumHPofUnit, AttackUnit.HPCurrent);
        DefenseUnit.HPCurrent = Math.Max(minimumHPofUnit, DefenseUnit.HPCurrent);
    }

    private void WrapUpCombat()
    {
        SetUnitsHPToMinimumIfNegative();
        ResetUnitsBonusAndPenaltyStatsDiff();
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
        return _unitStatsManager.GetUnitTotalSpd(AttackUnit) - _unitStatsManager.GetUnitTotalSpd(DefenseUnit) >= minimumSpdDifferenceForFollowUp;
    }
    
    private bool DefenseUnitCanFollowUp()
    {
        const int minimumSpdDifferenceForFollowUp = 5;
        return _unitStatsManager.GetUnitTotalSpd(DefenseUnit) - _unitStatsManager.GetUnitTotalSpd(AttackUnit) >= minimumSpdDifferenceForFollowUp;
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
            ResolveUnitFollowUp(AttackUnit, DefenseUnit, WTBAttacker);
        }
        if (DefenseUnitCanFollowUp())
        {
            ResolveUnitFollowUp(DefenseUnit, AttackUnit, WTBDefender);
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
        _unitStatsManager.ResetFirstAttackBonusAndPenaltyStatsDiff(AttackUnit);
        _unitStatsManager.ResetFirstAttackBonusAndPenaltyStatsDiff(DefenseUnit);
    }

    private void ShowCombatResults()
    {
        _view.WriteLine($"{AttackUnit.Name} ({AttackUnit.HPCurrent}) : {DefenseUnit.Name} ({DefenseUnit.HPCurrent})");
    }
    
    private void ResolveSkills()
    {
        SkillsController skillsController = new SkillsController(AttackUnit, DefenseUnit, _view);
        skillsController.CreateSkills();
        skillsController.ApplySkills();
        skillsController.ShowAllSkillsNetStatsOfUnitsAfterEffects();
    }
    
    private void SetUnitRoles()
    {
        AttackUnit.Role = "Attacker";
        DefenseUnit.Role = "Defender";
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
        AttackOrCounterAttack(AttackUnit, DefenseUnit, WTBs[0]);
        if (CheckIfCombatIsOver()) return [AttackUnit, DefenseUnit];
        AttackOrCounterAttack(DefenseUnit, AttackUnit, WTBs[1]);
        if (CheckIfCombatIsOver()) return [AttackUnit, DefenseUnit];
        FollowUp(WTBs[0], WTBs[1]);
        if (CheckIfCombatIsOver()) return [AttackUnit, DefenseUnit];
        WrapUpCombat();
        return [AttackUnit, DefenseUnit];
    }

    private double[] SetWTBs()
    {
        WeaponTriangle weaponTriangle = new WeaponTriangle(AttackUnit, DefenseUnit, _view);
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