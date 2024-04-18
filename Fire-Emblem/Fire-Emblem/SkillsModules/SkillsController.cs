namespace Fire_Emblem;

public class SkillsController
{
    private Unit _attackUnit;
    private Unit _defenseUnit;
    private string _firstPlayerOfRoundName;
    private string _secondPlayerOfRoundName;
    private List<Skill> _attackUnitSkills;
    private List<Skill> _defenseUnitSkills;
    
    public SkillsController(Unit attackUnit, Unit defenseUnit, string firstPlayerOfRoundName, string secondPlayerOfRoundName)
    {
        this._attackUnit = attackUnit;
        this._defenseUnit = defenseUnit;
        this._firstPlayerOfRoundName = firstPlayerOfRoundName;
        this._secondPlayerOfRoundName = secondPlayerOfRoundName;
    }
    
    public void CreateSkills()
    {
        SkillsFactory attackersSkillsFactory = new SkillsFactory(_attackUnit, _defenseUnit, _firstPlayerOfRoundName, _secondPlayerOfRoundName);
        SkillsFactory defendersSkillsFactory = new SkillsFactory(_defenseUnit, _attackUnit, _secondPlayerOfRoundName, _firstPlayerOfRoundName);
        foreach (string skillName in _attackUnit.Skill)
        {
            Skill skill = attackersSkillsFactory.CreateSkill(skillName);
            if (skill != null)
            {
                _attackUnitSkills.Add(skill);
            }
        }
        foreach (string skillName in _defenseUnit.Skill)
        {
            Skill skill = defendersSkillsFactory.CreateSkill(skillName);
            if (skill != null)
            {
                _defenseUnitSkills.Add(skill);
            }
        }
    }
    
    public void ApplySkills()
    {
        foreach (Skill skill in _attackUnitSkills)
        {
            skill.ApplyEffectsIfConditionsAreSatisfied(_attackUnit, _defenseUnit);
        }
        foreach (Skill skill in _defenseUnitSkills)
        {
            skill.ApplyEffectsIfConditionsAreSatisfied(_defenseUnit, _attackUnit);
        }
    }
}