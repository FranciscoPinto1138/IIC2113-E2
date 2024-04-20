using Fire_Emblem;
using Fire_Emblem.Hybrids;

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
            case "HP +15":
                return new HPPlus15(_unit, _opponent);
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
            case "Deadly Blade":
                return new DeadlyBlade(_unit, _opponent);
            case "Death Blow":
                return new BlowStrikeSparrow(_unit, _opponent, [StatType.Atk], [8]);
            case "Armored Blow":
                return new BlowStrikeSparrow(_unit, _opponent, [StatType.Def], [8]);
            case "Darting Blow":
                return new BlowStrikeSparrow(_unit, _opponent, [StatType.Spd], [8]);
            case "Warding Blow":
                return new BlowStrikeSparrow(_unit, _opponent, [StatType.Res], [8]);
            case "Swift Sparrow":
                return new BlowStrikeSparrow(_unit, _opponent, [StatType.Atk, StatType.Spd], [6, 6]);
            case "Sturdy Blow":
                return new BlowStrikeSparrow(_unit, _opponent, [StatType.Atk, StatType.Def], [6, 6]);
            case "Mirror Strike":
                return new BlowStrikeSparrow(_unit, _opponent, [StatType.Atk, StatType.Res], [6, 6]);
            case "Steady Blow":
                return new BlowStrikeSparrow(_unit, _opponent, [StatType.Spd, StatType.Def], [6, 6]);
            case "Swift Strike":
                return new BlowStrikeSparrow(_unit, _opponent, [StatType.Spd, StatType.Res], [6, 6]);
            case "Bracing Blow":
                return new BlowStrikeSparrow(_unit, _opponent, [StatType.Def, StatType.Res], [6, 6]);
            case "Brazen Atk/Spd":
                return new Brazen(_unit, _opponent, [StatType.Atk, StatType.Spd], [10, 10]);
            case "Brazen Atk/Def":
                return new Brazen(_unit, _opponent, [StatType.Atk, StatType.Def], [10, 10]);
            case "Brazen Atk/Res":
                return new Brazen(_unit, _opponent, [StatType.Atk, StatType.Res], [10, 10]);
            case "Brazen Spd/Def":
                return new Brazen(_unit, _opponent, [StatType.Spd, StatType.Def], [10, 10]);
            case "Brazen Spd/Res":
                return new Brazen(_unit, _opponent, [StatType.Spd, StatType.Res], [10, 10]);
            case "Brazen Def/Res":
                return new Brazen(_unit, _opponent, [StatType.Def, StatType.Res], [10, 10]);
            case "Fire Boost":
                return new Boost(_unit, _opponent, [StatType.Atk], [6]);
            case "Wind Boost":
                return new Boost(_unit, _opponent, [StatType.Spd], [6]);
            case "Earth Boost":
                return new Boost(_unit, _opponent, [StatType.Def], [6]);
            case "Water Boost":
                return new Boost(_unit, _opponent, [StatType.Res], [6]);
            case "Chaos Style":
                return new ChaosStyle(_unit, _opponent);
            case "Blinding Flash":
                return new BlindingFlash(_unit, _opponent);
            case "Not *Quite*":
                return new NotQuite(_unit, _opponent);
            case "Stunning Smile":
                return new StunningSmile(_unit, _opponent);
            case "Disarming Sigh":
                return new DisarmingSigh(_unit, _opponent);
            case "Beorc's Blessing":
                return new BeorcsBlessing(_unit, _opponent);
            case "Agnea's Arrow":
                return new AgneasArrow(_unit, _opponent);
            case "Sword Agility":
                return new AgilityPowerFocus(_unit, _opponent, "Sword", [StatType.Spd], [12], [StatType.Atk], [6]);
            case "Lance Power":
                return new AgilityPowerFocus(_unit, _opponent, "Lance", [StatType.Atk], [10], [StatType.Def], [10]);
            case "Sword Power":
                return new AgilityPowerFocus(_unit, _opponent, "Sword", [StatType.Atk], [10], [StatType.Def], [10]);
            case "Bow Focus":
                return new AgilityPowerFocus(_unit, _opponent, "Bow", [StatType.Atk], [10], [StatType.Res], [10]);
            case "Lance Agility":
                return new AgilityPowerFocus(_unit, _opponent, "Lance", [StatType.Spd], [12], [StatType.Atk], [6]);
            case "Axe Power":
                return new AgilityPowerFocus(_unit, _opponent, "Axe", [StatType.Atk], [10], [StatType.Def], [10]);
            case "Bow Agility":
                return new AgilityPowerFocus(_unit, _opponent, "Bow", [StatType.Spd], [12], [StatType.Atk], [6]);
            case "Sword Focus":
                return new AgilityPowerFocus(_unit, _opponent, "Sword", [StatType.Atk], [10], [StatType.Res], [10]);
            case "Lull Atk/Spd":
                return new Lull(_unit, _opponent, [StatType.Atk, StatType.Spd], [3, 3], [StatType.Atk, StatType.Spd]);
            case "Lull Atk/Def":
                return new Lull(_unit, _opponent, [StatType.Atk, StatType.Def], [3, 3], [StatType.Atk, StatType.Def]);
            case "Lull Atk/Res":
                return new Lull(_unit, _opponent, [StatType.Atk, StatType.Res], [3, 3], [StatType.Atk, StatType.Res]);
            case "Lull Spd/Def":
                return new Lull(_unit, _opponent, [StatType.Spd, StatType.Def], [3, 3], [StatType.Spd, StatType.Def]);
            case "Lull Spd/Res":
                return new Lull(_unit, _opponent, [StatType.Spd, StatType.Res], [3, 3], [StatType.Spd, StatType.Res]);
            case "Lull Def/Res":
                return new Lull(_unit, _opponent, [StatType.Def, StatType.Res], [3, 3], [StatType.Def, StatType.Res]);
            default:
                return null;
        }
    }
}