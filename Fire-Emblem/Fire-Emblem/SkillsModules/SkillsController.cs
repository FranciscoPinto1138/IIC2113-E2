using Fire_Emblem_View;

namespace Fire_Emblem;

public class SkillsController
{
    private Unit _attackUnit;
    private Unit _defenseUnit;
    private SkillList _attackUnitSkills;
    private SkillList _defenseUnitSkills;
    private ConditionEffectPairList _attackUnitConditionEffectPairList;
    private ConditionEffectPairList _defenseUnitConditionEffectPairList;
    private SkillsFactory _skillsFactory = new SkillsFactory();
    private View _view;
    
    public SkillsController(Unit attackUnit, Unit defenseUnit, View view)
    {
        this._attackUnit = attackUnit;
        this._defenseUnit = defenseUnit;
        this._attackUnitSkills = new SkillList();
        this._defenseUnitSkills = new SkillList();
        this._attackUnitConditionEffectPairList = new ConditionEffectPairList();
        this._defenseUnitConditionEffectPairList = new ConditionEffectPairList();
        this._view = view;
    }
    
    public void CreateSkills()
    {
        CreateSkillsOfUnit(_attackUnit, _attackUnitSkills);
        CreateSkillsOfUnit(_defenseUnit, _defenseUnitSkills);
        AddSkillsConditionEffectPairsOfUnits();
    }
    
    private void CreateSkillsOfUnit(Unit unit, SkillList skillsList)
    {
        if (unit.Skill.Length == 0) return;
        foreach (string skillName in unit.Skill)
        {
            Skill skill = _skillsFactory.CreateSkill(skillName);
            skillsList.Add(skill);
        }
    }

    private void AddSkillsConditionEffectPairsOfUnits()
    {
        _attackUnitSkills.AddConditionEffectPairs(_attackUnit, _defenseUnit, 
            _attackUnitConditionEffectPairList);
        _defenseUnitSkills.AddConditionEffectPairs(_defenseUnit, _attackUnit, 
            _defenseUnitConditionEffectPairList);
    }

    public void ApplyUnitsSkillsEffectsIfConditionsAreSatisfiedByPriority()
    {
        const int NUMBER_OF_PRIORITIES = 6;
        for (int priority = 1; priority < NUMBER_OF_PRIORITIES + 1; priority++)
        {
            _attackUnitConditionEffectPairList.ApplyEffectsIfConditionsAreSatisfied(_attackUnit, 
                _defenseUnit, priority);
            _defenseUnitConditionEffectPairList.ApplyEffectsIfConditionsAreSatisfied(_defenseUnit, 
                _attackUnit, priority);
        }
    }
    
    public void ShowAllSkillsNetStatsOfUnitsAfterEffects()
    {
        SkillsEffectsShower skillsEffectsShower = new SkillsEffectsShower(_attackUnit, _defenseUnit, _view);
        skillsEffectsShower.ShowNetStatsOfUnitsAfterEffects();
    }
}