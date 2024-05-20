namespace Fire_Emblem;

public class FairFight : Bonus
{
    public FairFight()
    {
        this.Name = "Fair Fight";
        this.Description = "Si la unidad inicia el combate, otorga Atk+6 a la unidad y al rival durante el combate.";
    }
    
    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { 
            new ConditionEffectPair(
                new UnitStartsCombatCondition(), new IncreaseStats([StatType.Atk], [6])), 
            new ConditionEffectPair(
                new UnitStartsCombatCondition(), new IncreaseOpponentStats([StatType.Atk], [6]))
        };
    }
}