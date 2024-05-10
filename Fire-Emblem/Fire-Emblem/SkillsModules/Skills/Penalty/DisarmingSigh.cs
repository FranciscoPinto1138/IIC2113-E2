namespace Fire_Emblem;

public class DisarmingSigh : Penalty
{
    public DisarmingSigh()
    {
        this.Name = "Disarming Sigh";
        this.Description = "Si el rival es hombre, inflige Atk-8 en ese rival durante el combate";
    }

    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var condition = new OpponentIsMale();
        var effectOnUnit = new DecreaseStat(8, StatType.Atk);
        if (condition.IsConditionFulfilled(unit, opponent))
        {
            effectOnUnit.ApplyEffect(opponent, unit);
        }
    }
}