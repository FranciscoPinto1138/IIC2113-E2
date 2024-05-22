using Fire_Emblem_View;

namespace Fire_Emblem;

public class CombatWrapper
{
    private Unit _attackUnit;
    private Unit _defenseUnit;
    private View _view;

    public CombatWrapper(Unit attackUnit, Unit defenseUnit, View view)
    {
        this._attackUnit = attackUnit;
        this._defenseUnit = defenseUnit;
        this._view = view;
    }

    public void WrapUpCombat()
    {
        SetUnitsHPToMinimumIfNegative();
        ResetUnitsBonusAndPenaltyStatsDiff();
        ResetUnitsExtraDamage();
        _view.ShowCombatResults(_attackUnit.Name, _attackUnit.HPCurrent, 
            _defenseUnit.Name, _defenseUnit.HPCurrent);
    }

    private void ResetUnitsBonusAndPenaltyStatsDiff()
    {
        UnitStatsManager unitStatsManager = new UnitStatsManager();
        unitStatsManager.ResetAllBonusAndPenaltyStatsDiff(_attackUnit);
        unitStatsManager.ResetAllBonusAndPenaltyStatsDiff(_defenseUnit);
    }
    
    private void SetUnitsHPToMinimumIfNegative()
    {
        const int MIN_HP_OF_UNIT = 0;
        _attackUnit.HPCurrent = Math.Max(MIN_HP_OF_UNIT, _attackUnit.HPCurrent);
        _defenseUnit.HPCurrent = Math.Max(MIN_HP_OF_UNIT, _defenseUnit.HPCurrent);
    }
    
    private void ResetUnitsExtraDamage()
    {
        _attackUnit.DamageEffectsManager = new DamageEffectsManager();
        _defenseUnit.DamageEffectsManager = new DamageEffectsManager();
    }
}