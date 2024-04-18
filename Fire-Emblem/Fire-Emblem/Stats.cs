using System.Net.Mail;

namespace Fire_Emblem;

public class Stats
{
    public int Atk;
    public int Spd;
    public int Res;
    public int Def;
    public int HPCurrent;
    public int HPMax;

    public Stats(Unit unit)
    {
        this.Atk = unit.Atk;
        this.Spd = unit.Spd;
        this.Res = unit.Res;
        this.Def = unit.Def;
        this.HPCurrent = unit.HPCurrent;
        this.HPMax = unit.HPMax;
    }
}