using Fire_Emblem_View;

namespace Fire_Emblem;

public class SkillsController
{
    private Unit _attackUnit;
    private Unit _defenseUnit;
    private List<Skill> _attackUnitSkills;
    private List<Skill> _defenseUnitSkills;
    private List<ConditionEffectPair> _attackUnitConditionEffectPairList;
    private List<ConditionEffectPair> _defenseUnitConditionEffectPairList;
    private View _view;
    
    public SkillsController(Unit attackUnit, Unit defenseUnit, View view)
    {
        this._attackUnit = attackUnit;
        this._defenseUnit = defenseUnit;
        this._attackUnitSkills = new List<Skill>();
        this._defenseUnitSkills = new List<Skill>();
        this._attackUnitConditionEffectPairList = new List<ConditionEffectPair>();
        this._defenseUnitConditionEffectPairList = new List<ConditionEffectPair>();
        this._view = view;
    }
    
    public void CreateSkills()
    {
        SkillsFactory attackersSkillsFactory = new SkillsFactory(_attackUnit, _defenseUnit);
        SkillsFactory defendersSkillsFactory = new SkillsFactory(_defenseUnit, _attackUnit);
        CreateSkillsOfUnit(_attackUnit, _attackUnitSkills, attackersSkillsFactory);
        CreateSkillsOfUnit(_defenseUnit, _defenseUnitSkills, defendersSkillsFactory);
        AddSkillsConditionEffectPairsOfUnits();
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

    private void AddSkillsConditionEffectPairsOfUnits()
    {
        AddSkillsConditionEffectPairs(_attackUnit, _defenseUnit, _attackUnitSkills, _attackUnitConditionEffectPairList);
        AddSkillsConditionEffectPairs(_defenseUnit, _attackUnit, _defenseUnitSkills, _defenseUnitConditionEffectPairList);
    }

    private void AddSkillsConditionEffectPairs(Unit unit, Unit opponent, List<Skill> skills, List<ConditionEffectPair> unitConditionEffectPairsList)
    {
        if (skills.Count > 0)
        {
            foreach (Skill skill in skills)
            {
                foreach (ConditionEffectPair conditionEffectPair in skill.GetConditionEffectPairs(unit, opponent))
                {
                    unitConditionEffectPairsList.Add(conditionEffectPair);
                }
            }
        }
    }

    public void ApplyUnitsSkillsEffectsIfConditionsAreSatisfiedByPriority(int priority)
    {
        ApplyUnitSkillsEffectsIfConditionsAreSatisfiedByPriority(_attackUnit, _defenseUnit, _attackUnitConditionEffectPairList, priority);
        ApplyUnitSkillsEffectsIfConditionsAreSatisfiedByPriority(_defenseUnit, _attackUnit, _defenseUnitConditionEffectPairList, priority);
    }
    
    private void ApplyUnitSkillsEffectsIfConditionsAreSatisfiedByPriority(Unit attackUnit, Unit defenseUnit, List<ConditionEffectPair> unitConditionEffectPairsList, int priority)
    {
        if (unitConditionEffectPairsList.Count > 0)
        {
            foreach (ConditionEffectPair conditionEffectPair in unitConditionEffectPairsList)
            {
                if (conditionEffectPair.GetPriority() == priority)
                {
                    conditionEffectPair.ApplyEffectIfConditionIsSatisfied(attackUnit, defenseUnit);
                }
            }
        }
    }
    
    public void ShowAllSkillsNetStatsOfUnitsAfterEffects()
    {
        SkillsEffectsShower skillsEffectsShower = new SkillsEffectsShower(_attackUnit, _defenseUnit, _view);
        skillsEffectsShower.ShowNetStatsOfUnitsAfterEffects();
    }
}