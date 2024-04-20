namespace Fire_Emblem;

public class BlindingFlash : Penalty
{
    public BlindingFlash(Unit unit, Unit opponent) : base(unit, opponent)
    {
        this.Name = "Blinding Flash";
        this.Description = "Si la unidad inicia el combate, inflige Spd-4 en el rival durante el combate.";
        this.unit = unit;
        this.opponent = opponent;
    }

    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var condition = new UnitStartsCombatCondition();
        var effectOnUnit = new DecreaseStat(4, StatType.Spd);
        if (condition.IsConditionFulfilled(unit, opponent))
        {
            effectOnUnit.ApplyEffect(opponent, unit);
        }
    }
}