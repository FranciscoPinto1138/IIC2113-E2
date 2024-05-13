namespace Fire_Emblem;

public class AegisShield : Hybrid
{
    public AegisShield()
    {
        this.Name = "Aegis Shield";
        this.Description = "Otorga Def+6 y Res+3. Reduce el daño a la mitad en el primer ataque del rival";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        var condition = new NoCondition();
        var firstEffectOnUnit = new IncreaseStats([StatType.Def, StatType.Res], [6, 3]);
        var secondEffectOnUnit = new ReduceReceivedPermanentDamageByPercentageOnOpponentFirstAttack(0.5);
        return new ConditionEffectPair[] { new ConditionEffectPair(condition, firstEffectOnUnit),
            new ConditionEffectPair(condition, secondEffectOnUnit) };
    }
}