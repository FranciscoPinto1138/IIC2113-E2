using System.Runtime.InteropServices.ComTypes;

namespace Fire_Emblem;

public class DeadlyBlade : Bonus
{
    public DeadlyBlade(Unit unit, Unit opponent) : base(unit, opponent)
    {
        this.Name = "Deadly Blade";
        this.Description = "Si la unidad inicia el combate con una espada, otorga Atk/Spd+8 durante el combate";
        this.unit = unit;
        this.opponent = opponent;
    }

    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var firstCondition = new UnitStartsCombatCondition();
        var secondCondition = new UnitHasWeaponTypeCondition("Sword");
        var effectOnUnit = new IncreaseStat(8, StatType.Atk);
        var effectOnUnitAdditional = new IncreaseStat(8, StatType.Spd);
        if (firstCondition.IsConditionFulfilled(unit, opponent) && secondCondition.IsConditionFulfilled(unit, opponent))
        {
            effectOnUnit.ApplyEffect(unit, opponent);
            effectOnUnitAdditional.ApplyEffect(unit, opponent);
        }
    }
}