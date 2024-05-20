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
        AddSkillsConditionEffectPairs(_attackUnit, _defenseUnit, _attackUnitSkills, 
            _attackUnitConditionEffectPairList);
        AddSkillsConditionEffectPairs(_defenseUnit, _attackUnit, _defenseUnitSkills, 
            _defenseUnitConditionEffectPairList);
    }

    private void AddSkillsConditionEffectPairs(Unit unit, Unit opponent, SkillList skills, 
        ConditionEffectPairList unitConditionEffectPairsList)
    {
        if (skills.Count <= 0) return;
        foreach (Skill skill in skills)
        {
            AddConditionEffectPairsOfSkill(unit, opponent, skill, unitConditionEffectPairsList);
        }
    }

    private void AddConditionEffectPairsOfSkill(Unit unit, Unit opponent, Skill skill, 
        ConditionEffectPairList unitConditionEffectPairsList)
    {
        foreach (ConditionEffectPair conditionEffectPair in skill.GetConditionEffectPairs(unit, opponent))
        {
            unitConditionEffectPairsList.Add(conditionEffectPair);
        } 
    }
    
    public void ApplyUnitsSkillsEffectsIfConditionsAreSatisfiedByPriority()
    {
        const int NUMBER_OF_PRIORITIES = 6;
        for (int priority = 1; priority < NUMBER_OF_PRIORITIES + 1; priority++)
        {
            ApplyUnitSkillsEffectsIfConditionsAreSatisfiedByPriority(_attackUnit, _defenseUnit, 
                _attackUnitConditionEffectPairList, priority);
            ApplyUnitSkillsEffectsIfConditionsAreSatisfiedByPriority(_defenseUnit, 
                _attackUnit, _defenseUnitConditionEffectPairList, priority);
        }
    }
    
    private void ApplyUnitSkillsEffectsIfConditionsAreSatisfiedByPriority(Unit attackUnit, Unit defenseUnit, 
        ConditionEffectPairList unitConditionEffectPairsList, int priority)
    {
        if (unitConditionEffectPairsList.Count <= 0) return;
        foreach (ConditionEffectPair conditionEffectPair in unitConditionEffectPairsList)
        {
            if (conditionEffectPair.HasPriority(priority))
            {
                conditionEffectPair.ApplyEffectIfConditionIsSatisfied(attackUnit, defenseUnit);
            }
        }
    }
    
    public void ShowAllSkillsNetStatsOfUnitsAfterEffects()
    {
        SkillsEffectsShower skillsEffectsShower = new SkillsEffectsShower(_attackUnit, _defenseUnit, _view);
        skillsEffectsShower.ShowNetStatsOfUnitsAfterEffects();
    }
}