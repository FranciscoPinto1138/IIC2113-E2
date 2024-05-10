namespace Fire_Emblem;

public class StunningSmile : Penalty
{
    public StunningSmile()
    {
        this.Name = "Stunning Smile";
        this.Description = "Si el rival es hombre, inflige Spd-8 en ese rival durante el combate.";
    }

    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var condition = new OpponentIsMale();
        var effectOnUnit = new DecreaseStat(8, StatType.Spd);
        if (condition.IsConditionFulfilled(unit, opponent))
        {
            effectOnUnit.ApplyEffect(opponent, unit);
        }
    }
}