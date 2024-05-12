using Fire_Emblem_View;

namespace Fire_Emblem;

public class SkillsController
{
    private Unit _attackUnit;
    private Unit _defenseUnit;
    private List<Skill> _attackUnitSkills;
    private List<Skill> _defenseUnitSkills;
    private ConditionEffectPairList _attackUnitConditionEffectPairList;
    private ConditionEffectPairList _defenseUnitConditionEffectPairList;
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
    }
    
    public void ShowAllSkillsNetStatsOfUnitsAfterEffects()
    {
        SkillsEffectsShower skillsEffectsShower = new SkillsEffectsShower(_attackUnit, _defenseUnit, _view);
        skillsEffectsShower.ShowNetStatsOfUnitsAfterEffects();
    }
}