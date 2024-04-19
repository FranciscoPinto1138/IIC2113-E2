namespace Fire_Emblem;

public class Perceptive : Bonus
{
    public Perceptive(Unit unit, Unit opponent) : base(unit, opponent)
    {
        this.Name = "Perceptive";
        this.Description = "Si la unidad inicia el combate, otorga Spd+12 a la unidad durante el combate, y por cada cuatro puntos de Spd (sin contar bonus), la unidad gana Spd+1 adicional.";
        this.unit = unit;
        this.opponent = opponent;
    }
    
    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var condition = new UnitStartsCombatCondition();
        var effectOnUnit = new IncreaseStat(12, StatType.Spd);
        var effectOnUnitAdditional = new IncreaseSpdByBaseSpdStat(4);
        if (condition.IsConditionFulfilled(unit, opponent))
        {
            effectOnUnit.ApplyEffect(unit, opponent);
            effectOnUnitAdditional.ApplyEffect(unit, opponent);
        }
    }
}