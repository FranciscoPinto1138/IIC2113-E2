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
    
    private void ResetBonusAndPenaltyStatsDiff()
    {
        AttackUnit.BonusStatsDiff = new StatsDiff();
        AttackUnit.PenaltyStatsDiff = new StatsDiff();
        AttackUnit.BonusNeutralizationManager = new BonusNeutralizationManager();
        AttackUnit.PenaltyNeutralizationManager = new PenaltyNeutralizationManager();
        DefenseUnit.BonusStatsDiff = new StatsDiff();
        DefenseUnit.PenaltyStatsDiff = new StatsDiff();
        DefenseUnit.BonusNeutralizationManager = new BonusNeutralizationManager();
        DefenseUnit.PenaltyNeutralizationManager = new PenaltyNeutralizationManager();
    }
    
    private void ApplyDamage(Unit damageMaker, Unit damageReceiver, double damageMakerWTB)
    {
        int defOrRes = DetermineResOrDef(damageReceiver, damageMaker);
        int damage = Convert.ToInt32(Math.Max(0, Math.Floor((damageMaker.UnitTotalAtk() * damageMakerWTB) - defOrRes)));
        //damageReceiverCombatStats.HPCurrent -= damage;
        damageReceiver.HPCurrent -= damage;
        _view.WriteLine($"{damageMaker.Name} ataca a {damageReceiver.Name} con {damage} de daño");
    }
    
    private bool CheckIfUnitDied()
    {
        bool unitDied = AttackUnit.HPCurrent <= 0 || DefenseUnit.HPCurrent <= 0;
        if (!unitDied) return unitDied;
        AttackUnit.HPCurrent = Math.Max(0, AttackUnit.HPCurrent);
        DefenseUnit.HPCurrent = Math.Max(0, DefenseUnit.HPCurrent);
        WrapUpCombat();
        return unitDied;
    }

    private void WrapUpCombat()
    {
        UpdateStatsPostCombat();
        ShowCombatResults();
    }
    
    private void Attack(double WTBAttacker)
    {
        ApplyDamage(AttackUnit, DefenseUnit, WTBAttacker);
    }

    private void CounterAttack(double WTBDefender)
    {
        ApplyDamage(DefenseUnit, AttackUnit, WTBDefender);
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
        if (AttackUnitCanFollowUp()) // Atacante hace Follow-Up
        {
            Attack(WTBAttacker);
        }
        if (DefenseUnitCanFollowUp()) // Defensor hace Follow-Up
        {
            CounterAttack(WTBDefender);
        }
        else if (!UnitsCanFollowUp())
        {
            _view.WriteLine("Ninguna unidad puede hacer un follow up");
        }
    }
    
    private void UpdateStatsPostCombat()
    {
        ResetBonusAndPenaltyStatsDiff();
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