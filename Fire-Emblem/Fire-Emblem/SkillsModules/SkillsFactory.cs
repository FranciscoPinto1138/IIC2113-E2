namespace Fire_Emblem;

public class SkillsFactory
{
    private Unit _unit;
    private Unit _opponent;
    
    public SkillsFactory(Unit unit, Unit opponent)
    {
        this._unit = unit;
        this._opponent = opponent;
    }
    
    public Skill CreateSkill(string name)
    {
        switch (name)
        {
            case "Fair Fight":
                return new FairFight(_unit, _opponent);
            case "Will to Win":
                return new WillToWin(_unit, _opponent);
            case "Single-Minded":
                return new SingleMinded(_unit, _opponent);
            case "Perceptive":
                return new Perceptive(_unit, _opponent);
            case "Tome Precision":
                return new TomePrecision(_unit, _opponent);
            case "Attack +6":
                return new StatBuffer(_unit, _opponent, [StatType.Atk], [6]);
            case "Speed +5":
                return new StatBuffer(_unit, _opponent, [StatType.Spd], [5]);
            case "Defense +5":
                return new StatBuffer(_unit, _opponent, [StatType.Def], [5]);
            case "Wrath":
                return new Wrath(_unit, _opponent);
            case "Resolve":
                return new Resolve(_unit, _opponent);
            case "Resistance +5":
                return new StatBuffer(_unit, _opponent, [StatType.Res], [5]);
            case "Atk/Def +5":
                return new StatBuffer(_unit, _opponent, [StatType.Atk, StatType.Def], [5, 5]);
            case "Atk/Res +5":
                return new StatBuffer(_unit, _opponent, [StatType.Atk, StatType.Res], [5, 5]);
            case "Spd/Res +5":
                return new StatBuffer(_unit, _opponent, [StatType.Spd, StatType.Res], [5, 5]);
            default:
                return null;
        }
    }
}