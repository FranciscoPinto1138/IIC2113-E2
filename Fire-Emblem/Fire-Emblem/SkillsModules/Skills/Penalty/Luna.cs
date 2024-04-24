namespace Fire_Emblem;

public class Luna : Penalty
{
    public Luna(Unit unit, Unit opponent) : base(unit, opponent)
    {
        this.Name = "Luna";
        this.Description = "Durante el primer ataque de la unidad, ignora la mitad de Def y Res base del rival. (Considere esta reduccion como un Penalty).";
        this.unit = unit;
        this.opponent = opponent;
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