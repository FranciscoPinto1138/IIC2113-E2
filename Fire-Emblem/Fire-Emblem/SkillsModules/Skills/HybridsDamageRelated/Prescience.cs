namespace Fire_Emblem;

public class Prescience : Hybrid
{
    public Prescience()
    {
        this.Name = "Prescience";
        this.Description = "Inflige Atk/Res-5 en el rival durante el combate. Si la unidad inicia el combate o si el rival usa magia o arcos, reduce el daño del primer ataque del rival en un 30%.";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { 
            new ConditionEffectPair(
                new NoCondition(),
                new DecreaseOpponentStats([StatType.Atk, StatType.Res], [5, 5])),
            new ConditionEffectPair(new OrPairCondition(
                    new UnitStartsCombatCondition(),
                    new OrPairCondition(
                        new OpponentHasWeaponTypeCondition("Bow"),
                        new OpponentHasWeaponTypeCondition("Magic"))),
                new ReduceReceivedPermanentDamageByPercentageOnOpponentFirstAttack(0.3)) 
        };
    }
}