using Fire_Emblem_View;

namespace Fire_Emblem;

public class SkillsEffectsShower
{
    private Unit _attackUnit;
    private Unit _defenseUnit;
    private View _view;
    
    public SkillsEffectsShower(Unit attackUnit, Unit defenseUnit, View view)
    {
        _attackUnit = attackUnit;
        _defenseUnit = defenseUnit;
        _view = view;
    }
    
    public void ShowNetStatsOfUnitsAfterEffects()
    {
        ShowNetStatsEffects(_attackUnit);
        ShowNeutralizedBonusAndPenalties(_attackUnit);
        ShowDamageRelatedEffects(_attackUnit);
        ShowNetStatsEffects(_defenseUnit);
        ShowNeutralizedBonusAndPenalties(_defenseUnit);
        ShowDamageRelatedEffects(_defenseUnit);
    }
    
    private void ShowNetStatsEffects(Unit unit)
    {
        ShowBonusStatsEffects(unit);
        ShowPenaltiesStatsEffects(unit);
    }
    
    private void ShowBonusStatsEffects(Unit unit)
    {
        ShowBonusStatsEffectsOfUnit(unit);
        ShowBonusStatsEffectsOnFirstAttackOnUnit(unit);
        ShowBonusStatsEffectsOnFollowUpOnUnit(unit);
    }
    
    private void ShowPenaltiesStatsEffects(Unit unit)
    {
        ShowPenaltyStatsEffectsOfUnit(unit);
        ShowPenaltyStatsEffectsOnFirstAttackOnUnit(unit);
        ShowPenaltyStatsEffectsOnFollowUpOnUnit(unit);
    }

    private void ShowNeutralizedBonusAndPenalties(Unit unit)
    {
        ShowNeutralizedBonusByStats(unit);
        ShowNeutralizedPenaltyByStats(unit);
    }

    private void ShowDamageRelatedEffects(Unit unit)
    {
        ShowExtraDamageEffects(unit);
        ShowPercentageReducedDamage(unit);
        ShowAbsolutePermanentReducedDamage(unit);
    }

    private void ShowExtraDamageEffects(Unit unit)
    {
        ShowExtraDamagePermanentEffects(unit);
        ShowExtraDamageFirstAttackEffects(unit);
        ShowExtraDamageFollowUpEffects(unit);
    }

    private void ShowPercentageReducedDamage(Unit unit)
    {
        ShowPercentagePermanentReducedDamage(unit);
        ShowPercentageOpponentFirstAttackReducedDamage(unit);
        ShowPercentageOpponentFollowUpReducedDamage(unit);
    }
    
    private void ShowBonusStatsEffectsOfUnit(Unit unit)
    {
        if (unit.BonusStatsDiff.Atk > 0)
        {
            _view.WriteLine($"{unit.Name} obtiene Atk+{unit.BonusStatsDiff.Atk}");
        }
        if (unit.BonusStatsDiff.Spd > 0)
        {
            _view.WriteLine($"{unit.Name} obtiene Spd+{unit.BonusStatsDiff.Spd}");
        }
        if (unit.BonusStatsDiff.Def > 0)
        {
            _view.WriteLine($"{unit.Name} obtiene Def+{unit.BonusStatsDiff.Def}");
        }
        if (unit.BonusStatsDiff.Res > 0)
        {
            _view.WriteLine($"{unit.Name} obtiene Res+{unit.BonusStatsDiff.Res}");
        }
    }
    
    private void ShowBonusStatsEffectsOnFirstAttackOnUnit(Unit unit)
    {
        if (unit.FirstAttackBonusStatsDiff.Atk > 0)
        {
            _view.WriteLine($"{unit.Name} obtiene Atk+{unit.FirstAttackBonusStatsDiff.Atk} en su primer ataque");
        }
        if (unit.FirstAttackBonusStatsDiff.Def > 0)
        {
            _view.WriteLine($"{unit.Name} obtiene Def+{unit.FirstAttackBonusStatsDiff.Def} en su primer ataque");
        }
        if (unit.FirstAttackBonusStatsDiff.Res > 0)
        {
            _view.WriteLine($"{unit.Name} obtiene Res+{unit.FirstAttackBonusStatsDiff.Res} en su primer ataque");
        }
    }
    
