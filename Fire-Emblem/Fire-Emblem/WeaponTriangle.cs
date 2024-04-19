using Fire_Emblem_View;

namespace Fire_Emblem;

public class WeaponTriangle
{
    private Unit _attackUnit;
    private Unit _defenseUnit;
    private View _view;
    
    public WeaponTriangle(Unit attackUnit, Unit defendUnit, View view)
    {
        _attackUnit = attackUnit;
        _defenseUnit = defendUnit;
        _view = view;
    }
    
    private bool UnitHasWeaponAdvantage(Unit unit, Unit opponentUnit)
    {
        return (unit.Weapon == "Sword" && opponentUnit.Weapon == "Axe") ||
               (unit.Weapon == "Axe" && opponentUnit.Weapon == "Lance") ||
               (unit.Weapon == "Lance" && opponentUnit.Weapon == "Sword");
    }
    
    private bool UnitsHaveNoWeaponAdvantage(Unit unit, Unit opponentUnit)
    {
        return (unit.Weapon == opponentUnit.Weapon || (unit.Weapon == "Magic" || opponentUnit.Weapon == "Magic") ||
                (unit.Weapon == "Bow" || opponentUnit.Weapon == "Bow"));
    }
    
    private void DetermineWeaponAdvantage(ref double WTBAttacker, ref double WTBDefender)
    {
        if (UnitHasWeaponAdvantage(_attackUnit, _defenseUnit))
        {
            WTBAttacker = 1.2;
            WTBDefender = 0.8;
            _view.WriteLine($"{_attackUnit.Name} ({_attackUnit.Weapon}) tiene ventaja con respecto a {_defenseUnit.Name} ({_defenseUnit.Weapon})");
        }
        else if (UnitHasWeaponAdvantage(_defenseUnit, _attackUnit))
        {
            WTBAttacker = 0.8;
            WTBDefender = 1.2;
            _view.WriteLine($"{_defenseUnit.Name} ({_defenseUnit.Weapon}) tiene ventaja con respecto a {_attackUnit.Name} ({_attackUnit.Weapon})");
        }
    }

    public double[] ResolveWeaponTriangle()
    {
        double WTBAttacker = 1.0;
        double WTBDefender = 1.0;
        
        if (UnitsHaveNoWeaponAdvantage(_attackUnit, _defenseUnit))
        {
            _view.WriteLine("Ninguna unidad tiene ventaja con respecto a la otra");
        }
        else
        {
            DetermineWeaponAdvantage(ref WTBAttacker, ref WTBDefender);
        }
        
        return new double[] { WTBAttacker, WTBDefender };
    }
}