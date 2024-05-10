namespace Fire_Emblem;

public class Bravery : ExtraDamage
{
    public Bravery()
    {
        this.Name = "Bravery";
        this.Description = "La unidad inflige +5 de daño en cada ataque.";
    }
    
    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var condition = new NoCondition();
        var effectOnUnit = new IncreaseExtraDamage(5);
        if (condition.IsConditionFulfilled(unit, opponent))
        {
            effectOnUnit.ApplyEffect(unit, opponent);
        }
    }
}