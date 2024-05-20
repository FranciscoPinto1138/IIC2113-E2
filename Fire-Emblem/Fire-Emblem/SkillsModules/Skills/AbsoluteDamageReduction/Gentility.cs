namespace Fire_Emblem;

public class Gentility : AbsoluteDamageReduction
{
    public Gentility()
    {
        this.Name = "Gentility";
        this.Description = "La unidad recibe -5 de daño en cada ataque del rival";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { new ConditionEffectPair(
            new NoCondition(), new ReduceReceivedDamageByAbsoluteValue(5)) 
        };
    }
}