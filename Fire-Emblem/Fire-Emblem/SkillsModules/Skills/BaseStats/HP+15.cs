namespace Fire_Emblem;

public class HPPlus15 : Bonus
{
    
    public HPPlus15(Unit unit, Unit opponent) : base(unit, opponent)
    {
        this.Name = "HP +15";
        this.Description = "Otorga max HP+15";
        this.unit = unit;
        this.opponent = opponent;
    }

    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        if (unit.MostRecentRival == "")
        {
            var effectOnUnit = new IncreaseHPBaseStat(15);
            effectOnUnit.ApplyEffect(unit, opponent);
        }
    }
}