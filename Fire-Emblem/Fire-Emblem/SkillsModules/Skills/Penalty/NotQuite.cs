namespace Fire_Emblem;

public class NotQuite : Penalty
{
    public NotQuite()
    {
        this.Name = "Not *Quite*";
        this.Description = "Si el rival inicia el combate, inflige Atk-4 en ese rival durante el combate";
    }

    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var condition = new UnitStartsCombatCondition();
        var effectOnUnit = new DecreaseStat(4, StatType.Atk);
        if (condition.IsConditionFulfilled(opponent, unit))
        {
            effectOnUnit.ApplyEffect(opponent, unit);
        }
    }
}