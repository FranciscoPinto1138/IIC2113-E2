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
        const string MAGIC_WEAPON = "Magic";
        const string BOW_WEAPON = "Bow";
        return (unit.Weapon == opponentUnit.Weapon 
                || (unit.Weapon == MAGIC_WEAPON || opponentUnit.Weapon == MAGIC_WEAPON) 
                || (unit.Weapon == BOW_WEAPON || opponentUnit.Weapon == BOW_WEAPON));
    }
    
    private void DetermineWeaponAdvantage()
    {
        const double WTB_ADVANTAGE= 1.2;
        const double WTB_DISADVANTAGE = 0.8;
        if (UnitHasWeaponAdvantage(_attackUnit, _defenseUnit))
        {
            _WTBAttacker = WTB_ADVANTAGE;
            _WTBDefender = WTB_DISADVANTAGE;
        }
        else if (UnitHasWeaponAdvantage(_defenseUnit, _attackUnit))
        {
            _WTBAttacker = WTB_DISADVANTAGE;
            _WTBDefender = WTB_ADVANTAGE;
        }
    }
    
    private bool UnitHasWeaponAdvantage(Unit unit, Unit opponentUnit)
    {
        const string SWORD_WEAPON = "Sword";
        const string AXE_WEAPON = "Axe"; 
        const string LANCE_WEAPON = "Lance";
        return (unit.Weapon == SWORD_WEAPON && opponentUnit.Weapon == AXE_WEAPON) ||
               (unit.Weapon == AXE_WEAPON && opponentUnit.Weapon == LANCE_WEAPON) ||
               (unit.Weapon == LANCE_WEAPON && opponentUnit.Weapon == SWORD_WEAPON);
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