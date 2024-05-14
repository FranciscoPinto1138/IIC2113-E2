namespace Fire_Emblem;

public class Luna : Penalty
{
    public Luna()
    {
        this.Name = "Luna";
        this.Description = "Durante el primer ataque de la unidad, ignora la mitad de Def y Res base del rival. (Considere esta reduccion como un Penalty).";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        var condition = new NoCondition();
        var effectOnOpponent = new DecreaseOpponentStatByPercentageOnFirstAttack(50, StatType.Def);
        var effectOnOpponentAdditional = new DecreaseOpponentStatByPercentageOnFirstAttack(50, StatType.Res);
        return new ConditionEffectPair[] { new ConditionEffectPair(condition, effectOnOpponent),
            new ConditionEffectPair(condition, effectOnOpponentAdditional) };
    }
}