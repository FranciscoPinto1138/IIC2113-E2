namespace Fire_Emblem;

public class BlindingFlash : Penalty
{
    public BlindingFlash()
    {
        this.Name = "Blinding Flash";
        this.Description = "Si la unidad inicia el combate, inflige Spd-4 en el rival durante el combate.";
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