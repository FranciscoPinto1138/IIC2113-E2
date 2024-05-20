namespace Fire_Emblem;

public class BlueSkies : Skill
{
    public BlueSkies()
    {
        this.Name = "Blue Skies";
        this.Description = "La unidad recibe -5 de daño en cada ataque del rival e inflige +5 de daño en cada ataque.";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { 
            new ConditionEffectPair(new NoCondition(), new IncreaseExtraDamage(5)),
            new ConditionEffectPair(new NoCondition(), new ReduceReceivedDamageByAbsoluteValue(5))
        };
    }
}