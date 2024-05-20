namespace Fire_Emblem;

public class Luna : Skill
{
    public Luna()
    {
        this.Name = "Luna";
        this.Description = "Durante el primer ataque de la unidad, ignora la mitad de Def y Res base del rival. " +
                           "(Considere esta reduccion como un Penalty).";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { 
            new ConditionEffectPair(new NoCondition(), 
                new DecreaseOpponentStatByPercentageOnFirstAttack(50, StatType.Def)),
            new ConditionEffectPair(new NoCondition(), 
                new DecreaseOpponentStatByPercentageOnFirstAttack(50, StatType.Res)) };
    }
}