    private void ShowBonusStatsEffectsOnFollowUpOnUnit(Unit unit)
    {
        if (unit.FollowUpAttackBonusStatsDiff.Atk > 0)
        {
            _view.WriteLine($"{unit.Name} obtiene Atk+{unit.FollowUpAttackBonusStatsDiff.Atk} en su Follow-Up");
        }
        if (unit.FollowUpAttackBonusStatsDiff.Def > 0)
        {
            _view.WriteLine($"{unit.Name} obtiene Def+{unit.FollowUpAttackBonusStatsDiff.Def} en su Follow-Up");
        }
        if (unit.FollowUpAttackBonusStatsDiff.Res > 0)
        {
            _view.WriteLine($"{unit.Name} obtiene Res+{unit.FollowUpAttackBonusStatsDiff.Res} en su Follow-Up");
        }
    }
    
    private void ShowPenaltyStatsEffectsOfUnit(Unit unit)
    {
        if (unit.PenaltyStatsDiff.Atk < 0)
        {
            _view.WriteLine($"{unit.Name} obtiene Atk{unit.PenaltyStatsDiff.Atk}");
        }
        if (unit.PenaltyStatsDiff.Spd < 0)
        {
            _view.WriteLine($"{unit.Name} obtiene Spd{unit.PenaltyStatsDiff.Spd}");
        }
        if (unit.PenaltyStatsDiff.Def < 0)
        {
            _view.WriteLine($"{unit.Name} obtiene Def{unit.PenaltyStatsDiff.Def}");
        }
        if (unit.PenaltyStatsDiff.Res < 0)
        {
            _view.WriteLine($"{unit.Name} obtiene Res{unit.PenaltyStatsDiff.Res}");
        }
    }
    
    private void ShowPenaltyStatsEffectsOnFirstAttackOnUnit(Unit unit)
    {
        if (unit.FirstAttackPenaltyStatsDiff.Atk < 0)
        {
            _view.WriteLine($"{unit.Name} obtiene Atk{unit.FirstAttackPenaltyStatsDiff.Atk} en su primer ataque");
        }
        if (unit.FirstAttackPenaltyStatsDiff.Def < 0)
        {
            _view.WriteLine($"{unit.Name} obtiene Def{unit.FirstAttackPenaltyStatsDiff.Def} en su primer ataque");
        }
        if (unit.FirstAttackPenaltyStatsDiff.Res < 0)
        {
            _view.WriteLine($"{unit.Name} obtiene Res{unit.FirstAttackPenaltyStatsDiff.Res} en su primer ataque");
        }
    }
    
    private void ShowPenaltyStatsEffectsOnFollowUpOnUnit(Unit unit)
    {
        if (unit.FollowUpAttackPenaltyStatsDiff.Atk < 0)
        {
            _view.WriteLine($"{unit.Name} obtiene Atk{unit.FollowUpAttackPenaltyStatsDiff.Atk} en su Follow-Up");
        }
        if (unit.FollowUpAttackPenaltyStatsDiff.Def < 0)
        {
            _view.WriteLine($"{unit.Name} obtiene Def{unit.FollowUpAttackPenaltyStatsDiff.Def} en su Follow-Up");
        }
        if (unit.FollowUpAttackPenaltyStatsDiff.Res < 0)
        {
            _view.WriteLine($"{unit.Name} obtiene Res{unit.FollowUpAttackPenaltyStatsDiff.Res} en su Follow-Up");
        }
    }
    
