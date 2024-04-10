namespace Fire_Emblem;

public class Unit
{
    public string Name;
    public string Weapon;
    public string Gender;
    public string DeathQuote;
    public string[] Skill;
    public int HPMax;
    public int HPCurrent;
    public int Atk;
    public int Spd;
    public int Def;
    public int Res;

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
        const int maxValidAmountOfSkills = 2;
        if (Skill.Length == maxValidAmountOfSkills)
        {
            if (Skill[0] == Skill[1])
            {
                return true;
            }
        }

        return false;
    }
}