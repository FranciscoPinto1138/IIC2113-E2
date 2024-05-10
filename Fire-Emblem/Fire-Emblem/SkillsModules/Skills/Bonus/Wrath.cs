namespace Fire_Emblem;

public class Wrath : Bonus
{
    public Wrath()
    {
        this.Name = "Wrath";
        this.Description = "Al inicio del combate, por cada punto de HP que la unidad ha perdido, otorga Atk/Spd+1 durante el combate. (Max +30)";
    }

    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var condition = new NoCondition();
        var effectOnUnit = new IncreaseAtkSpdByLostHP();
        if (condition.IsConditionFulfilled(unit, opponent))
        {
            effectOnUnit.ApplyEffect(unit, opponent);
        }
    }
}