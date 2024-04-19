namespace Fire_Emblem;

public class SkillsFactory
{
    private Unit _unit;
    private Unit _opponent;
    private string _firstPlayerOfRoundName;
    private string _secondPlayerOfRoundName;
    private Stats _unitCombatStats;
    private Stats _opponentCombatStats;
    
    public SkillsFactory(Unit unit, Unit opponent, string firstPlayerOfRoundName, string secondPlayerOfRoundName, Stats unitCombatStats, Stats opponentCombatStats)
    {
        this._unit = unit;
        this._opponent = opponent;
        this._firstPlayerOfRoundName = firstPlayerOfRoundName;
        this._secondPlayerOfRoundName = secondPlayerOfRoundName;
        this._unitCombatStats = unitCombatStats;
        this._opponentCombatStats = opponentCombatStats;
    }
    
    public Skill CreateSkill(string name)
    {
        switch (name)
        {
            case "Fair Fight":
                return new FairFight(_unit, _opponent, _firstPlayerOfRoundName, _secondPlayerOfRoundName, _unitCombatStats, _opponentCombatStats);
            case "Will to Win":
                return new WillToWin(_unit, _opponent, _firstPlayerOfRoundName, _secondPlayerOfRoundName, _unitCombatStats, _opponentCombatStats);
            default:
                return null;
        }
    }
}