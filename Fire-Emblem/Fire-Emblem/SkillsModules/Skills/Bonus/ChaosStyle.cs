namespace Fire_Emblem;

public class ChaosStyle : Skill
{
    public ChaosStyle()
    {
        this.Name = "Chaos Style";
        this.Description = "Si la unidad inicia el combate con un ataque físico contra un rival armado " +
                           "con magia, o viceversa, otorga Spd+3 durante el combate.";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { new ConditionEffectPair(
            new AndPairCondition(new UnitStartsCombatCondition(), new UnitsHaveOppositeDamageTypes()), 
            new IncreaseStat(3, StatType.Spd)) 
        };
    }
}