namespace Fire_Emblem;

public class Luna : Penalty
{
    public Luna()
    {
        this.Name = "Luna";
        this.Description = "Durante el primer ataque de la unidad, ignora la mitad de Def y Res base del rival. (Considere esta reduccion como un Penalty).";
    }

    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var condition = new NoCondition();
        var effectOnUnit = new DecreaseStatByPercentageOnFirstAttack(50, StatType.Def);
        var effectOnUnitAdditional = new DecreaseStatByPercentageOnFirstAttack(50, StatType.Res);
        if (condition.IsConditionFulfilled(unit, opponent))
        {
            effectOnUnit.ApplyEffect(opponent, unit);
            effectOnUnitAdditional.ApplyEffect(opponent, unit);
        }
    }
}