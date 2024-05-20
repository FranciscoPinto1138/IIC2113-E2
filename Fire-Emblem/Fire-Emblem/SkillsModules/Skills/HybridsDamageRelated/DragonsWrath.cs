namespace Fire_Emblem;

public class DragonsWrath : Skill
{
    public DragonsWrath()
    {
        this.Name = "Dragon's Wrath";
        this.Description = "Reduce el daño del primer ataque del rival durante el combate en un 25%. " +
                           "Si el Atk de la unidad > Res del rival, el primer ataque de la unidad hace " +
                           "daño extra = 25% del Atk de la unidad menos Res del rival durante el combate.";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { 
            new ConditionEffectPair(
                new NoCondition(), 
                new ReduceReceivedPermanentDamageByPercentageOnOpponentFirstAttack(0.25)),
            new ConditionEffectPair(
                new UnitHasHigherAtkThanOpponentsResCondition(), 
                new IncreaseExtraDamageByQuarterOfUnitAtkOpponentResDiff())
        };
    }
}