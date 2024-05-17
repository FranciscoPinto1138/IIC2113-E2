using Fire_Emblem_View;

namespace Fire_Emblem;

public class DamageManager
{
    private Unit _damageMaker;
    private Unit _damageReceiver;
    private int _defOrRes;
    private int _initialDamage;
    private UnitStatsManager _unitStatsManager = new UnitStatsManager();
    
    public DamageManager(Unit damageMaker, Unit damageReceiver)
    {
        this._damageMaker = damageMaker;
        this._damageReceiver = damageReceiver;
        SetResOrDef();
        SetInitialDamage();
    }
    
    private void SetInitialDamage()
    {
        _initialDamage = Convert.ToInt32(Math.Max(0, Math.Floor((_unitStatsManager.GetUnitTotalAtk(_damageMaker) * _damageMaker.CurrentWTB) - _defOrRes)));
    }
    
    private void SetResOrDef()
    {
        _defOrRes = _damageMaker.Weapon == "Magic" ? _unitStatsManager.GetUnitTotalRes(_damageReceiver) : _unitStatsManager.GetUnitTotalDef(_damageReceiver);
    }
    
    public void ApplyDamage()
    {
        _damageReceiver.HPCurrent -= DetermineTotalDamageAfterEffects();
    }
    
    public int DetermineTotalDamageAfterEffects()
    {
        const int MIN_TOTAL_DAMAGE = 0;
        int initialDamagePlusExtraDamage = _initialDamage + DetermineBaseExtraDamage();
        int percentageReducedDamage = DeterminePercentageReducedDamage(initialDamagePlusExtraDamage);
        int absoluteReducedDamage = DetermineAbsoluteReducedDamage(percentageReducedDamage);
        return Math.Max(absoluteReducedDamage, MIN_TOTAL_DAMAGE);
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
        return Convert.ToInt32(_initialDamage
                               + _damageMaker.DamageEffectsManager.ExtraDamagePermanent
                               + _damageMaker.DamageEffectsManager.ExtraDamageFirstAttack
                               - (Math.Floor((_initialDamage
                                   + _damageMaker.DamageEffectsManager.ExtraDamagePermanent
                                   + _damageMaker.DamageEffectsManager.ExtraDamageFirstAttack) 
                                  * (1 - _damageReceiver.DamageEffectsManager.DamagePercentageReductionPermanent)
                                  * (1 - _damageReceiver.DamageEffectsManager.DamagePercentageReductionFirstAttack))
                                  - _damageReceiver.DamageEffectsManager.DamageAbsoluteReductionPermanent));
    }
}