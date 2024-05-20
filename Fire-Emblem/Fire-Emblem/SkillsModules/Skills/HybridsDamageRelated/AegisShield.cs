namespace Fire_Emblem;

public class AegisShield : Skill
{
    public AegisShield()
    {
        this.Name = "Aegis Shield";
        this.Description = "Otorga Def+6 y Res+3. Reduce el daño a la mitad en el primer ataque del rival";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { 
            new ConditionEffectPair(new NoCondition(), 
                new IncreaseStats([StatType.Def, StatType.Res], [6, 3])),
            new ConditionEffectPair(new NoCondition(), 
                new ReduceReceivedPermanentDamageByPercentageOnOpponentFirstAttack(0.5)) 
        };
    }
}