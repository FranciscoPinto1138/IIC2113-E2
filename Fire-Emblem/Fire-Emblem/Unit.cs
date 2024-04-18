namespace Fire_Emblem;

public class Unit
{
    public string Name { get; set;}
    public string Weapon { get; set;}
    public string Gender { get; set;}
    public string DeathQuote { get; set;}
    public string[] Skill { get; set;}
    public int HPMax { get; set;}
    public int HPCurrent { get; set;}
    public int Atk { get; set;}
    public int Spd { get; set;}
    public int Def { get; set;}
    public int Res { get; set;}
    public string MostRecentRival { get; set; } = null!;
    private int _maxAmountOfSkills = 2;

    public Unit(string name, string weapon, string gender, string deathQuote, string[] skill, int hp, int atk, int spd, int def,
        int res)
    {
        this.Name = name;
        this.Weapon = weapon;
        this.Gender = gender;
        this.DeathQuote = deathQuote;
        this.Skill = skill;
        this.HPMax = hp;
        this.HPCurrent = HPMax;
        this.Atk = atk;
        this.Spd = spd;
        this.Def = def;
        this.Res = res;
    }
    
    public bool UnitHasEqualSkills()
    {
        if (Skill.Length == _maxAmountOfSkills)
        {
            if (Skill[0] == Skill[1])
            {
                return true;
            }
        }

        return false;
    }
    
    public bool UnitHasValidAmountOfSkills()
    {
        return Skill.Length <= _maxAmountOfSkills;
    }
}