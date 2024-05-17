using Fire_Emblem_View;

namespace Fire_Emblem;

public class WeaponTriangle
{
    private Unit _attackUnit;
    private Unit _defenseUnit;
    private View _view;
    private double _WTBAttacker;
    private double _WTBDefender;

    
    public WeaponTriangle(Unit attackUnit, Unit defendUnit, View view)
    {
        _attackUnit = attackUnit;
        _defenseUnit = defendUnit;
        _view = view;
    }
    
    public double[] GetWTBsFromWeaponTriangle()
    {
        _WTBAttacker = 1.0;
        _WTBDefender = 1.0;
        
        if (DoesUnitsHaveNoWeaponAdvantage(_attackUnit, _defenseUnit))
        {
            _view.WriteLine("Ninguna unidad tiene ventaja con respecto a la otra");
        }
        else
        {
            DetermineWeaponAdvantage();
            ShowWeaponAdvantage();
        }
        
        return new double[] { _WTBAttacker, _WTBDefender };
    }
    
    private bool DoesUnitsHaveNoWeaponAdvantage(Unit unit, Unit opponentUnit)
    {
        const string magicWeapon = "Magic";
        const string bowWeapon = "Bow";
        return (unit.Weapon == opponentUnit.Weapon || (unit.Weapon == magicWeapon || opponentUnit.Weapon == magicWeapon) ||
                (unit.Weapon == bowWeapon || opponentUnit.Weapon == bowWeapon));
    }
    
    private void DetermineWeaponAdvantage()
    {
        const double WTBAdvantage = 1.2;
        const double WTBDisadvantage = 0.8;
        if (UnitHasWeaponAdvantage(_attackUnit, _defenseUnit))
        {
            _WTBAttacker = WTBAdvantage;
            _WTBDefender = WTBDisadvantage;
        }
        else if (UnitHasWeaponAdvantage(_defenseUnit, _attackUnit))
        {
            _WTBAttacker = WTBDisadvantage;
            _WTBDefender = WTBAdvantage;
        }
    }
    
    private bool UnitHasWeaponAdvantage(Unit unit, Unit opponentUnit)
    {
        const string swordWeapon = "Sword";
        const string axeWeapon = "Axe"; 
        const string lanceWeapon = "Lance";
        return (unit.Weapon == swordWeapon && opponentUnit.Weapon == axeWeapon) ||
               (unit.Weapon == axeWeapon && opponentUnit.Weapon == lanceWeapon) ||
               (unit.Weapon == lanceWeapon && opponentUnit.Weapon == swordWeapon);
    }
    
    private void ShowWeaponAdvantage()
    {
        if (_WTBAttacker > _WTBDefender)
        {
            _view.WriteLine($"{_attackUnit.Name} ({_attackUnit.Weapon}) tiene ventaja con respecto a {_defenseUnit.Name} ({_defenseUnit.Weapon})");
        }
        else if (_WTBAttacker < _WTBDefender)
        {
            _view.WriteLine($"{_defenseUnit.Name} ({_defenseUnit.Weapon}) tiene ventaja con respecto a {_attackUnit.Name} ({_attackUnit.Weapon})");
        }
    }
}