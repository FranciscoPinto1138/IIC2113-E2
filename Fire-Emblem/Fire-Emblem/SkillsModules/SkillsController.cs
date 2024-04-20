using Fire_Emblem_View;

namespace Fire_Emblem;

public class SkillsController
{
    private Unit _attackUnit;
    private Unit _defenseUnit;
    private List<Skill> _attackUnitSkills;
    private List<Skill> _defenseUnitSkills;
    private View _view;
    
    public SkillsController(Unit attackUnit, Unit defenseUnit, View view)
    {
        this._attackUnit = attackUnit;
        this._defenseUnit = defenseUnit;
        this._attackUnitSkills = new List<Skill>();
        this._defenseUnitSkills = new List<Skill>();
        this._view = view;
    }
    
    public void CreateSkills()
    {
        SkillsFactory attackersSkillsFactory = new SkillsFactory(_attackUnit, _defenseUnit);
        SkillsFactory defendersSkillsFactory = new SkillsFactory(_defenseUnit, _attackUnit);
        CreateSkillsOfUnit(_attackUnit, _attackUnitSkills, attackersSkillsFactory);
        CreateSkillsOfUnit(_defenseUnit, _defenseUnitSkills, defendersSkillsFactory);
    }
    
    private void CreateSkillsOfUnit(Unit unit, List<Skill> skillsList, SkillsFactory factory)
    {
        if (unit.Skill.Length == 0) return;
        foreach (string skillName in unit.Skill)
        {
            Skill skill = factory.CreateSkill(skillName);
            if (skill != null)
            {
                skillsList.Add(skill);
            }
        }
    } 
    
    public void ApplySkills()
    {
        if (_attackUnitSkills.Count > 0)
        {
            foreach (Skill skill in _attackUnitSkills)
            {
                skill.ApplyEffectsIfConditionsAreSatisfied(_attackUnit, _defenseUnit);
            }
        }
        if (_defenseUnitSkills.Count > 0)
        {
            foreach (Skill skill in _defenseUnitSkills)
            {
                skill.ApplyEffectsIfConditionsAreSatisfied(_defenseUnit, _attackUnit);
            }
        }
        ShowNetStatsOfUnitsAfterEffects();
    }
    
    private void ShowNetStatsOfUnitsAfterEffects()
    {
        ShowNetStatsEffects(_attackUnit);
        ShowNeutralizedBonusAndPenalties(_attackUnit);
        ShowNetStatsEffects(_defenseUnit);
        ShowNeutralizedBonusAndPenalties(_defenseUnit);
    }
    
    private void ShowNetStatsEffects(Unit unit)
    {
        ShowBonusStatsEffectsOfUnit(unit);
        ShowPenaltyStatsEffectsOfUnit(unit);
    }

    private void ShowNeutralizedBonusAndPenalties(Unit unit)
    {
        ShowNeutralizedBonusByStats(unit);
        ShowNeutralizedPenaltyByStats(unit);
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
}