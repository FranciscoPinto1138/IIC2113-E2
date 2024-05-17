using Fire_Emblem;
using Fire_Emblem.Hybrids;
using Fire_Emblem.SkillsModules.Skills.Hybrids;

namespace Fire_Emblem;

public class SkillsFactory
{
    public Skill CreateSkill(string name)
    {
        switch (name)
        {
            case "HP +15":
                return new HPPlus15();
            case "Fair Fight":
                return new FairFight();
            case "Will to Win":
                return new WillToWin();
            case "Single-Minded":
                return new SingleMinded();
            case "Ignis":
                return new Ignis();
            case "Perceptive":
                return new Perceptive();
            case "Tome Precision":
                return new TomePrecision();
            case "Attack +6":
                return new StatBuffer([StatType.Atk], [6]);
            case "Speed +5":
                return new StatBuffer([StatType.Spd], [5]);
            case "Defense +5":
                return new StatBuffer([StatType.Def], [5]);
            case "Wrath":
                return new Wrath();
            case "Resolve":
                return new Resolve();
            case "Resistance +5":
                return new StatBuffer([StatType.Res], [5]);
            case "Atk/Def +5":
                return new StatBuffer([StatType.Atk, StatType.Def], [5, 5]);
            case "Atk/Res +5":
                return new StatBuffer([StatType.Atk, StatType.Res], [5, 5]);
            case "Spd/Res +5":
                return new StatBuffer([StatType.Spd, StatType.Res], [5, 5]);
            case "Deadly Blade":
                return new DeadlyBlade();
            case "Death Blow":
                return new BlowStrikeSparrow([StatType.Atk], [8]);
            case "Armored Blow":
                return new BlowStrikeSparrow([StatType.Def], [8]);
            case "Darting Blow":
                return new BlowStrikeSparrow([StatType.Spd], [8]);
            case "Warding Blow":
                return new BlowStrikeSparrow([StatType.Res], [8]);
            case "Swift Sparrow":
                return new BlowStrikeSparrow([StatType.Atk, StatType.Spd], [6, 6]);
            case "Sturdy Blow":
                return new BlowStrikeSparrow([StatType.Atk, StatType.Def], [6, 6]);
            case "Mirror Strike":
                return new BlowStrikeSparrow([StatType.Atk, StatType.Res], [6, 6]);
            case "Steady Blow":
                return new BlowStrikeSparrow([StatType.Spd, StatType.Def], [6, 6]);
            case "Swift Strike":
                return new BlowStrikeSparrow([StatType.Spd, StatType.Res], [6, 6]);
            case "Bracing Blow":
                return new BlowStrikeSparrow([StatType.Def, StatType.Res], [6, 6]);
            case "Brazen Atk/Spd":
                return new Brazen([StatType.Atk, StatType.Spd], [10, 10]);
            case "Brazen Atk/Def":
                return new Brazen([StatType.Atk, StatType.Def], [10, 10]);
            case "Brazen Atk/Res":
                return new Brazen([StatType.Atk, StatType.Res], [10, 10]);
            case "Brazen Spd/Def":
                return new Brazen([StatType.Spd, StatType.Def], [10, 10]);
            case "Brazen Spd/Res":
                return new Brazen([StatType.Spd, StatType.Res], [10, 10]);
            case "Brazen Def/Res":
                return new Brazen([StatType.Def, StatType.Res], [10, 10]);
            case "Fire Boost":
                return new Boost([StatType.Atk], [6]);
            case "Wind Boost":
                return new Boost([StatType.Spd], [6]);
            case "Earth Boost":
                return new Boost([StatType.Def], [6]);
            case "Water Boost":
                return new Boost([StatType.Res], [6]);
            case "Chaos Style":
                return new ChaosStyle();
            case "Blinding Flash":
                return new BlindingFlash();
            case "Not *Quite*":
                return new NotQuite();
            case "Stunning Smile":
                return new StunningSmile();
            case "Disarming Sigh":
                return new DisarmingSigh();
            case "Charmer":
                return new Charmer();
            case "Luna":
                return new Luna();
            case "Belief in Love":
                return new BeliefInLove();
            case "Beorc's Blessing":
                return new BeorcsBlessing();
            case "Agnea's Arrow":
                return new AgneasArrow();
            case "Soulblade":
                return new Soulblade();
            case "Sandstorm":
                return new Sandstorm();
            case "Sword Agility":
                return new AgilityPowerFocus("Sword", [StatType.Spd], [12], [StatType.Atk], [6]);
            case "Lance Power":
                return new AgilityPowerFocus("Lance", [StatType.Atk], [10], [StatType.Def], [10]);
            case "Sword Power":
                return new AgilityPowerFocus("Sword", [StatType.Atk], [10], [StatType.Def], [10]);
            case "Bow Focus":
                return new AgilityPowerFocus("Bow", [StatType.Atk], [10], [StatType.Res], [10]);
            case "Lance Agility":
                return new AgilityPowerFocus("Lance", [StatType.Spd], [12], [StatType.Atk], [6]);
            case "Axe Power":
                return new AgilityPowerFocus("Axe", [StatType.Atk], [10], [StatType.Def], [10]);
            case "Bow Agility":
                return new AgilityPowerFocus("Bow", [StatType.Spd], [12], [StatType.Atk], [6]);
            case "Sword Focus":
                return new AgilityPowerFocus("Sword", [StatType.Atk], [10], [StatType.Res], [10]);
            case "Close Def":
                return new CloseDef();
            case "Distant Def":
                return new DistantDef();
            case "Lull Atk/Spd":
                return new Lull([StatType.Atk, StatType.Spd], [3, 3], [StatType.Atk, StatType.Spd]);
            case "Lull Atk/Def":
                return new Lull([StatType.Atk, StatType.Def], [3, 3], [StatType.Atk, StatType.Def]);
            case "Lull Atk/Res":
                return new Lull([StatType.Atk, StatType.Res], [3, 3], [StatType.Atk, StatType.Res]);
            case "Lull Spd/Def":
                return new Lull([StatType.Spd, StatType.Def], [3, 3], [StatType.Spd, StatType.Def]);
            case "Lull Spd/Res":
                return new Lull([StatType.Spd, StatType.Res], [3, 3], [StatType.Spd, StatType.Res]);
            case "Lull Def/Res":
                return new Lull([StatType.Def, StatType.Res], [3, 3], [StatType.Def, StatType.Res]);
            case "Fort. Def/Res":
                return new FortDefRes();
            case "Life and Death":
                return new LifeAndDeath();
            case "Solid Ground":
                return new SolidGround();
            case "Still Water":
                return new StillWater();
            case "Dragonskin":
                return new Dragonskin();
            case "Light and Dark":
                return new LightAndDark();
            case "Dragon Wall":
                return new DragonWall();
            case "Dodge":
                return new Dodge();
            case "Golden Lotus":
                return new GoldenLotus();
            case "Gentility":
                return new Gentility();
            case "Bow Guard":
                return new Guard("Bow");
            case "Arms Shield":
                return new ArmsShield();
            case "Axe Guard":
                return new Guard("Axe");
            case "Magic Guard":
                return new Guard("Magic");
            case "Lance Guard":
                return new Guard("Lance");
            case "Sympathetic":
                return new Sympathetic();
            case "Bravery":
                return new Bravery();
            case "Lunar Brace":
                return new LunarBrace();
            case "Back at You":
                return new BackAtYou();
            case "Bushido":
                return new Bushido();
            case "Moon-Twin Wing":
                return new MoonTwinWing();
            case "Blue Skies":
                return new BlueSkies();
            case "Aegis Shield":
                return new AegisShield();
            case "Remote Sparrow":
                return new Remote([StatType.Atk, StatType.Spd], [7, 7]);
            case "Remote Mirror":
                return new Remote([StatType.Atk, StatType.Res], [7, 10]);
            case "Remote Sturdy":
                return new Remote([StatType.Atk, StatType.Def], [7, 10]);
            case "Fierce Stance":
                return new Stance([StatType.Atk], [8]);
            case "Darting Stance":
                return new Stance([StatType.Spd], [8]);
            case "Steady Stance":
                return new Stance([StatType.Def], [8]);
            case "Warding Stance":
                return new Stance([StatType.Res], [8]);
            case "Kestrel Stance":
                return new Stance([StatType.Atk, StatType.Spd], [6, 6]);
            case "Sturdy Stance":
                return new Stance([StatType.Atk, StatType.Def], [6, 6]);
            case "Mirror Stance":
                return new Stance([StatType.Atk, StatType.Res], [6, 6]);
            case "Steady Posture":
                return new Stance([StatType.Spd, StatType.Def], [6, 6]);
            case "Swift Stance":
                return new Stance([StatType.Spd, StatType.Res], [6, 6]);
            case "Bracing Stance":
                return new Stance([StatType.Def, StatType.Res], [6, 6]);
            case "Poetic Justice":
                return new PoeticJustice();
            case "Laguz Friend":
                return new LaguzFriend();
            case "Chivalry":
                return new Chivalry();
            case "Dragon's Wrath":
                return new DragonsWrath();
            case "Prescience":
                return new Prescience();
            case "Extra Chivalry":
                return new ExtraChivalry();
            case "Guard Bearing":
                return new GuardBearing();
            case "Divine Recreation":
                return new DivineRecreation();
            default:
                return new EmptySkill();
        }
    }
}