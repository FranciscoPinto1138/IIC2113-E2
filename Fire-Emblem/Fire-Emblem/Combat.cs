using Fire_Emblem_View;
namespace Fire_Emblem;

public class Combat
{
    private Unit AttackUnit { get; }
    private Team AttackerTeam { get; }
    private Unit DefenseUnit { get; }
    private Team DefenderTeam { get; }
    private Stats OriginalAttackUnitStats { get; set; }
    private Stats OriginalDefenseUnitStats { get; set; }
    private Stats CombatAttackUnitStats { get; set; }
    private Stats CombatDefenseUnitStats { get; set; }
    private View _view;
    
    public Combat(Unit attacker, Unit defender, Team attackerTeam, Team defenderTeam ,View view)
    {
        AttackUnit = attacker;
        DefenseUnit = defender;
        AttackerTeam = attackerTeam;
        DefenderTeam = defenderTeam;
        _view = view;
    }
    
    private int DetermineResOrDef(Stats stats, Unit opponentUnit)
    {
        return opponentUnit.Weapon == "Magic" ? stats.Res : stats.Def;
    }
    
    private void ResetStats()
    {
        AttackUnit.HPCurrent = CombatAttackUnitStats.HPCurrent;
        AttackUnit.Atk = OriginalAttackUnitStats.Atk;
        AttackUnit.Spd = OriginalAttackUnitStats.Spd;
        AttackUnit.Def = OriginalAttackUnitStats.Def;
        AttackUnit.Res = OriginalAttackUnitStats.Res;
        DefenseUnit.HPCurrent = CombatDefenseUnitStats.HPCurrent;
        DefenseUnit.Atk = OriginalDefenseUnitStats.Atk;
        DefenseUnit.Spd = OriginalDefenseUnitStats.Spd;
        DefenseUnit.Def = OriginalDefenseUnitStats.Def;
        DefenseUnit.Res = OriginalDefenseUnitStats.Res;
    }
    
    private void ApplyDamage(Unit damageMaker, Unit damageReceiver, double damageMakerWTB, Stats damageReceiverCombatStats, Stats damageMakerCombatStats)
    {
        int defOrRes = DetermineResOrDef(damageReceiverCombatStats, damageMaker);
        int damage = Convert.ToInt32(Math.Max(0, Math.Floor((damageMakerCombatStats.Atk * damageMakerWTB) - defOrRes)));
        damageReceiverCombatStats.HPCurrent -= damage;
        _view.WriteLine($"{damageMaker.Name} ataca a {damageReceiver.Name} con {damage} de daño");
    }
    
    private bool CheckIfUnitDied()
    {
        bool unitDied = CombatAttackUnitStats.HPCurrent <= 0 || CombatDefenseUnitStats.HPCurrent <= 0;
        if (!unitDied) return unitDied;
        CombatAttackUnitStats.HPCurrent = Math.Max(0, CombatAttackUnitStats.HPCurrent);
        CombatDefenseUnitStats.HPCurrent = Math.Max(0, CombatDefenseUnitStats.HPCurrent);
        UpdateStatsPostCombat();
        ShowCombatResults();
        return unitDied;
    }
    
    private void Attack(double WTBAttacker)
    {
        ApplyDamage(AttackUnit, DefenseUnit, WTBAttacker, 
            CombatDefenseUnitStats, CombatAttackUnitStats);
    }

    private void CounterAttack(double WTBDefender)
    {
        ApplyDamage(DefenseUnit, AttackUnit, WTBDefender, 
            CombatAttackUnitStats, CombatDefenseUnitStats);
    }
    
    private bool AttackUnitCanFollowUp()
    {
        const int minimumSpdDifferenceForFollowUp = 5;
        return CombatAttackUnitStats.Spd - CombatDefenseUnitStats.Spd >= minimumSpdDifferenceForFollowUp;
    }
    
    private bool DefenseUnitCanFollowUp()
    {
        const int minimumSpdDifferenceForFollowUp = 5;
        return CombatDefenseUnitStats.Spd - CombatAttackUnitStats.Spd >= minimumSpdDifferenceForFollowUp;
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
    
    private void SetUnitsLastRivalStats()
    {
        AttackUnit.MostRecentRival = DefenseUnit.Name;
        DefenseUnit.MostRecentRival = AttackUnit.Name;
    }
    
    private void SetCombatAndOriginalStats()
    {
        OriginalAttackUnitStats = new Stats(AttackUnit);
        OriginalDefenseUnitStats = new Stats(DefenseUnit);
        CombatAttackUnitStats = new Stats(AttackUnit);
        CombatDefenseUnitStats = new Stats(DefenseUnit);
    }
    
    private void UpdateStatsPostCombat()
    {
        ResetStats();
        SetUnitsLastRivalStats();
    }
    
    private void ShowCombatResults()
    {
        _view.WriteLine($"{AttackUnit.Name} ({AttackUnit.HPCurrent}) : {DefenseUnit.Name} ({DefenseUnit.HPCurrent})");
    }
    
    private void ResolveSkills()
    {
        SkillsController skillsController = new SkillsController(AttackUnit, DefenseUnit,
            CombatAttackUnitStats, CombatDefenseUnitStats, _view);
        skillsController.CreateSkills();
        skillsController.ApplySkills();
    }

    public Unit[] ResolveCombat()
    {
        WeaponTriangle weaponTriangle = new WeaponTriangle(AttackUnit, DefenseUnit, _view);
        double[] WTBs = weaponTriangle.ResolveWeaponTriangle();
        SetCombatAndOriginalStats();
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
        UpdateStatsPostCombat();
        ShowCombatResults();
        return [AttackUnit, DefenseUnit];
    }
}