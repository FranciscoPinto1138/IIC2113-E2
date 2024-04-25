using Fire_Emblem_View;
namespace Fire_Emblem;

public class Combat
{
    private Unit AttackUnit { get; }
    private Team AttackerTeam { get; }
    private Unit DefenseUnit { get; }
    private Team DefenderTeam { get; }
    private View _view;
    
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
        return opponentUnit.Weapon == "Magic" ? unit.UnitTotalRes() : unit.UnitTotalDef();
    }
    
    private void ResetUnitsBonusAndPenaltyStatsDiff()
    {
        AttackUnit.ResetAllBonusAndPenaltyStatsDiff();
        DefenseUnit.ResetAllBonusAndPenaltyStatsDiff();
    }
    
    private void ApplyDamage(Unit damageMaker, Unit damageReceiver, double damageMakerWTB)
    {
        int defOrRes = DetermineResOrDef(damageReceiver, damageMaker);
        int damage = Convert.ToInt32(Math.Max(0, Math.Floor((damageMaker.UnitTotalAtk() * damageMakerWTB) - defOrRes)));
        damageReceiver.HPCurrent -= damage;
        _view.WriteLine($"{damageMaker.Name} ataca a {damageReceiver.Name} con {damage} de daño");
    }
    
    private bool CheckIfUnitDied()
    {
        bool unitDied = AttackUnit.HPCurrent <= 0 || DefenseUnit.HPCurrent <= 0;
        if (!unitDied) return unitDied;
        SetUnitsHPToMinimumIfNegative();
        WrapUpCombat();
        return unitDied;
    }
    
    private void SetUnitsHPToMinimumIfNegative()
    {
        const int minimumHPofUnit = 0;
        AttackUnit.HPCurrent = Math.Max(minimumHPofUnit, AttackUnit.HPCurrent);
        DefenseUnit.HPCurrent = Math.Max(minimumHPofUnit, DefenseUnit.HPCurrent);
    }

    private void WrapUpCombat()
    {
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
    
    private void Attack(double WTBAttacker)
    {
        SetUnitsFirstAttackStatus(AttackUnit, DefenseUnit);
        ApplyDamage(AttackUnit, DefenseUnit, WTBAttacker);
        UnSetUnitsFirstAttackStatus(AttackUnit, DefenseUnit);
    }

    private void CounterAttack(double WTBDefender)
    {
        SetUnitsFirstAttackStatus(DefenseUnit, AttackUnit);
        ApplyDamage(DefenseUnit, AttackUnit, WTBDefender);
        UnSetUnitsFirstAttackStatus(DefenseUnit, AttackUnit);
    }
    
    private bool AttackUnitCanFollowUp()
    {
        const int minimumSpdDifferenceForFollowUp = 5;
        return AttackUnit.UnitTotalSpd() - DefenseUnit.UnitTotalSpd() >= minimumSpdDifferenceForFollowUp;
    }
    
    private bool DefenseUnitCanFollowUp()
    {
        const int minimumSpdDifferenceForFollowUp = 5;
        return DefenseUnit.UnitTotalSpd() - AttackUnit.UnitTotalSpd() >= minimumSpdDifferenceForFollowUp;
    }
    
    private bool UnitsCanFollowUp()
    {
        return AttackUnitCanFollowUp() || DefenseUnitCanFollowUp();
    }

    private void FollowUp(double WTBAttacker, double WTBDefender)
    {
        AttackUnit.ResetFirstAttackBonusAndPenaltyStatsDiff();
        DefenseUnit.ResetFirstAttackBonusAndPenaltyStatsDiff();
        if (AttackUnitCanFollowUp()) // Atacante hace Follow-Up
        {
            SetUnitsFollowUpStatus(AttackUnit, DefenseUnit);
            Attack(WTBAttacker);
            AttackUnit.ResetFollowUpAttackBonusAndPenaltyStatsDiff();
            UnSetUnitsFollowUpStatus(AttackUnit, DefenseUnit);
        }
        if (DefenseUnitCanFollowUp()) // Defensor hace Follow-Up
        {
            SetUnitsFollowUpStatus(DefenseUnit, AttackUnit);
            CounterAttack(WTBDefender);
            DefenseUnit.ResetFollowUpAttackBonusAndPenaltyStatsDiff();
            UnSetUnitsFollowUpStatus(DefenseUnit, AttackUnit);
        }
        else if (!UnitsCanFollowUp())
        {
            _view.WriteLine("Ninguna unidad puede hacer un follow up");
        }
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

    public Unit[] ResolveCombat()
    {
        WeaponTriangle weaponTriangle = new WeaponTriangle(AttackUnit, DefenseUnit, _view);
        double[] WTBs = weaponTriangle.ResolveWeaponTriangle();
        SetUnitRoles();
        ResolveSkills();
        Attack(WTBs[0]);
        if (CheckIfUnitDied())
        {
            return [AttackUnit, DefenseUnit];
        }
        CounterAttack(WTBs[1]);
        if (CheckIfUnitDied())
        {
            return [AttackUnit, DefenseUnit];
        }
        FollowUp(WTBs[0], WTBs[1]);
        if (CheckIfUnitDied())
        {
            return [AttackUnit, DefenseUnit];
        }
        WrapUpCombat();
        return [AttackUnit, DefenseUnit];
    }
}