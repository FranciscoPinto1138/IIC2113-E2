namespace Fire_Emblem;

public class ArmsShield : AbsoluteDamageReduction
{
    public ArmsShield()
    {
        this.Name = "Arms Shield";
        this.Description = "Si la unidad tiene ventaja de arma, la unidad recibe -7 de daño en cada ataque del rival.";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { new ConditionEffectPair(
            new UnitHasWeaponAdvantageCondition(), new ReduceReceivedDamageByAbsoluteValue(7)) 
        };
    }
}