using Fire_Emblem_View;

namespace Fire_Emblem;

public class DamageManager
{
    private Unit _damageMaker;
    private Unit _damageReceiver;
    private int _defOrRes;
    private int _initialDamage;
    private int _totalDamage;
    private UnitStatsManager _unitStatsManager = new UnitStatsManager();
    
    public DamageManager(Unit damageMaker, Unit damageReceiver)
    {
        this._damageMaker = damageMaker;
        this._damageReceiver = damageReceiver;
    }
    
    public void ApplyDamage()
    {
        SetResOrDef();
        _totalDamage = DetermineDamage();
        _damageReceiver.HPCurrent -= _totalDamage;
    }
    
    private void SetResOrDef()
    {
        _defOrRes = _damageMaker.Weapon == "Magic" ? _unitStatsManager.GetUnitTotalRes(_damageReceiver) : _unitStatsManager.GetUnitTotalDef(_damageReceiver);
    }
    
    private int DetermineDamage()
    {
        _initialDamage = Convert.ToInt32(Math.Max(0, Math.Floor((_unitStatsManager.GetUnitTotalAtk(_damageMaker) * _damageMaker.CurrentWTB) - _defOrRes)));
        int initialDamagePlusExtraDamage = _initialDamage + DetermineBaseExtraDamage();
        int percentageReducedDamage = DeterminePercentageReducedDamage(initialDamagePlusExtraDamage);
        int absoluteReducedDamage = DetermineAbsoluteReducedDamage(percentageReducedDamage);
        return Math.Max(absoluteReducedDamage, 0);
    }

    private int DetermineBaseExtraDamage()
    {
        return _damageMaker.DamageEffectsManager.ExtraDamagePermanent
               + _damageMaker.DamageEffectsManager.ExtraDamageFirstAttack * _damageMaker.IsOnFirstAttack
               + _damageMaker.DamageEffectsManager.ExtraDamageFollowUp * _damageMaker.IsOnFollowUpAttack;
    }

    private int DeterminePercentageReducedDamage(int initialDamagePlusExtraDamage)
    {
        double percentageReducedDamage =
            initialDamagePlusExtraDamage * (1 - _damageReceiver.DamageEffectsManager.DamagePercentageReductionPermanent)
                                         * (1 - _damageReceiver.DamageEffectsManager.DamagePercentageReductionFirstAttack * _damageReceiver.RivalIsOnFirstAttack)
                                         * (1 - _damageReceiver.DamageEffectsManager.DamagePercentageReductionFollowUp * _damageReceiver.RivalIsOnFollowUpAttack);
        return Convert.ToInt32(Math.Floor(Math.Round(percentageReducedDamage, 9)));
    }

    private int DetermineAbsoluteReducedDamage(int percentageReducedDamage)
    {
        return percentageReducedDamage - _damageReceiver.DamageEffectsManager.DamageAbsoluteReductionPermanent;
    }
    
    public int GetReducedDamageOnFirstAttack()
    {
        SetResOrDef();
        return Convert.ToInt32(Convert.ToInt32(Math.Max(0, Math.Floor((_unitStatsManager.GetUnitTotalAtk(_damageMaker) * _damageMaker.CurrentWTB) - _defOrRes))) 
                               + _damageMaker.DamageEffectsManager.ExtraDamagePermanent
                               + _damageMaker.DamageEffectsManager.ExtraDamageFirstAttack
                               - (Math.Floor((Convert.ToInt32(Math.Max(0, Math.Floor((_unitStatsManager.GetUnitTotalAtk(_damageMaker) * _damageMaker.CurrentWTB) - _defOrRes)))
                                   + _damageMaker.DamageEffectsManager.ExtraDamagePermanent
                                   + _damageMaker.DamageEffectsManager.ExtraDamageFirstAttack) 
                                  * (1 - _damageReceiver.DamageEffectsManager.DamagePercentageReductionPermanent)
                                  * (1 - _damageReceiver.DamageEffectsManager.DamagePercentageReductionFirstAttack))
                                  - _damageReceiver.DamageEffectsManager.DamageAbsoluteReductionPermanent));
    }
    
    public int GetTotalDamage()
    {
        return _totalDamage;
    }
}