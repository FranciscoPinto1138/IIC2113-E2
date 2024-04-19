using Fire_Emblem_View;

namespace Fire_Emblem;

public class SkillsController
{
    private Unit _attackUnit;
    private Unit _defenseUnit;
    private string _firstPlayerOfRoundName;
    private string _secondPlayerOfRoundName;
    private List<Skill> _attackUnitSkills;
    private List<Skill> _defenseUnitSkills;
    private Stats _attackUnitCombatStats;
    private Stats _defenseUnitCombatStats;
    private View _view;
    private Stats _attackUnitOriginalStats;
    private Stats _defenseUnitOriginalStats;
    
    public SkillsController(Unit attackUnit, Unit defenseUnit, Stats attackUnitCombatStats, Stats defenseUnitCombatStats, View view)
    {
        this._attackUnit = attackUnit;
        this._defenseUnit = defenseUnit;
        this._attackUnitCombatStats = attackUnitCombatStats;
        this._defenseUnitCombatStats = defenseUnitCombatStats;
        this._attackUnitSkills = new List<Skill>();
        this._defenseUnitSkills = new List<Skill>();
        this._attackUnitOriginalStats = new Stats(_attackUnit);
        this._defenseUnitOriginalStats = new Stats(_defenseUnit);
        this._view = view;
    }
    
    public void CreateSkills()
    {
        SkillsFactory attackersSkillsFactory = new SkillsFactory(_attackUnit, _defenseUnit, _attackUnitCombatStats, _defenseUnitCombatStats);
        SkillsFactory defendersSkillsFactory = new SkillsFactory(_defenseUnit, _attackUnit, _defenseUnitCombatStats, _attackUnitCombatStats);
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
                skill.ApplyEffectsIfConditionsAreSatisfied(_attackUnit, _defenseUnit, 
                    _attackUnitCombatStats, _defenseUnitCombatStats);
            }
        }
        if (_defenseUnitSkills.Count > 0)
        {
            foreach (Skill skill in _defenseUnitSkills)
            {
                skill.ApplyEffectsIfConditionsAreSatisfied(_defenseUnit, _attackUnit, 
                    _defenseUnitCombatStats, _attackUnitCombatStats);
            }
        }
        ShowNetStatsOfUnitsAfterEffects();
    }
    
    private void ShowNetStatsOfUnitsAfterEffects()
    {
        ShowNetStatsEffects(_attackUnit, _attackUnitCombatStats, _attackUnitOriginalStats);
        ShowNetStatsEffects(_defenseUnit, _defenseUnitCombatStats, _defenseUnitOriginalStats);
    }
    
    private void ShowNetStatsEffects(Unit unit, Stats unitCombatStats, Stats unitOriginalStats)
    {
        Dictionary<string, int> unitStatDifferences = GetStatDifferences(unitCombatStats, unitOriginalStats);
        ShowNetStatsOfUnit(unitStatDifferences, unit);
    }
    
    private void ShowNetStatsOfUnit(Dictionary<string, int> statDifferences, Unit unit)
    {
        foreach (var kvp in statDifferences)
        {
            _view.WriteLine($"{unit.Name} obtiene {kvp.Key}{kvp.Value}");
        }
    }
    
    private Dictionary<string, int> GetStatDifferences(Stats currentStats, Stats originalStats)
    {
        Dictionary<string, int> statDifferences = new Dictionary<string, int>();

        AddStatDifference("Atk", currentStats.Atk, originalStats.Atk, statDifferences);
        AddStatDifference("Spd", currentStats.Spd, originalStats.Spd, statDifferences);
        AddStatDifference("Def", currentStats.Def, originalStats.Def, statDifferences);
        AddStatDifference("Res", currentStats.Res, originalStats.Res, statDifferences);

        return statDifferences;
    }

    private void AddStatDifference(string statName, int currentStat, int originalStat, Dictionary<string, int> statDifferences)
    {
        int difference = currentStat - originalStat;
        if (difference != 0)
        {
            statDifferences.Add($"{statName}{(difference > 0 ? "+" : "-")}", difference);
        }
    }
}