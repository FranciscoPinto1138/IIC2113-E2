namespace Fire_Emblem;

public class SkillsFactory
{
    private Unit _unit;
    private Unit _opponent;
    private Stats _unitCombatStats;
    private Stats _opponentCombatStats;
    
    public SkillsFactory(Unit unit, Unit opponent, Stats unitCombatStats, Stats opponentCombatStats)
    {
        this._unit = unit;
        this._opponent = opponent;
        this._unitCombatStats = unitCombatStats;
        this._opponentCombatStats = opponentCombatStats;
    }
    
    public Skill CreateSkill(string name)
    {
        switch (name)
        {
            case "Fair Fight":
                return new FairFight(_unit, _opponent, _unitCombatStats, _opponentCombatStats);
            case "Will to Win":
                return new WillToWin(_unit, _opponent,  _unitCombatStats, _opponentCombatStats);
            default:
                return null;
        }
    }
}