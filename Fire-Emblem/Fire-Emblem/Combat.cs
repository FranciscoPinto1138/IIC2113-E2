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
    
    private static bool UnitHasWeaponAdvantage(Unit unit, Unit opponentUnit)
    {
        return (unit.Weapon == "Sword" && opponentUnit.Weapon == "Axe") ||
               (unit.Weapon == "Axe" && opponentUnit.Weapon == "Lance") ||
               (unit.Weapon == "Lance" && opponentUnit.Weapon == "Sword");
    }
    
    private static bool UnitsHaveNoWeaponAdvantage(Unit unit, Unit opponentUnit)
    {
        return (unit.Weapon == opponentUnit.Weapon || (unit.Weapon == "Magic" || opponentUnit.Weapon == "Magic") ||
                (unit.Weapon == "Bow" || opponentUnit.Weapon == "Bow"));
    }
    
    private void DetermineWeaponAdvantage(Unit attackUnit, Unit defenseUnit, ref double WTBAttacker, ref double WTBDefender)
    {
        if (UnitHasWeaponAdvantage(attackUnit, defenseUnit))
        {
            WTBAttacker = 1.2;
            WTBDefender = 0.8;
            _view.WriteLine($"{attackUnit.Name} ({attackUnit.Weapon}) tiene ventaja con respecto a {defenseUnit.Name} ({defenseUnit.Weapon})");
        }
        else if (UnitHasWeaponAdvantage(defenseUnit, attackUnit))
        {
            WTBAttacker = 0.8;
            WTBDefender = 1.2;
            _view.WriteLine($"{defenseUnit.Name} ({defenseUnit.Weapon}) tiene ventaja con respecto a {attackUnit.Name} ({attackUnit.Weapon})");
        }
    }

    private double[] ResolveWeaponTriangle(Unit attackUnit, Unit defenseUnit)
    {
        double WTBAttacker = 1.0;
        double WTBDefender = 1.0;
        
        if (UnitsHaveNoWeaponAdvantage(attackUnit, defenseUnit))
        {
            _view.WriteLine("Ninguna unidad tiene ventaja con respecto a la otra");
        }
        else
        {
            DetermineWeaponAdvantage(attackUnit, defenseUnit, ref WTBAttacker, ref WTBDefender);
        }
        
        return new double[] { WTBAttacker, WTBDefender };
    }
    
    private static int DetermineResOrDef(Unit unit, Unit opponentUnit)
    {
        return opponentUnit.Weapon == "Magic" ? unit.Res : unit.Def;
    }

    public Unit[] ResolveCombat()
    {
        // Se determinan los WTB usando el método WeaponTriangle()
        double[] WTBs = ResolveWeaponTriangle(AttackUnit, DefenseUnit);
        double WTBAttacker = WTBs[0];
        double WTBDefender = WTBs[1];
        Stats originalAttackUnitStats = new Stats(AttackUnit);
        Stats originalDefenseUnitStats = new Stats(DefenseUnit);
        Stats combatAttackUnitStats = new Stats(AttackUnit);
        Stats combatDefenseUnitStats = new Stats(DefenseUnit);
        // Ataque
        // Se revisa si debe usarse Res o Def para el defensor
        int defenderDefOrRes = DetermineResOrDef(DefenseUnit, AttackUnit);
        // Se calcula el daño y se resta al defensor
        int damageToDefender = Convert.ToInt32(Math.Max(0, Math.Floor((AttackUnit.Atk * WTBAttacker) - defenderDefOrRes)));
        DefenseUnit.HPCurrent = DefenseUnit.HPCurrent - damageToDefender;
        _view.WriteLine($"{AttackUnit.Name} ataca a {DefenseUnit.Name} con {damageToDefender} de daño");
        // Si la unidad muere se termina el round
        if (DefenseUnit.HPCurrent <= 0)
        {
            DefenseUnit.HPCurrent = 0;
            _view.WriteLine($"{AttackUnit.Name} ({AttackUnit.HPCurrent}) : {DefenseUnit.Name} ({DefenseUnit.HPCurrent})");
            return [AttackUnit, DefenseUnit];
        }
        // Contraataque
        // Se revisa si debe usarse Res o Def para el atacante
        int attackerDefOrRes = DetermineResOrDef(AttackUnit, DefenseUnit);
        // Se calcula el daño y se resta al atacante
        int damageToAttacker = Convert.ToInt32(Math.Max(0, Math.Floor((DefenseUnit.Atk * WTBDefender) - attackerDefOrRes)));
        AttackUnit.HPCurrent = AttackUnit.HPCurrent - damageToAttacker;
        _view.WriteLine($"{DefenseUnit.Name} ataca a {AttackUnit.Name} con {damageToAttacker} de daño");
        // Si la unidad muere se termina el round
        if (AttackUnit.HPCurrent <= 0)
        {
            AttackUnit.HPCurrent = 0;
            _view.WriteLine($"{AttackUnit.Name} ({AttackUnit.HPCurrent}) : {DefenseUnit.Name} ({DefenseUnit.HPCurrent})");
            return [AttackUnit, DefenseUnit];
        }
        // Follow-Up (si aplica)
        if (AttackUnit.Spd - DefenseUnit.Spd >= 5) // Atacante hace Follow-Up
        {
            DefenseUnit.HPCurrent = DefenseUnit.HPCurrent - damageToDefender;
            _view.WriteLine($"{AttackUnit.Name} ataca a {DefenseUnit.Name} con {damageToDefender} de daño");
            if (DefenseUnit.HPCurrent <= 0)
            {
                DefenseUnit.HPCurrent = 0;
                _view.WriteLine($"{AttackUnit.Name} ({AttackUnit.HPCurrent}) : {DefenseUnit.Name} ({DefenseUnit.HPCurrent})");
                return [AttackUnit, DefenseUnit];
            }
        }
        if (DefenseUnit.Spd - AttackUnit.Spd >= 5) // Defensor hace Follow-Up
        {
            AttackUnit.HPCurrent = AttackUnit.HPCurrent - damageToAttacker;
            _view.WriteLine($"{DefenseUnit.Name} ataca a {AttackUnit.Name} con {damageToAttacker} de daño");
            if (AttackUnit.HPCurrent <= 0)
            {
                AttackUnit.HPCurrent = 0;
                _view.WriteLine($"{AttackUnit.Name} ({AttackUnit.HPCurrent}) : {DefenseUnit.Name} ({DefenseUnit.HPCurrent})");
                return [AttackUnit, DefenseUnit];
            }
        }
        if (!((DefenseUnit.Spd - AttackUnit.Spd >= 5) || (AttackUnit.Spd - DefenseUnit.Spd >= 5))) // No ocurre Follow-Up
        {
          _view.WriteLine("Ninguna unidad puede hacer un follow up");
        }

        _view.WriteLine($"{AttackUnit.Name} ({AttackUnit.HPCurrent}) : {DefenseUnit.Name} ({DefenseUnit.HPCurrent})");
        return [AttackUnit, DefenseUnit];
    }
}