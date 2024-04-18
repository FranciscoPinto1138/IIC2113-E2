namespace Fire_Emblem;

public class SkillsFactory
{
    private Unit _unit;
    private Unit _opponent;
    private string _firstPlayerOfRoundName;
    private string _secondPlayerOfRoundName;
    
    public SkillsFactory(Unit unit, Unit opponent, string firstPlayerOfRoundName, string secondPlayerOfRoundName)
    {
        this._unit = unit;
        this._opponent = opponent;
        this._firstPlayerOfRoundName = firstPlayerOfRoundName;
        this._secondPlayerOfRoundName = secondPlayerOfRoundName;
    }
    
    public Skill CreateSkill(string name)
    {
        switch (name)
        {
            case "Fair Fight":
                return new FairFight(_unit, _opponent, _firstPlayerOfRoundName, _secondPlayerOfRoundName);
            case "Will to Win":
                return new WillToWin(_unit, _opponent, _firstPlayerOfRoundName, _secondPlayerOfRoundName);
            default:
                return null;
        }
    }
}