    private void ShowNeutralizedBonusByStats(Unit unit)
    {
        if (unit.BonusNeutralizationManager.Atk == 0)
        {
            _view.WriteLine($"Los bonus de Atk de {unit.Name} fueron neutralizados");
        }
        if (unit.BonusNeutralizationManager.Spd == 0)
        {
            _view.WriteLine($"Los bonus de Spd de {unit.Name} fueron neutralizados");
        }
        if (unit.BonusNeutralizationManager.Def == 0)
        {
            _view.WriteLine($"Los bonus de Def de {unit.Name} fueron neutralizados");
        }
        if (unit.BonusNeutralizationManager.Res == 0)
        {
            _view.WriteLine($"Los bonus de Res de {unit.Name} fueron neutralizados");
        }
    }
    
    private void ShowNeutralizedPenaltyByStats(Unit unit)
    {
        if (unit.PenaltyNeutralizationManager.Atk == 0)
        {
            _view.WriteLine($"Los penalty de Atk de {unit.Name} fueron neutralizados");
        }
        if (unit.PenaltyNeutralizationManager.Spd == 0)
        {
            _view.WriteLine($"Los penalty de Spd de {unit.Name} fueron neutralizados");
        }
        if (unit.PenaltyNeutralizationManager.Def == 0)
        {
            _view.WriteLine($"Los penalty de Def de {unit.Name} fueron neutralizados");
        }
        if (unit.PenaltyNeutralizationManager.Res == 0)
        {
            _view.WriteLine($"Los penalty de Res de {unit.Name} fueron neutralizados");
        }
    }
    
    private void ShowExtraDamagePermanentEffects(Unit unit)
    {
        if (unit.DamageEffectsManager.ExtraDamagePermanent > 0)
        {
            _view.WriteLine($"{unit.Name} realizará +{unit.DamageEffectsManager.ExtraDamagePermanent} daño extra en cada ataque");
        }
    }
    
    private void ShowExtraDamageFirstAttackEffects(Unit unit)
    {
        if (unit.DamageEffectsManager.ExtraDamageFirstAttack > 0)
        {
            _view.WriteLine($"{unit.Name} realizará +{unit.DamageEffectsManager.ExtraDamageFirstAttack} daño extra en su primer ataque");
        }
    }
    
    private void ShowExtraDamageFollowUpEffects(Unit unit)
    {
        if (unit.DamageEffectsManager.ExtraDamageFollowUp > 0)
        {
            _view.WriteLine($"{unit.Name} realizará +{unit.DamageEffectsManager.ExtraDamageFollowUp} daño extra  en su Follow-Up");
        }
    }

    private void ShowPercentagePermanentReducedDamage(Unit unit)
    {
        if (unit.DamageEffectsManager.DamagePercentageReductionPermanent > 0)
        {
            _view.WriteLine($"{unit.Name} reducirá el daño de los ataques del rival en un {Convert.ToInt32(unit.DamageEffectsManager.DamagePercentageReductionPermanent * 100)}%");
        }
    }

    private void ShowPercentageOpponentFirstAttackReducedDamage(Unit unit)
    {
        if (unit.DamageEffectsManager.DamagePercentageReductionFirstAttack > 0)
        {
            _view.WriteLine($"{unit.Name} reducirá el daño del primer ataque del rival en un {Convert.ToInt32(unit.DamageEffectsManager.DamagePercentageReductionFirstAttack * 100)}%");
        }  
    }
    
    private void ShowPercentageOpponentFollowUpReducedDamage(Unit unit)
    {
        if (unit.DamageEffectsManager.DamagePercentageReductionFollowUp > 0)
        {
            _view.WriteLine($"{unit.Name} reducirá el daño del Follow-Up del rival en un {Convert.ToInt32(unit.DamageEffectsManager.DamagePercentageReductionFollowUp * 100)}%");
        }  
    }

    private void ShowAbsolutePermanentReducedDamage(Unit unit)
    {
        if (unit.DamageEffectsManager.DamageAbsoluteReductionPermanent > 0)
        {
            _view.WriteLine($"{unit.Name} recibirá -{unit.DamageEffectsManager.DamageAbsoluteReductionPermanent} daño en cada ataque");
        }  
    }
}