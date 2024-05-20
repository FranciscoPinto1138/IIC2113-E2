namespace Fire_Emblem;

public class Bravery : Skill
{
    public Bravery()
    {
        this.Name = "Bravery";
        this.Description = "La unidad inflige +5 de daño en cada ataque.";
    }
    
    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { new ConditionEffectPair(
            new NoCondition(), new IncreaseExtraDamage(5)) 
        };
    }
}